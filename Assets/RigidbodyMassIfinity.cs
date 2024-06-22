using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidbodyMassIfinity : MonoBehaviour
{
    private Rigidbody rigid;
    // Start is called before the first frame update
    void Start()
    {
        rigid = this.gameObject.GetComponent<Rigidbody>();
        rigid.mass = Mathf.Infinity;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
