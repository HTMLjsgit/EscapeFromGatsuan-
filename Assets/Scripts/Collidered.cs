using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class Collidered : MonoBehaviour
{
    public bool Collider;
    public List<string> Targets;
    public UnityEvent TriggerEnterEvents;
    public UnityEvent TriggerExitEvents;
    public bool once;
    private bool once_now;
    private void OnTriggerEnter(Collider other)
    {
        if (Targets.Contains(other.gameObject.tag) && once_now == false)
        {
            TriggerEnterEvents.Invoke();
            Collider = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (Targets.Contains(other.gameObject.tag) && once_now == false)
        {
            if (once)
            {
                once_now = true;
            }
            TriggerExitEvents.Invoke();
            Collider = false;
        }
    }
}
