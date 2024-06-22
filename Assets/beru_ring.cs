using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Sirenix.OdinInspector;
public class beru_ring : SerializedMonoBehaviour
{
    private AudioSource audio_source;
    public float RingStrength;
    private Tween tween;
    private Quaternion DefaultRotation;
    // Start is called before the first frame update
    void Start()
    {
        audio_source = this.gameObject.GetComponent<AudioSource>();
        DefaultRotation = this.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
    }

    [Button]
    public void Ring()
    {
        this.transform.rotation = Quaternion.Euler(-160, 0, 0);
        audio_source.Play();
        tween = this.transform.DORotate(new Vector3(10, 0, 0), RingStrength).SetLink(this.gameObject).SetEase(Ease.Linear).SetLoops(-1, LoopType.Yoyo);
    }
    public void StopRing()
    {
        this.transform.rotation = DefaultRotation;
        audio_source.Stop();
        tween.Kill();
    }
}
