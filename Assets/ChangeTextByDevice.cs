using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
public class ChangeTextByDevice : SerializedMonoBehaviour
{
    public Dictionary<string, string> change_texts_status = new Dictionary<string, string>() { { "keyboard", "Space" } };
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
