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
    public CreateGatsuBeltoPos create_gatsu_belto_pos;

    public List<Transform> BeltoColliderAreaPositions;

    public Dictionary<Transform, BeltoManStatus> BeltoManLists;
    public bool FirstBeltoAreaAlreadyPassed = true;
    public float WaitBeltoAreaToNextPointTime = 1;
    private float WaitBeltoAreaToNextPointTimeNow = 1;
    public GameObject gatsu_belto_prefab;
    public GameObject toumei_prefab;
    private GameObject Player;
    private bool PlayerIntoBeltoArea;
    public float BeltoGatsuManSpeed;
    private bool AllAlreadyPassedToPoint = true;
    //最終チェックを得てこいつがfalseならば条件クリアできている
    private bool BeltoAreaError;
    [Button]
    public void Create()
    {
        int r = Random.Range(0,5);
        GameObject gatsu_belto_man;
        GatsuBeltoMan gatsu_belto_man_script;
        GatsuBeltoMan.GatsuManOrTransParent who;
        if (r == 3)
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
        AllAlreadyPassedToPoint = true;
    }
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        //AllAlreadyPassedToPoint = true;
        foreach (KeyValuePair<Transform, BeltoManStatus> transform_belto in BeltoManLists)
        {
            if (!transform_belto.Value.AlreadyPassedToPoint)
            {
                //AllAlreadyPassedToPoint = false;
            }
        }
        if (PlayerIntoBeltoArea)
        {
            //まずはベルト判断エリアにいるのかどうか。
            
        }
        else
        {
            //BeltoAreaError = true;
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
