using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravitySetting : MonoBehaviour
{
    private Rigidbody rigid;
    public Vector3 Gravity = new Vector3(0,-10,0);
    // Start is called before the first frame update
    void Start()
    {
        rigid = this.gameObject.GetComponent<Rigidbody>();
        rigid.useGravity = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rigid.AddForce(Gravity, ForceMode.Acceleration);
    }
}
