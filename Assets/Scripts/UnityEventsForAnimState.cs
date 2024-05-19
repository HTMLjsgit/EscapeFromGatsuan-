using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Sirenix.OdinInspector;
public class UnityEventsForAnimState : SerializedMonoBehaviour
{

    [ShowInInspector]
    public Dictionary<string,UnityEvent> AnimEnterEvent;
    [Space]
    [Space]
    [Space]
    [Space]
    public Dictionary<string, UnityEvent> AnimExitEvent;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
