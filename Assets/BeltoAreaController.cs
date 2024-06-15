using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq; 
using Sirenix.OdinInspector;
public class BeltoAreaController : SerializedMonoBehaviour
{
    public class BeltoManStatus
    {
        public int index;
        public bool AlreadyPassedToPoint = false;
        public Transform PointPos;
        public BeltoManStatus(int _index, bool _AlreadyPassedToPoint)
        {
            this.index = _index;
            this.AlreadyPassedToPoint = _AlreadyPassedToPoint;
        }
    }
    public GameObject EnemyGatsu;
    private EnemyController enemy_controller;
    public CreateGatsuBeltoPos create_gatsu_belto_pos;

    public List<Transform> BeltoColliderAreaPositions;

    public Dictionary<Transform, BeltoManStatus> BeltoManLists;
    public bool FirstBeltoAreaAlreadyPassed = true;
    public float WaitBeltoAreaToNextPointTime = 1;
    private float WaitBeltoAreaToNextPointTimeNow = 1;
    public GameObject gatsu_belto_prefab;
    public GameObject toumei_prefab;
    private GameObject Player;
    private Rigidbody player_rigid;
    private bool PlayerIntoBeltoArea;
    private float BeltoCreateTimeNow = 0;
    public float BeltoGatsuManSpeed;
    //[HideInInspector]
    public Dictionary<GameObject, bool> AllAlreadyPassedPoints = new Dictionary<GameObject, bool>();
    //最終チェックを得てこいつがfalseならば条件クリアできている
    //Trueになったら急に襲ってくるようにするよ
    public bool BeltoAreaError;
    [Button]
    public void Create()
    {
        int r = Random.Range(0,3);
        GameObject gatsu_belto_man;
        GatsuBeltoMan gatsu_belto_man_script;
        GatsuBeltoMan.GatsuManOrTransParent who;
        if (r == 2)
        {
            gatsu_belto_man = Instantiate(toumei_prefab, create_gatsu_belto_pos.transform.position, Quaternion.identity);
            who = GatsuBeltoMan.GatsuManOrTransParent.TransparentMan;
        }
        else
        {
            gatsu_belto_man = Instantiate(gatsu_belto_prefab, create_gatsu_belto_pos.transform.position, Quaternion.identity);
            who = GatsuBeltoMan.GatsuManOrTransParent.GatsuMan;
        }
        gatsu_belto_man_script = gatsu_belto_man.GetComponent<GatsuBeltoMan>();
        gatsu_belto_man_script.belto_area_controller = this;
        gatsu_belto_man_script.gatsuman_or_transparentman = who;
        Debug.Log(BeltoManLists.Count);
        foreach(KeyValuePair<Transform, BeltoManStatus> b in BeltoManLists)
        {
            b.Value.index += 1;
        }
        BeltoManStatus belto_man_status;
        belto_man_status = new BeltoManStatus(0, false);
        gatsu_belto_man_script.target_belto_man_status = belto_man_status;
        gatsu_belto_man_script.speed = this.BeltoGatsuManSpeed;
        BeltoManLists.Add(gatsu_belto_man.transform, belto_man_status);
        AllAlreadyPassedPoints.Add(gatsu_belto_man, false);
    }
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindWithTag("Player");
        player_rigid = Player.GetComponent<Rigidbody>();
        enemy_controller = EnemyGatsu.GetComponent<EnemyController>();
        Create();
        PlayerIntoBeltoArea = true;
    }

    // Update is called once per frame
    void Update()
    {
        //AllAlreadyPassedToPoint = true;
        if (PlayerIntoBeltoArea)
        {
            if(AllAlreadyPassedPoints.ContainsValue(false))
            {
                //まだMoveしている最中の人がいる
                BeltoCreateTimeNow = 0;
            }
            else
            {
                //全員Moveが終わった状態
                BeltoCreateTimeNow += Time.deltaTime;
                if(BeltoCreateTimeNow > 1)
                {
                    Create();
                }
                if (Mathf.Floor(player_rigid.velocity.magnitude) == 0)
                {
                    //全員Moveが終わっているのにPlayerが動いていたら発見される。
                    BeltoAreaError = true;
                }
            }
        }
        if (BeltoAreaError)
        {
            enemy_controller.PermitDiscoveryToPlayer = true;
        }

    }
    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            PlayerIntoBeltoArea = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            PlayerIntoBeltoArea = false;
        }
    }
}
