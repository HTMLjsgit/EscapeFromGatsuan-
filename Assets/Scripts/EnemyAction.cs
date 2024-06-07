using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using Cinemachine;
public class EnemyAction : SerializedMonoBehaviour
{
    public class WallBreakSetting{
        public int AttackedCountForWallBreak = 2;
        public bool WallBreakNow = true;
        public AudioClip wall_attack_sound;
        public AudioClip wall_broken_sound;
        public GameObject TargetWall;
        public int AttackedCountForWallBreakNow;
        public ParticleSystem[] broken_dusts;
        public ParticleSystem[] attacked_wall_dusts;
    }

    private Animator anim;
    public bool Talk;
    public bool PlayAnimMode;
    [ShowIf("PlayAnimMode")]
    public string PlayAnimName; 

    public bool DirectionChange;
    [ShowIf("DirectionChange")]
    public bool Change;
    [ShowIf("DirectionChange")]
    public float ChangeWaitTime;
    public bool WallBreak;
    [ShowIf("WallBreak")]
    public WallBreakSetting wall_break_setting;

    private float ChangeWaitTimeNow;
    private EnemyMove enemy_move;
    private AudioSource audio_source;
    private CinemachineImpulseSource cinemachine_impulse_source;
    public Dictionary<string, float> DirectionChangeVector = new Dictionary<string, float>() { { "before", 0 },{ "after",180 } };
    // Start is called before the first frame update
    void Start()
    {
        anim = this.gameObject.GetComponent<Animator>();
        enemy_move = this.gameObject.GetComponent<EnemyMove>();
        audio_source = this.gameObject.GetComponent<AudioSource>();
        if(wall_break_setting != null)
        {
            wall_break_setting.AttackedCountForWallBreakNow = wall_break_setting.AttackedCountForWallBreak;
            cinemachine_impulse_source = GameObject.FindWithTag("VirtualCamera").GetComponent<CinemachineImpulseSource>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("Talk", Talk);
        if (DirectionChange && !enemy_move.ChaseToPlayer)
        {
            ChangeWaitTimeNow += Time.deltaTime;
            if(ChangeWaitTimeNow > ChangeWaitTime)
            {
                if (!Change)
                {
                    Change = true;
                }
                else
                {
                    Change = false;
                }
                ChangeWaitTimeNow = 0;
            }
            if (Change)
            {
                this.transform.rotation = Quaternion.Euler(new Vector3(0, DirectionChangeVector["after"],0));
            }
            else
            {
                this.transform.rotation = Quaternion.Euler(new Vector3(0, DirectionChangeVector["before"], 0));
            }
        }
        if (WallBreak)
        {
            if (wall_break_setting.WallBreakNow)
            {
                if (enemy_move.AttackEnd)
                {
                    anim.SetTrigger("Attack");
                }
                if (wall_break_setting.AttackedCountForWallBreakNow <= 0)
                {
                    wall_break_setting.WallBreakNow = false;
                    WallBreak = false;
                }
            }

        }

        if(PlayAnimMode == true)
        {
            anim.SetBool(PlayAnimName, true);
        }
    }
    public void AttackWallMode(bool mode)
    {
        WallBreak = mode;
    }
    public void AttackWall()
    {
        wall_break_setting.AttackedCountForWallBreakNow -= 1;
        if(wall_break_setting.AttackedCountForWallBreakNow == 0)
        {
            audio_source.PlayOneShot(wall_break_setting.wall_broken_sound);
            foreach(ParticleSystem ps in wall_break_setting.broken_dusts)
            {
                ps.Play();
            }
            Destroy(wall_break_setting.TargetWall);
            cinemachine_impulse_source.GenerateImpulse();
        }
        foreach (ParticleSystem ps in wall_break_setting.attacked_wall_dusts)
        {
            ps.Play();
        }
        audio_source.PlayOneShot(wall_break_setting.wall_attack_sound);
        cinemachine_impulse_source.GenerateImpulse();
        Debug.Log("•Ç‚ðUŒ‚’†I + " + wall_break_setting.AttackedCountForWallBreakNow);
    }
}
