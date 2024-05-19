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
    private void OnTriggerEnter(Collider other)
    {
        if (Targets.Contains(other.gameObject.tag))
        {
            TriggerEnterEvents.Invoke();
            Collider = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (Targets.Contains(other.gameObject.tag))
        {
            TriggerExitEvents.Invoke();
            Collider = false;
        }
    }
}
