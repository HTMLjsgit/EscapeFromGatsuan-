using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Animator anim;
    private EnemyMove enemy_move;
    private CharactorMovePermit player_move_permit;
    private GameController game_controller;
    private RaycastHit hit;
    public Transform MyEyePosition;
    private Transform PlayersEyePosition;
    public bool DiscoveryToPlayer;
    public bool MissedPlayer;
    public float VisionFieldAngle = 80;
    private GameObject Player;
    private PlayerController player_controller;
    public Collidered collidered;
    // Start is called before the first frame update
    void Start()
    {
        enemy_move = this.gameObject.GetComponent<EnemyMove>();
        game_controller = GameObject.FindWithTag("GameController").GetComponent<GameController>();
        Player = GameObject.FindWithTag("Player");
        player_controller = Player.GetComponent<PlayerController>();
        player_move_permit = Player.GetComponent<CharactorMovePermit>();
        PlayersEyePosition = player_controller.PlayersEyePosition;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = PlayersEyePosition.transform.position - MyEyePosition.transform.position;

        if (enemy_move.InsideToPlayerDistance)
        {
            player_move_permit.Stop();
        }

        if(Vector3.Angle(direction, MyEyePosition.forward) <= VisionFieldAngle && collidered.Collider)
        {
            if(this.gameObject.name == "gatsu_unko2" || this.gameObject.name == "gatsu_unko1")
            {
                Debug.Log("Angleないにいる");
            }
            
            //Playerが敵の視界以内にいるかを判定する。まずね
            if(Physics.Raycast(MyEyePosition.transform.position, direction,out hit, 100))
            {
                Debug.Log("tag11111: " + hit.collider.gameObject.tag);
                //Ray光線をPlayerに飛ばして、壁に当たらないかつPlayerに当たったら判定とするよ！
                if (hit.collider.gameObject.layer != LayerMask.NameToLayer("Object"))
                {
                    Debug.Log("tag2222: " + hit.collider.gameObject.tag);
                    if(hit.collider.gameObject.tag == "Player")
                    {
                        Debug.Log("Playerに当たりましたね！");
                        DiscoveryToPlayer = true;
                        MissedPlayer = false;
                    }
                    else
                    {
                        //DiscoveryToPlayer = false;
                    }
                }
                else if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Object"))
                {
                    Debug.Log("壁に当たってると思う");
                    if (DiscoveryToPlayer)
                    {
                        MissedPlayer = true;
                        //DiscoveryToPlayer = false;
                    }
                }
            }
            else
            {
                //DiscoveryToPlayer = false;
            }
            Debug.DrawLine(MyEyePosition.transform.position, direction, Color.red);
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawRay(MyEyePosition.transform.position, (Quaternion.Euler(0, -VisionFieldAngle, 0) * this.transform.forward) * 10);
        Gizmos.DrawRay(MyEyePosition.transform.position, (Quaternion.Euler(0, VisionFieldAngle, 0) * this.transform.forward) * 10);

    }

}
