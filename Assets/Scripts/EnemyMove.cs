using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using UnityEngine.AI;
using DG.Tweening;
using UnityEngine.Events;
public class EnemyMove : SerializedMonoBehaviour
{
    private Animator anim;
    private Rigidbody rigid;
    private GameObject Player;
    public GameObject ChaseToTarget;
    public GameObject[] ToMovePlaces;
    public bool AlreadyWalkMoved = true;
    public bool MoveToPlaces = true;
    private Vector3 TargetPosition;
    private Vector3 TargetDiff;
    private Vector3 direction;
    private Vector3 PlayerToDistance;
    private Vector3 ToPlayerDirection;
    private Vector3 NavmeshNextPos;
    private bool MoveMode = true;
    public int CountNow = 0;
    public bool ChaseToTargetMode;
    private NavMeshAgent nav_mesh_agent;
    private bool AttackStoppedOnce;
    private bool StoppedOnce;
    [ShowIf("MoveToPlaces")]
    public float WalkToNextPositionWaitTime = 1f;
    [ShowIf("MoveToPlaces")]
    public bool VectorFixedWhenMoveToPlaces;
    public float WalkSpeed = 2;
    public bool InsideToPlayerDistance;
    public bool AttackEnd = true;
    public bool ReturnToDefaultPositionMode;
    public float ReturnSpeed = 6;
    private GameObject GameController;
    private Animator PlayerAnim;
    private EnemyController enemy_controller;
    private bool SavePositionedOnce = false;
    private float ChaseToPlayerStartTimeNow;
    private AudioSource RunAwayBGM;
    private Vector3 DefaultPosition;
    private Vector3 DefaultRotation;
    public bool AlreadyReturnedOnce = false;
    private EnemyAction enemy_action;
    private bool ReturnOnceEvent;
    private RaycastHit hitCol;
    private int layerMask;
    private float StickWallTimeNow;
    public Transform RayPos;
    // Start is called before the first frame update
    void Start()
    {
        rigid = this.gameObject.GetComponent<Rigidbody>();
        anim = this.gameObject.GetComponent<Animator>();
        DefaultRotation = this.transform.rotation.eulerAngles;
        Player = GameObject.FindWithTag("Player");
        PlayerAnim = Player.GetComponent<Animator>();
        DefaultPosition = this.transform.position;
        nav_mesh_agent = this.gameObject.GetComponent<NavMeshAgent>();
        ChaseToTarget = Player;
        layerMask = LayerMask.GetMask(new string[] { "Object" });
        if (nav_mesh_agent.path.corners.Length >= 1)
        {
            NavmeshNextPos = nav_mesh_agent.path.corners[0];
        }
        enemy_action = this.gameObject.GetComponent<EnemyAction>();
        nav_mesh_agent.updatePosition = false;
        nav_mesh_agent.updateRotation = false;
        GameController = GameObject.FindWithTag("GameController");
        RunAwayBGM = GameObject.FindWithTag("MainBGM").GetComponent<MainBGM>().RunAwayBGM.GetComponent<AudioSource>();
        enemy_controller = this.gameObject.GetComponent<EnemyController>();
        if (MoveToPlaces)
        {
            MovePosition();
        }
    }

