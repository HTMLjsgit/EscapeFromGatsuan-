using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using Sirenix.OdinInspector;
using UnityEngine.Events;
public class FadeController : SerializedMonoBehaviour
{
    public bool CanvasGroup;
    public float duration = 1;
    private CanvasGroup canvas_group;
    public UnityEvent FadeInCompleteEvent;
    public UnityEvent FadeOutCompleteEvent;
    public bool StartFadeIn;
    public bool StartFadeOut;
    public float EventInvokeTimeWait;
    private Tween tween;
    public bool AlreadyEnded;
    private float WaitEventInvokeTimeNow;
    private bool Waited;
    public bool FadeInCompleted;
    public bool FadeOutCompleted;
    private bool FadeInStart;
    private bool FadeOutStart;
    private bool FadeInStartOnce;
    // Start is called before the first frame update
    void Start()
    {
        canvas_group = this.gameObject.GetComponent<CanvasGroup>();
        WaitEventInvokeTimeNow = EventInvokeTimeWait;
        if (StartFadeIn)
        {
            FadeIn();
        }else if (StartFadeOut)
        {
            FadeOut();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (FadeInStart && !AlreadyEnded)
        {
            Debug.Log("FadeinStartttttt");
            if (FadeInStartOnce)
            {
                FadeInAction();
                FadeInStartOnce = false;
                FadeInStart = false;
            }
            FadeInStartOnce = true;
        }

        if (FadeInCompleted)
        {
            WaitEventInvokeTimeNow -= Time.deltaTime;
            if(WaitEventInvokeTimeNow <= 0)
            {
                FadeInCompleteEvent.Invoke();
                WaitEventInvokeTimeNow = EventInvokeTimeWait;
                FadeInCompleted = false;
            }
        }
        if (FadeOutCompleted)
        {
            WaitEventInvokeTimeNow -= Time.deltaTime;
            if(WaitEventInvokeTimeNow <= 0)
            {
                WaitEventInvokeTimeNow = EventInvokeTimeWait;
                FadeOutCompleteEvent.Invoke();
                FadeOutCompleted = false;
            }
        }
    }
    private void OnDisable()
    {
        tween.Kill();
        FadeOutCompleted = false;
        FadeInStart = false;
        FadeInCompleted = false;
        FadeInStartOnce = false;
        StartFadeIn = false;
    }
    public void FadeIn()
    {
        this.gameObject.SetActive(true);
        FadeInStartOnce = false;
        FadeInStart = true;
        FadeOutStart = false;

    }
    public void FadeOut()
    {
        FadeInStart = false;
        FadeOutStart = true;
        if (CanvasGroup && !AlreadyEnded)
        {
            FadeOutAction();
        }
    }
    private void FadeInAction()
    {
        Debug.Log("FadeInAction");
        tween = canvas_group.DOFade(1, duration).SetLink(this.gameObject).SetEase(Ease.Linear).OnComplete(() => {
            //StartCoroutine(WaitInvoke(FadeInCompleteEvent));
            FadeInCompleted = true;
        });
    }
    private void FadeOutAction()
    {
        tween = canvas_group.DOFade(0, duration).SetLink(this.gameObject).SetEase(Ease.Linear).OnComplete(() => {
            FadeOutCompleted = true;
        });
    }
    public void Kill()
    {
        tween.Kill();
        AlreadyEnded = true;
    }
    IEnumerator WaitInvoke(UnityEvent events) {
        yield return new WaitForSeconds(EventInvokeTimeWait);
        events.Invoke();
    }
}
