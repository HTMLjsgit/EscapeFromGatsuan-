using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RealyPoint : MonoBehaviour
{
    private RelayPointSave relay_point_save;
    public UIPositionMove ui_position_move;
    private UnityEvent un_ac = new UnityEvent();
    public bool start_in_player;
    // Start is called before the first frame update
    void Start()
    {
        relay_point_save = GameObject.FindWithTag("GameController").GetComponent<RelayPointSave>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player" && !start_in_player)
        {
            if (!relay_point_save.AlreadySaved)
            {
                ui_position_move.Move(true, un_ac, 1);
            }
            Debug.Log("------Saveeeeeeeeee--------");
            relay_point_save.Save(this.transform.position);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            ui_position_move.Move(false, un_ac,1);
            start_in_player = false;
        }
    }
}
