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
    public float PositionArrivalWaitTimeNow = 0;
    public float PositionArrivalWaitTime = 3;
    public bool Collidered;
    public GameObject collidered_obj;
    // Start is called before the first frame update
    void Start()
    {
        rigid = this.gameObject.GetComponent<Rigidbody>();
        //Player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(Collidered && collidered_obj == TargetPositions[NowPosition].gameObject)
        {
            PositionArrivalWaitTimeNow += Time.deltaTime;
            rigid.velocity = Vector3.zero;
            if (PositionArrivalWaitTimeNow > PositionArrivalWaitTime)
            {
                if (NowPosition < TargetPositions.Count - 1)
                {
                    NowPosition += 1;
                }
                else
                {

                    NowPosition = 0;
                }
                Collidered = false;
                PositionArrivalWaitTimeNow = 0;
            }

        }
    }
    private void FixedUpdate()
    {
        if (!Collidered)
        {
            rigid.velocity = (TargetPositions[NowPosition].transform.position - this.transform.position).normalized * speed;
        }
        else
        {
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "MovePosition")
        {
            collidered_obj = other.gameObject;
            Collidered = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "MovePosition")
        {
            collidered_obj = null;
            Collidered = false;
        }
    }
}