    // Update is called once per frame
    void Update()
    {
        PlayerToDistance = Player.transform.position - this.transform.position;
        ToPlayerDirection = PlayerToDistance.normalized;
        if (AlreadyReturnedOnce)
        {
            anim.SetBool("Walk", false);
            anim.SetBool("Run", false);
            //帰還済みならば
            if (MoveToPlaces)
            {
                Debug.Log("きかんずみ");
                CountNow = 0;
                MovePosition();
            }
            AlreadyReturnedOnce = false;
        }
        if (ReturnToDefaultPositionMode || ChaseToTargetMode)
        {
            if (AttackEnd)
            {
                Vector3 forward = (nav_mesh_agent.steeringTarget - this.transform.position).normalized;
                this.transform.forward = new Vector3(forward.x, 0, forward.z);
            }
            enemy_action.enabled = false;
        }
        else
        {
            enemy_action.enabled = true;
        }
        if (ReturnToDefaultPositionMode)
        {
            Debug.Log("WalkMode");
            anim.SetBool("Walk", true);
        }
        //壁にずーとぶつかり続けているなら一旦disabledにしておく
        Debug.DrawRay(RayPos.position, this.transform.forward.normalized * 1.5f, Color.magenta);
        if (Physics.Raycast(RayPos.position,  this.transform.forward, out hitCol, 1.5f, layerMask))
        {
            if(MoveToPlaces && !ChaseToTargetMode && !ReturnToDefaultPositionMode)
            {
                return;
            }
            Debug.Log("壁にぶつかり続けています");
            if (hitCol.collider.gameObject.layer == LayerMask.NameToLayer("Object"))
            {
                StickWallTimeNow += Time.deltaTime;
                if(StickWallTimeNow > 1)
                {
                    nav_mesh_agent.enabled = false;
                    StickWallTimeNow = 0;
                }
            }
        }
        if (!ChaseToTargetMode && !ReturnToDefaultPositionMode && MoveToPlaces && !enemy_controller.DiscoveryToPlayer)
        {
            //MoveToPlacesの動作

            nav_mesh_agent.enabled = false;
            if (!AlreadyWalkMoved)
            {
                if (VectorFixedWhenMoveToPlaces)
                {
                }
                else
                {
                    this.transform.forward = new Vector3(direction.x, 0, direction.z);
                }
                if (Vector3.Distance(this.transform.position, TargetPosition) < 0.5f)
                {
                    Debug.Log("");
                    if (CountNow + 1 >= ToMovePlaces.Length)
                    {
                        CountNow = 0;
                    }
                    else
                    {
                        CountNow += 1;
                    }
                    Invoke("MovePosition", WalkToNextPositionWaitTime);
                    AlreadyWalkMoved = true;
                }
            }
            if (!VectorFixedWhenMoveToPlaces && !ReturnToDefaultPositionMode)
            {
                anim.SetBool("Walk", !AlreadyWalkMoved);
                anim.SetBool("HorizontalRun", false);
            }
            else
            {
                //横に歩くアニメーション
                anim.SetBool("HorizontalRun", true);
                float x = 0;
                if (TargetDiff.x > 0)
                {
                    x = 1;
                }
                else
                {
                    x = -1;
                }
                anim.SetFloat("DirectionX", x);
            }
            anim.SetBool("Run", false);
        }

        if (enemy_controller.DiscoveryToPlayer)
        {
            ChaseToPlayerStartTimeNow += Time.deltaTime;
            if (ChaseToPlayerStartTimeNow >= 0.5f)
            {

                ChaseToTargetMode = true;
            }
            else
            {
                rigid.velocity = Vector3.zero;
            }
            if (!SavePositionedOnce)
            {
                if (!RunAwayBGM.isPlaying)
                {
                    RunAwayBGM.Play();
                }
                anim.SetBool("Walk", false);
                this.transform.forward = ToPlayerDirection;
                SavePositionedOnce = true;
            }
        }
        else
        {
            SavePositionedOnce = false;
            ChaseToPlayerStartTimeNow = 0;
        }
        //探索結果を利用して移動するコード。
        if (ReturnToDefaultPositionMode)
        {
            if (!ReturnOnceEvent)
            {

                Debug.Log("naaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
                ReturnOnceEvent = true;
            }
            if (Vector3.Distance(this.transform.position, DefaultPosition) <= 1)
            {
                AlreadyReturnedOnce = true;
                ReturnToDefaultPositionMode = false;
                this.transform.DORotate(DefaultRotation, 0.3f).SetEase(Ease.Linear).SetLink(this.gameObject);
            }
            MoveByFinder(DefaultPosition);
        }
        else
        {
            ReturnOnceEvent = false;
        }
        if (ChaseToTargetMode && ChaseToTarget != null)
        {
            if (ChaseToTarget == Player)
            {
                InsideToPlayerDistance = Vector3.Distance(this.transform.position, ChaseToTarget.transform.position) <= nav_mesh_agent.stoppingDistance;
            }
            else
            {
                InsideToPlayerDistance = Vector3.Distance(this.transform.position, ChaseToTarget.transform.position) <= 5;
            }
            MoveByFinder(ChaseToTarget.gameObject.transform.position);
            anim.SetBool("Walk", false);

            if (InsideToPlayerDistance)
            {
                anim.SetBool("Run", false);
                if (AttackEnd && ChaseToTarget == Player)
                {
                    anim.SetTrigger("Attack");
                }
            }
            else if (!InsideToPlayerDistance)
            {
                anim.SetBool("Run", true);
            }

        }
        else
        {

        }

    }
    private IEnumerator ie()
    {
        yield return new WaitForSeconds(1);
        nav_mesh_agent.enabled = false;
    }
    private void OnDrawGizmos()
    {
        if (ChaseToTargetMode)
        {
            if (ChaseToTarget != null)
            {
                Vector3 prepos = ChaseToTarget.transform.position;
                Gizmos.color = Color.green;
                foreach (Vector3 pos in nav_mesh_agent.path.corners)
                {
                    Gizmos.DrawLine(prepos, pos);
                    prepos = pos;
                }
            }
        }
        else if (ReturnToDefaultPositionMode)
        {
            Vector3 prepos = DefaultPosition;
            Gizmos.color = Color.green;
            foreach (Vector3 pos in nav_mesh_agent.path.corners)
            {
                Gizmos.DrawLine(prepos, pos);
                prepos = pos;
            }
        }


    }
    private void FixedUpdate()
    {
        if (!ChaseToTargetMode && !ReturnToDefaultPositionMode)
        {
            if (!AlreadyWalkMoved)
            {
                //this.transform.forward = new Vector3();
                rigid.velocity = (direction * WalkSpeed);
            }
            else
            {
                rigid.velocity = Vector3.zero;
            }
        }
        else
        {
            if (!InsideToPlayerDistance)
            {
                Debug.Log("いまきかんちゅうになるはずですが");
                float speed = 0;
                if (ChaseToTargetMode)
                {
                    speed = nav_mesh_agent.speed;

                }
                else if (!ChaseToTarget && ReturnToDefaultPositionMode)
                {
                    speed = ReturnSpeed;
                }
                if (AttackEnd)
                {
                    rigid.velocity = ((NavmeshNextPos - this.transform.position).normalized * speed);
                }
            }
            else
            {
                rigid.velocity = Vector3.zero;
            }
        }

    }
    [Button]
    public void MovePosition()
    {
        TargetPosition = ToMovePlaces[CountNow].transform.position;
        TargetDiff = TargetPosition - this.gameObject.transform.position;
        direction = TargetDiff.normalized;
        AlreadyWalkMoved = false;
    }
    public void AttackEndChange(bool ended)
    {
        this.AttackEnd = ended;
    }
    public void ChaseToTargetSet(GameObject Target)
    {
        ChaseToTarget = Target;
    }
    private void NavmeshDisabled()
    {
        nav_mesh_agent.enabled = false;
    }
    private void MoveByFinder(Vector3 target_pos)
    {
        nav_mesh_agent.enabled = true;
        //探索結果を利用して目的地に移動するコード
        nav_mesh_agent.destination = target_pos;
        if (nav_mesh_agent.path.corners.Length > 2)
        {
            NavmeshNextPos = nav_mesh_agent.path.corners[1];
        }
        else
        {
            NavmeshNextPos = target_pos;
        }
        if (Vector3.Distance(NavmeshNextPos, this.transform.position) <= 0.5f)
        {
            nav_mesh_agent.nextPosition = NavmeshNextPos;
        }

    }
}
