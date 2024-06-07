using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RealyPoint : MonoBehaviour
{
    private RelayPointSave relay_point_save;
    // Start is called before the first frame update
    void Start()
    {
        relay_point_save = GameObject.FindWithTag("GameController").GetComponent<RelayPointSave>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<RelayPointSave>().Save(this.transform.position);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {

        }
    }
}
