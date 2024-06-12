using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidbodyRemoveAndCreate : MonoBehaviour
{
    private Rigidbody rigid;
    // Start is called before the first frame update
    void Start()
    {
        rigid = this.gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void Remove()
    {
        Debug.Log("Removeeee");
        Destroy(this.gameObject.GetComponent<Rigidbody>());
    }
    public void Create()
    {
        this.gameObject.AddComponent<Rigidbody>();
    }
}
