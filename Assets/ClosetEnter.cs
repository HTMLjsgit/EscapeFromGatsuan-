using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class ClosetEnter : MonoBehaviour
{
    private PlayerInput player_input;
    public enum InsideOrOutSide
    {
        Inside,
        Outside
    }
    public InsideOrOutSide inside_or_outside;
    public Transform TeleportPosition;
    private GameObject Player;
    private Vector3 PlayerPosSave;
    private CharactorMovePermit player_move_permit;
    private bool col;
    private bool once_inside;
    private bool once_outside;
    private Rigidbody player_rigid;
    private AudioSource audio_source;
    private PlayerController player_controller;
    public AudioClip door_open_clip;
    public AudioClip door_close_clip;

    // Start is called before the first frame update
    void Start()
    {
        player_input = GameObject.FindWithTag("GameController").GetComponent<PlayerInput>();
        Player = GameObject.FindWithTag("Player");
        player_move_permit = Player.GetComponent<CharactorMovePermit>();
        player_rigid = Player.GetComponent<Rigidbody>();
        audio_source = this.gameObject.GetComponent<AudioSource>();
        player_controller = Player.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player_controller.chased_by_enemies)
        {
            return;
        }
        if(inside_or_outside == InsideOrOutSide.Inside){
            if (player_input.currentActionMap["ClosetAction"].triggered)
            {
                //クローゼットの中にいたら
                if (!once_inside)
                {
                    //外に出ちゃいます。
                    GoOutsideFromCloset();
                    once_inside = true;
                }
                once_outside = false;
            }
        }

        if (col)
        {
            if (player_input.currentActionMap["ClosetAction"].triggered)
            {
                
                if(inside_or_outside == InsideOrOutSide.Outside)
                {
                    //クローゼットの外にいたら
                    if (!once_outside)
                    {
                        //中に入ります。
                        EnterIntoCloset();
                        once_outside = true;
                    }
                    once_inside = false;
                }
            }
        }

    }
    private void OnCollisionStay(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            col = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            col = false;
        }
    }
    public void EnterIntoCloset()
    {
        Debug.Log("中に入りました！");
        audio_source.PlayOneShot(door_open_clip);
        inside_or_outside = InsideOrOutSide.Inside;
        PlayerPosSave = this.transform.position + (-this.transform.forward * 2);
        Player.transform.position = TeleportPosition.transform.position;
        player_rigid.isKinematic = true;
        player_move_permit.Stop();
    }
    public void GoOutsideFromCloset()
    {
        Debug.Log("外にでました！");
        audio_source.PlayOneShot(door_close_clip);
        inside_or_outside = InsideOrOutSide.Outside;
        Player.transform.position = PlayerPosSave;
        player_rigid.isKinematic = false;
        player_move_permit.Move();
    }
}
