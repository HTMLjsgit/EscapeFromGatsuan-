using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Sirenix.OdinInspector;
[ExecuteInEditMode]
public class FixedPosition : SerializedMonoBehaviour
{
    private Vector3 DefaultPosition;
    public bool OnEditorFixed;
    // Start is called before the first frame update
    void Start()
    {
        DefaultPosition = this.transform.position;
    }
    
    // Update is called once per frame
    void Update()
    {
        if (Application.isPlaying)
        {
            this.transform.position = DefaultPosition;
        }

        if(!Application.isPlaying && OnEditorFixed)
        {
            this.transform.position = DefaultPosition;
        }
    }
    [Button]
    public void DefaultPositionSet()
    {
        DefaultPosition = this.transform.position;
    }
}
