using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMove : MonoBehaviour
{
    private Rigidbody rigid;
    public float speed;
    public List<Transform> TargetPositions;
    public int NowPosition = 0;
    private GameObject Player;
    private float PositionArrivalWaitTimeNow = 0;
    public float PositionArrivalWaitTime = 3;
    // Start is called before the first frame update
    void Start()
    {
        rigid = this.gameObject.GetComponent<Rigidbody>();
        //Player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(this.transform.position, TargetPositions[NowPosition].transform.position) <= 3)
        {
            PositionArrivalWaitTimeNow += Time.deltaTime;
            Debug.Log("--------------------------------------!!!!");
            if(PositionArrivalWaitTimeNow > PositionArrivalWaitTime)
            {
                if (NowPosition < TargetPositions.Count - 1)
                {
                    NowPosition += 1;
                }
                else
                {

                    NowPosition = 0;
                }
                PositionArrivalWaitTimeNow = 0;
            }

        }
    }
    private void FixedUpdate()
    {

        rigid.velocity = (TargetPositions[NowPosition].transform.position - this.transform.position).normalized * speed;

    }
}
