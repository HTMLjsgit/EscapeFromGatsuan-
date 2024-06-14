using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GatsuBeltoMan : MonoBehaviour
{
    [HideInInspector]
    public BeltoAreaController belto_area_controller;
    public int BeltoCountNow = 0;
    private Rigidbody rigid;
    public Vector3 VectorDiffToNextArea;
    private Animator anim;
    private float ToNextPointDistance;
    public enum GatsuManOrTransParent
    {
        GatsuMan,
        TransparentMan
    }
    public GatsuManOrTransParent gatsuman_or_transparentman;
    // Start is called before the first frame update
    void Start()
    {
        rigid = this.gameObject.GetComponent<Rigidbody>();
        anim = this.gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        if(belto_area_controller == null)
        {
            return;
        }
        //Createされたときに個々のBeltoCountNowを増やしたいね。
        BeltoCountNow = belto_area_controller.BeltoManLists.IndexOf(this.gameObject.transform);
        if (belto_area_controller.BeltoColliderAreaPositions.Count  <= BeltoCountNow)
        {
            belto_area_controller.BeltoManLists.Remove(this.gameObject.transform);
            Destroy(this.gameObject);
        }
        else
        {
            VectorDiffToNextArea = (belto_area_controller.BeltoColliderAreaPositions[BeltoCountNow].position - this.transform.position).normalized;
            ToNextPointDistance = Vector3.Distance(this.transform.position, belto_area_controller.BeltoColliderAreaPositions[BeltoCountNow].transform.position);
        }
        if(Mathf.Round(ToNextPointDistance) == 0)
        {
            //次のエリアとの距離が０になったとき
        }

    }
    void FixedUpdate()
    {
        if (belto_area_controller == null)
        {
            return;
        }
        if (belto_area_controller.FirstBeltoAreaAlreadyPassed)
        {
            rigid.velocity = Vector3.zero;
            if(anim != null)
            {
                anim.SetBool("Move", false);
            }
        }
        else
        {
            rigid.velocity = VectorDiffToNextArea * 10;
            if (anim != null)
            {
                anim.SetBool("Move", true);
            }
        }

    }
}
