using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class PositionMove : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void MoveY(float target_position)
    {
        this.transform.DOMoveY(target_position, 0);
    }
}
