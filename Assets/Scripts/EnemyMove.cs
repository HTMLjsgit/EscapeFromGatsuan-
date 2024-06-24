using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using UnityEngine.AI;

public class EnemyMove : SerializedMonoBehaviour
{
    private Animator anim;
    private Rigidbody rigid;
    private GameObject Player;
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
    public bool ChaseToPlayer;
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
    private GameObject GameController;
    private Animator PlayerAnim;
    private EnemyController enemy_controller;
    private Vector3 SavePosiitonWhenChaseToPlayer;
    private bool SavePositionedOnce = false;
    private float ChaseToPlayerStartTimeNow;
    private AudioSource RunAwayBGM;
    // Start is called before the first frame update
    void Start()
    {
        rigid = this.gameObject.GetComponent<Rigidbody>();
        anim = this.gameObject.GetComponent<Animator>();
        Player = GameObject.FindWithTag("Player");
        PlayerAnim = Player.GetComponent<Animator>();
        nav_mesh_agent = this.gameObject.GetComponent<NavMeshAgent>();

        if(nav_mesh_agent.path.corners.Length >= 1)
        {
            NavmeshNextPos = nav_mesh_agent.path.corners[0];
        }
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
        if (!ChaseToPlayer && MoveToPlaces && !enemy_controller.DiscoveryToPlayer)
        {
            nav_mesh_agent.enabled = false;
            if (!AlreadyWalkMoved)
            {
                if (VectorFixedWhenMoveToPlaces)
                {
                }
                else
                {
                    this.transform.forward = new Vector3(TargetDiff.x, 0, TargetDiff.z);
                }
                if (Vector3.Distance(this.transform.position, TargetPosition) < 0.5f)
                {
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
            if (!VectorFixedWhenMoveToPlaces)
            {
                anim.SetBool("Walk", !AlreadyWalkMoved);
                anim.SetBool("HorizontalRun", false);
            }
            else
            {
                //横に歩くアニメーション
                anim.SetBool("HorizontalRun", true);
                float x = 0;
                if(TargetDiff.x > 0)
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

                ChaseToPlayer = true;
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
            ChaseToPlayer = false;
            SavePositionedOnce = false;
            ChaseToPlayerStartTimeNow = 0;
            if (enemy_controller.MissedPlayer)
            {
                //this.transform.position= this.transform.position - SavePosiitonWhenChaseToPlayer;
            }
        }

        if (ChaseToPlayer)
        {
            nav_mesh_agent.enabled = true;
            if(Player != null)
            {
                nav_mesh_agent.destination = Player.transform.position;
            }
            if (nav_mesh_agent.path.corners.Length > 2)
            {
                NavmeshNextPos = nav_mesh_agent.path.corners[1];
            }
            else
            {
                NavmeshNextPos = Player.transform.position;
            }
            InsideToPlayerDistance = Vector3.Distance(this.transform.position, Player.transform.position) <= nav_mesh_agent.stoppingDistance;

            if (Vector3.Distance(NavmeshNextPos, this.transform.position) <= 1)
            {
                nav_mesh_agent.nextPosition = NavmeshNextPos;
            }



            if (AttackEnd)
            {
                this.transform.forward = nav_mesh_agent.steeringTarget - this.transform.position;
            }
            else
            {
            }

            anim.SetBool("Walk", false);

            if (InsideToPlayerDistance)
            {
                anim.SetBool("Run", false);
                if (AttackEnd)
                {
                    anim.SetTrigger("Attack");
                }
            }
            else
            {
                anim.SetBool("Run", true);
            }
        }

    }
    private void OnDrawGizmos()
    {
        if(Player != null)
        {
            Vector3 prepos = Player.transform.position;
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
        if (!ChaseToPlayer)
        {
            if (!AlreadyWalkMoved)
            {
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
                if (AttackEnd)
                {
                    rigid.velocity = ((NavmeshNextPos - this.transform.position).normalized * nav_mesh_agent.speed);
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

}
