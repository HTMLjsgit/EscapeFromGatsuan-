using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackController : MonoBehaviour
{
    private GameObject Player;
    private Animator player_anim;
    private AudioSource AttackSoundSource;
    public AudioClip AttackSoundClip;
    private EnemyMove enemy_move;
    private EnemyAction enemy_action;
    public bool Death;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindWithTag("Player");
        player_anim = Player.GetComponent<Animator>();
        AttackSoundSource = this.gameObject.GetComponent<AudioSource>();
        enemy_move = this.gameObject.GetComponent<EnemyMove>();
        enemy_action = this.gameObject.GetComponent<EnemyAction>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Death)
        {
            player_anim.SetBool("Death", true);
        }
    }
    public void AttackToTarget()
    {
        if(enemy_move.InsideToPlayerDistance)
        {
            AttackSoundSource.PlayOneShot(AttackSoundClip);
            Death = true;
        }
        if (enemy_action.WallBreak)
        {
            if (enemy_action.wall_break_setting.WallBreakNow)
            {
                enemy_action.AttackWall();
            }
        }

    }

}
