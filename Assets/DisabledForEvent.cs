using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class DisabledForEvent : MonoBehaviour
{
    public UnityEvent DisabledEvents;
    public UnityEvent EnabledEvents;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Disable()
    {
        DisabledEvents.Invoke();
    }
    public void Enable()
    {
        EnabledEvents.Invoke();
    }
}
