using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class GameMouseCursor : MonoBehaviour
{
    private GameObject GameController;
    private PlayerInput player_input;
    private float MouseX;
    private float MouseY;
    private float XRotation;
    private float YRotation;
    public float speed = 4;
    public bool XRotationMode;
    public bool YRotationMode;
    private GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        GameController = GameObject.FindWithTag("GameController");
        player_input = GameController.GetComponent<PlayerInput>();
        Player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        MouseX = Input.GetAxis("Mouse X");
        MouseY = Input.GetAxis("Mouse Y");
        if (XRotationMode)
        {
            XRotation -= MouseY;
            XRotation = Mathf.Clamp(XRotation, -25f, 90f);
        }
        else
        {
            XRotation = 0;
        }
        if (YRotationMode)
        {
            YRotation += MouseX;
        }
        else
        {
            YRotation = 0;
        }
        this.transform.localRotation = Quaternion.Euler(XRotation, YRotation, 0f);
    }
    private void FixedUpdate()
    {

        //YRotation = Mathf.Clamp(YRotation, 0, -90);
        //this.transform.RotateAround(Player.transform.position, new Vector3(YRotation, XRotation, 0),0);
    }
}
