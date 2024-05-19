using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
public class EnemyAction : SerializedMonoBehaviour
{
    private Animator anim;
    public bool Talk;
    public bool DirectionChange;
    [ShowIf("DirectionChange")]
    public bool Change;
    [ShowIf("DirectionChange")]
    public float ChangeWaitTime;
    private float ChangeWaitTimeNow;
    private EnemyMove enemy_move;
    public Dictionary<string, float> DirectionChangeVector = new Dictionary<string, float>() { { "before", 0 },{ "after",180 } };
    // Start is called before the first frame update
    void Start()
    {
        anim = this.gameObject.GetComponent<Animator>();
        enemy_move = this.gameObject.GetComponent<EnemyMove>();
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
    }
}
