using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class PositionChange : SerializedMonoBehaviour
{
    [Header("右が移動させたいObjectのTransform 左がtargetの移動させるPosition")]
    public Dictionary<Transform, Transform> MyPositionToTargetMovePosition;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Move(Transform obj)
    {
        MyPositionToTargetMovePosition[obj].transform.position = obj.transform.position;
    }

}
