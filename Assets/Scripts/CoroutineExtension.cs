using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public static class CoroutineExtension
{
    public static IEnumerator CoroutineAction(UnityAction unity_action, float wait_time)
    {
        yield return new WaitForSeconds(wait_time);
        unity_action.Invoke();
    }
}
