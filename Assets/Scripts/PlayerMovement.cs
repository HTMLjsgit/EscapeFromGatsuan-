using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private GameObject GameController;
    private Rigidbody rigid;
    private PlayerInput player_input;
    private Vector2 Move;
    public float RunSpeed;
    public float CrouchSpeed;
    public bool MovePermit = true;
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
        anim.SetFloat("DirectionX", Move.x);
        anim.SetFloat("DirectionY", Move.y);
    }
    private void FixedUpdate()
    {
        if (MovePermit)
        {
            if (!Crouch)
            {
                rigid.velocity = (transform.forward * Move.y + transform.right * Move.x) * RunSpeed;
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
