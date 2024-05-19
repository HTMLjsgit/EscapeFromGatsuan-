using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionChangeFromCameraDIrection : MonoBehaviour
{
    public GameObject TargetCamera;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void DirectionChange()
    {
        this.transform.localRotation = Quaternion.Euler(0,TargetCamera.transform.rotation.eulerAngles.y,0);
    }
}
