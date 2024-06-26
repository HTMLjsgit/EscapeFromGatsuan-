using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
public class BeruAreaController : SerializedMonoBehaviour
{
    public enum ColMode
    {
        Default,
        PlayerInto,
        PlayerOutside
    }
    private beru_ring beruring;
    public bool BeruRingNow;
    public GameObject BeruAreaPlayer;
    private GameObject Player;
    private PlayerMovement player_movement;
    public ColMode col_mode;
    private bool beruring_once;
    public float BeruRingWhileTime;
    public List<GameObject> ChaseEnemys;
    private float BeruRingWhileTimeNow;
    private Rigidbody player_rigid;
    // Start is called before the first frame update
    void Start()
    {
        beruring = this.gameObject.GetComponent<beru_ring>();
        Player = GameObject.FindWithTag("Player");
        player_movement = Player.GetComponent<PlayerMovement>();
        player_rigid = Player.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(col_mode == ColMode.PlayerInto)
        {
            if (!beruring_once && !BeruRingNow)
            {
                if (player_movement.Crouch || Mathf.Round(player_rigid.velocity.magnitude) == 0) return;
                BeruRing();
                beruring_once = true;
            }
        }
        else if(col_mode == ColMode.PlayerOutside)
        {
            beruring_once = false;
        }
        if (BeruRingNow)
        {
            BeruRingWhileTimeNow += Time.deltaTime;
            if (BeruRingWhileTime < BeruRingWhileTimeNow)
            {
                BeruRingEnded();
                BeruRingWhileTimeNow = 0;
            }
        }
        else
        {
            BeruRingWhileTimeNow = 0;
        }
    }
    [Button]
    public void BeruRing()
    {
        BeruRingNow = true;
        //�x����������B
        foreach (GameObject enemy in ChaseEnemys)
        {
            EnemyMove enemy_move = enemy.GetComponent<EnemyMove>();
            enemy_move.ChaseToTargetSet(BeruAreaPlayer);
            enemy_move.ChaseToTargetMode = true;
        }
        beruring.Ring();
    }
    [Button]
    public void BeruRingEnded()
    {
        BeruRingNow = false;
        beruring.StopRing();
        foreach (GameObject enemy in ChaseEnemys)
        {
            EnemyMove enemy_move = enemy.GetComponent<EnemyMove>();
            enemy_move.ChaseToTargetSet(null);
            enemy_move.ChaseToTargetMode = false;
            enemy_move.ReturnToDefaultPositionMode = true;
            enemy_move.InsideToPlayerDistance = false;
        }
    }
}