using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
   public enum MoveMode
    {
        Run,
        Walk
    }
    private GameObject GameController;
    private Rigidbody rigid;
    private PlayerInput player_input;
    private Vector2 Move;
    public float RunSpeed;
    public float WalkSpped;
    public float CrouchSpeed;
    public bool MovePermit = true;
    public MoveMode move_mode;
    private Vector2 MousePosition;
    private Animator anim;
    private bool Crouch;
    private bool direction_change_once;
    private DirectionChangeFromCameraDIrection direction_change;
    // Start is called before the first frame update
    void Start()
    {
        GameController = GameObject.FindWithTag("GameController");
        player_input = GameController.GetComponent<PlayerInput>();
        rigid = this.gameObject.GetComponent<Rigidbody>();
        direction_change = this.gameObject.GetComponent<DirectionChangeFromCameraDIrection>();
        anim = this.gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Move = player_input.currentActionMap["Move"].ReadValue<Vector2>();
        if (player_input.currentActionMap["MoveModeChange"].triggered)
        {
            if(move_mode == MoveMode.Run)
            {
                move_mode = MoveMode.Walk;

            }
            else if(move_mode == MoveMode.Walk)
            {
                move_mode = MoveMode.Run;
            }

        }
        else
        {
        }
        if (player_input.currentActionMap["Crouch"].triggered)
        {

            if (!Crouch)
            {
                MovePermit = false;
                Crouch = true;
            }
            else
            {
                MovePermit = false;
                Crouch = false;
            }

        }

        anim.SetBool("Crouch", Crouch);
        if (Move.magnitude > 0)
        {
            direction_change.DirectionChange();
            //if (!direction_change_once)
            //{
            direction_change_once = true;
            //}
            anim.SetBool("Move", true);
        }
        else
        {
            direction_change_once = false;
            anim.SetBool("Move", false);
        }
        if(move_mode == MoveMode.Run)
        {
            anim.SetFloat("DirectionX", Move.x);
            anim.SetFloat("DirectionY", Move.y);
        }
        else if(move_mode == MoveMode.Walk)
        {
            anim.SetFloat("DirectionX", Move.x  / 2f);
            anim.SetFloat("DirectionY", Move.y / 2f);
        }

    }
    private void FixedUpdate()
    {
        if (MovePermit)
        {
            if (!Crouch)
            {
                if(MoveMode.Run == move_mode)
                {
                    rigid.velocity = (transform.forward * Move.y + transform.right * Move.x) * RunSpeed;
                }
                else if(MoveMode.Walk == move_mode)
                {
                    rigid.velocity = (transform.forward * Move.y + transform.right * Move.x) * WalkSpped;
                }
            }
            else
            {
                rigid.velocity = (transform.forward * Move.y + transform.right * Move.x) * CrouchSpeed;
            }
        }
        else
        {

        }
    }
    public void MovePermitChange(bool _mode)
    {
        MovePermit = _mode;
    }
}
