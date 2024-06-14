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
    // Start is called before the first frame update
    void Start()
    {
        canvas_group = this.gameObject.GetComponent<CanvasGroup>();
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
        
    }
    public void FadeIn()
    {
        if (CanvasGroup && !AlreadyEnded)
        {
            Debug.Log("FadeInnnnnnnnnnnSkipppppp");
            tween = canvas_group.DOFade(1,duration).SetLink(this.gameObject).SetEase(Ease.Linear).OnComplete(() => {
                StartCoroutine(WaitInvoke(FadeInCompleteEvent));
            });
        }
    }
    public void FadeOut()
    {
        if (CanvasGroup && !AlreadyEnded)
        {
            tween = canvas_group.DOFade(0, duration).SetLink(this.gameObject).SetEase(Ease.Linear).OnComplete(() => {
                StartCoroutine(WaitInvoke(FadeOutCompleteEvent));
            });
        }
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
