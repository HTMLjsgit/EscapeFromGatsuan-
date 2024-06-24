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
                //�N���[�[�b�g�̒��ɂ�����
                if (!once_inside)
                {
                    //�O�ɏo���Ⴂ�܂��B
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
                    //�N���[�[�b�g�̊O�ɂ�����
                    if (!once_outside)
                    {
                        //���ɓ���܂��B
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
        Debug.Log("���ɓ���܂����I");
        audio_source.PlayOneShot(door_open_clip);
        inside_or_outside = InsideOrOutSide.Inside;
        PlayerPosSave = this.transform.position + (-this.transform.forward * 2);
        Player.transform.position = TeleportPosition.transform.position;
        player_rigid.isKinematic = true;
        player_move_permit.Stop();
    }
    public void GoOutsideFromCloset()
    {
        Debug.Log("�O�ɂł܂����I");
        audio_source.PlayOneShot(door_close_clip);
        inside_or_outside = InsideOrOutSide.Outside;
        Player.transform.position = PlayerPosSave;
        player_rigid.isKinematic = false;
        player_move_permit.Move();
    }
}
