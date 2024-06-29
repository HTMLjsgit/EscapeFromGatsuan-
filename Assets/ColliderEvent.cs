using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class ColliderEvent : MonoBehaviour
{
    public UnityEvent collidered_enter_event;
    public UnityEvent collidered_exit_event;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            collidered_enter_event.Invoke();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            collidered_exit_event.Invoke();
        }
    }
    private void OnCollisionStay(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            collidered_enter_event.Invoke();
        }
    }
    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            collidered_exit_event.Invoke();
        }
    }
}
