using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using DG.Tweening;
using UnityEngine.Events;

public class UIPositionMove : MonoBehaviour
{
    private Vector3 DefaultPosition;
    public Transform TargetTransform;

    // Start is called before the first frame update
    void Start()
    {
        DefaultPosition = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    [Button]
    public void Move(bool move, UnityEvent complete_events,float invoke_events_when_completed_time, float duration = 0.4f)
    {
        if (move)
        {
            this.transform.DOMove(TargetTransform.transform.position, duration).SetLink(this.gameObject).OnComplete(() => {
            });
        }
        else
        {
            this.transform.DOMove(DefaultPosition, duration).SetLink(this.gameObject).OnComplete(() => {
            });
        }
    }
    private IEnumerator moved_completed_event(float time, UnityEvent events)
    {
        yield return new WaitForSeconds(time);
        events.Invoke();
    }
}
