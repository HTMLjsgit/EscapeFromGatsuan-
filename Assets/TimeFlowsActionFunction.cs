using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Sirenix.OdinInspector;
public class TimeFlowsActionFunction : SerializedMonoBehaviour
{
    public class EventsManager
    {
        public UnityEvent events;
        public bool events_triggered;
    }
    public Dictionary<int, EventsManager> managers;
    public float wait_time;
    private float time_now;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time_now += Time.deltaTime;
        if(time_now > wait_time)
        {
            //managers.Invoke();
            time_now = 0;
        }
    }
}
