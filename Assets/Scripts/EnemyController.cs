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
    private EnemyAction enemy_action;
    public Collidered collidered;
    public List<string> TargetLayers = new List<string>() { "Object" };
    public bool PermitDiscoveryToPlayer = true;
    // Start is called before the first frame update
    void Start()
    {
        enemy_action = this.gameObject.GetComponent<EnemyAction>();
        enemy_move = this.gameObject.GetComponent<EnemyMove>();
        game_controller = GameObject.FindWithTag("GameController").GetComponent<GameController>();
        Player = GameObject.FindWithTag("Player");
        player_controller = Player.GetComponent<PlayerController>();
        player_move_permit = Player.GetComponent<CharactorMovePermit>();
        PlayersEyePosition = player_controller.PlayersEyePosition;
        //TargetLayers.Add("Object");
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
                Debug.Log("Angle‚È‚¢‚É‚¢‚é");
            }
            
            //Player‚ª“G‚ÌŽ‹ŠEˆÈ“à‚É‚¢‚é‚©‚ð”»’è‚·‚éB‚Ü‚¸‚Ë
            if(Physics.Raycast(MyEyePosition.transform.position, direction,out hit, 100000000))
            {
                //RayŒõü‚ðPlayer‚É”ò‚Î‚µ‚ÄA•Ç‚É“–‚½‚ç‚È‚¢‚©‚ÂPlayer‚É“–‚½‚Á‚½‚ç”»’è‚Æ‚·‚é‚æI
                if (!TargetLayers.Contains(LayerMask.LayerToName(hit.collider.gameObject.layer)))
                {
                    if(hit.collider.gameObject.tag == "Player")
                    {
                        if (PermitDiscoveryToPlayer)
                        {
                            DiscoveryToPlayer = true;
                            MissedPlayer = false;
                        }
                    }
                    else
                    {
                        //DiscoveryToPlayer = false;
                    }
                }
                else if (TargetLayers.Contains(LayerMask.LayerToName(hit.collider.gameObject.layer)))
                {
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
