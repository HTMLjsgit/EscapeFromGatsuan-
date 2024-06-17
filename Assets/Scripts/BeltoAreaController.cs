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
    public float BeltoCreateTime = 3;
    public GameObject gatsu_belto_prefab;
    public GameObject toumei_prefab;
    private GameObject Player;
    private Rigidbody player_rigid;
    public bool PlayerIntoBeltoArea;
    private float BeltoCreateTimeNow = 0;
    public float BeltoGatsuManSpeed;
    [Header("�v���C���[����炩�����Ƃ��ɔ��������܂ł̎��ԑ�(���Ԃ𒴂��Ȃ��悤�ɒ��߂���΃Z�[�t)")]
    public float DelayResponseTime = 1;
    public float DelayResponseMoveTimeNow = 0;
    public float DelayResponseStopTimeNow = 0;
    private Animator player_anim;
    private PlayerMovement player_movement;
    //[HideInInspector]
    public Dictionary<GameObject, bool> AllAlreadyPassedPoints = new Dictionary<GameObject, bool>();
    //�ŏI�`�F�b�N�𓾂Ă�����false�Ȃ�Ώ����N���A�ł��Ă���
    //True�ɂȂ�����}�ɏP���Ă���悤�ɂ����
    public bool BeltoAreaError;
    [Button]
    public void Create()
    {
        int r = Random.Range(0,3);
        GameObject gatsu_belto_man;
        GatsuBeltoMan gatsu_belto_man_script;
        GatsuBeltoMan.GatsuManOrTransParent who;
        //if (r == 2)
        //{
        //    gatsu_belto_man = Instantiate(toumei_prefab, create_gatsu_belto_pos.transform.position, Quaternion.identity);
        //    who = GatsuBeltoMan.GatsuManOrTransParent.TransparentMan;
        //}
        //else
        //{
        gatsu_belto_man = Instantiate(gatsu_belto_prefab, create_gatsu_belto_pos.transform.position, Quaternion.identity);
        who = GatsuBeltoMan.GatsuManOrTransParent.GatsuMan;
        //}
        gatsu_belto_man_script = gatsu_belto_man.GetComponent<GatsuBeltoMan>();
        gatsu_belto_man_script.belto_area_controller = this;
        gatsu_belto_man_script.gatsuman_or_transparentman = who;
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
        player_anim = Player.GetComponent<Animator>();
        player_movement = Player.GetComponent<PlayerMovement>();
        Create();
    }

    // Update is called once per frame
    void Update()
    {
        //AllAlreadyPassedToPoint = true;
        if (PlayerIntoBeltoArea)
        {
            if(player_movement.move_mode == PlayerMovement.MoveMode.Run)
            {
                BeltoAreaError = true;
            }
            if (player_movement.Crouch)
            {
                BeltoAreaError = true;
            }
            //if(player_movement.crouch)
            if (!AllAlreadyPassedPoints.ContainsValue(false))
            {
                Debug.Log("�S���X�g�b�v���Ă�����");
                Debug.Log("aaaaa:   " + Mathf.Floor(player_rigid.velocity.magnitude));
                DelayResponseStopTimeNow = 0;
                //�S��Move���I��������
                if (Mathf.Floor(player_rigid.velocity.magnitude) > 0f)
                {
                    //�S��Move���I����Ă���̂�Player�������Ă����甭�������B
                    Debug.Log("�S��Move���I����Ă���̂�Player�������Ă����甭�������");
                    DelayResponseMoveTimeNow += Time.deltaTime;
                    if(DelayResponseMoveTimeNow > 0.1f)
                    {
                        Debug.Log("�S���~�܂��Ă���̂ɓ����J���[�_���Ȃ�ł���");
                        BeltoAreaError = true;
                    }

                }
            }
            else if(!AllAlreadyPassedPoints.ContainsValue(true))
            {
                DelayResponseMoveTimeNow = 0;
                //�݂�ȓ����Ă�����
                if (Mathf.Floor(player_rigid.velocity.magnitude) < 1)
                {
                    //�S��Move���I����Ă���̂�Player�������Ă����甭�������B
                    Debug.Log("�����Ȃ�����������ꂽ");
                    DelayResponseStopTimeNow += Time.deltaTime;
                    if(DelayResponseStopTimeNow > DelayResponseTime)
                    {
                        BeltoAreaError = true;
                    }

                }
                else
                {
                    DelayResponseStopTimeNow = 0;
                }
                
            }
        }
        if (!AllAlreadyPassedPoints.ContainsValue(false))
        {
            BeltoCreateTimeNow += Time.deltaTime;
            if (BeltoCreateTimeNow > BeltoCreateTime)
            {
                Create();
                BeltoCreateTimeNow = 0;
            }
        }
        else
        {
            BeltoCreateTimeNow = 0;
        }
        if (BeltoAreaError)
        {
            enemy_controller.PermitDiscoveryToPlayer = true;
        }
        else
        {
            enemy_controller.PermitDiscoveryToPlayer = false;

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
