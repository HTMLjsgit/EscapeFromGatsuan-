using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using DG.Tweening;
public class WallUpDown : SerializedMonoBehaviour
{
    public enum UpOrDown
    {
        UP,
        Down
    }
    public Transform TargetUpPosition;
    private float DefaultPositionY;
    public float Duration;
    public bool ActionEnd;
    public float NextWaitActionTime;
    private float NextWaitActionTimeNow;
    public UpOrDown up_or_down;
    // Start is called before the first frame update
    void Start()
    {
        DefaultPositionY = this.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (ActionEnd)
        {
            NextWaitActionTimeNow += Time.deltaTime;
            if(NextWaitActionTimeNow > NextWaitActionTime)
            {
                if (up_or_down == UpOrDown.UP)
                {
                    Down();
                }
                else
                {
                    Up();
                }
                NextWaitActionTimeNow = 0;
            }
        }

    }
    [Button]
    public void Up()
    {
        ActionEnd = false;
        up_or_down = UpOrDown.UP;
        this.transform.DOMoveY(TargetUpPosition.transform.position.y, Duration).SetLink(this.gameObject).SetEase(Ease.Linear).OnComplete(() => {
            ActionEnd = true;
        });
    }
    [Button]
    public void Down()
    {
        ActionEnd = false;
        up_or_down = UpOrDown.Down;
        this.transform.DOMoveY(DefaultPositionY, Duration).SetEase(Ease.Linear).OnComplete(() => {
            
            ActionEnd = true;
        });
    }
}
