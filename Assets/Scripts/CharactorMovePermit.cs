using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class CharactorMovePermit : MonoBehaviour
{
    public UnityEvent charactor_move;
    public UnityEvent charactor_stop;
    public void Move()
    {
        charactor_move.Invoke();
    }
    public void Stop()
    {
        charactor_stop.Invoke();
    }
}
