using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Playables;
using Sirenix.OdinInspector;
using DG.Tweening;
public class PlayAbleStartEndEvents : SerializedMonoBehaviour
{
    public UnityEvent StartEvent;
    public UnityEvent EndEvent;

    private PlayableDirector playable_director;
    private bool once = false;
    public bool PlayOnAwake;
    public FadeController fade_controller;
    public FadeController skip_fade_controller;
    // Start is called before the first frame update
    void Awake()
    {
        playable_director = this.gameObject.GetComponent<PlayableDirector>();
        if (PlayOnAwake)
        {
            this.Play();
        }
        AlreadyEnded();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("playable_directior_time: " + playable_director.time);
        Debug.Log("playable_directior_duration:" + playable_director.duration);
        if(playable_director.time >= playable_director.duration - 0.03f)
        {
            Debug.Log("TimeèIóπÇµÇΩÇÊÇ®");
            //TimelineÇÃçƒê∂Ç™èIóπ
            if (!once)
            {
                EndEvent.Invoke();
                once = true;
            }
        }
        else
        {
            once = false;
        }
    }
    public void Play()
    {
        playable_director.Play();
        StartEvent.Invoke();
    }
    [Button]
    public void AlreadyEnded()
    {
        StartCoroutine(aaa());
        fade_controller.Kill();
    }
    private IEnumerator aaa()
    {
        yield return null;
        skip_fade_controller.FadeIn();
    }
    public void AlreadyEndedBackend()
    {
        Play();
        EndEvent.Invoke();
        playable_director.playableGraph.GetRootPlayable(0).SetSpeed(Mathf.Infinity);
    }
}
