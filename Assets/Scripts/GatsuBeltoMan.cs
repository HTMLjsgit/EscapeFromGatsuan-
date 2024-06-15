using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class GatsuBeltoMan : MonoBehaviour
{
    [HideInInspector]
    public BeltoAreaController belto_area_controller;
    public int BeltoCountNow = 0;
    private Rigidbody rigid;
    public Vector3 VectorDiffToNextArea;
    private Animator anim;
    private float ToNextPointDistance;
    public float speed;
    PlayerInput player_input;
    [HideInInspector]
    public BeltoAreaController.BeltoManStatus target_belto_man_status;
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
        if(belto_area_controller == null || target_belto_man_status == null)
        {
            return;
        }
        //Createされたときに個々のBeltoCountNowを増やしたい。
        BeltoCountNow = target_belto_man_status.index;
        if (belto_area_controller.BeltoColliderAreaPositions.Count  <= BeltoCountNow)
        {
            belto_area_controller.BeltoManLists.Remove(this.gameObject.transform);
            Destroy(this.gameObject);
        }
        else
        {
            target_belto_man_status.PointPos = belto_area_controller.BeltoColliderAreaPositions[BeltoCountNow];
            VectorDiffToNextArea = (target_belto_man_status.PointPos.position - this.transform.position).normalized;
            ToNextPointDistance = Vector3.Distance(this.transform.position, belto_area_controller.BeltoColliderAreaPositions[BeltoCountNow].transform.position);
            this.transform.forward = VectorDiffToNextArea;
        }
        if(Mathf.Round(ToNextPointDistance) == 0)
        {
            //次のエリアとの距離が０になったとき
            target_belto_man_status.AlreadyPassedToPoint = true;
        }
        else
        {
            target_belto_man_status.AlreadyPassedToPoint = false;
        }
        if(anim != null)
        {
            anim.SetBool("Walk", !target_belto_man_status.AlreadyPassedToPoint);
        }

    }
    void FixedUpdate()
    {
        if (belto_area_controller == null)
        {
            return;
        }
        if (target_belto_man_status.AlreadyPassedToPoint)
        {
            rigid.velocity = Vector3.zero;

        }
        else
        {
            rigid.velocity = VectorDiffToNextArea * speed;
        }

    }
}
