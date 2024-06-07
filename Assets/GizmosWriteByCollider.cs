using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GizmosWriteByCollider : MonoBehaviour
{
    private BoxCollider box_collider;
    private void Awake()
    {
    }
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }
    private void OnDrawGizmos()
    {
        if(box_collider == null)
        {
            Debug.Log("nullCollider");
            box_collider = this.gameObject.GetComponent<BoxCollider>();
        }
        Gizmos.color = Color.red;
        Gizmos.DrawCube(this.transform.position + box_collider.center, new Vector3(box_collider.size.z, box_collider.size.x, box_collider.size.y));
    }
}
