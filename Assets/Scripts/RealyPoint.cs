using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RealyPoint : MonoBehaviour
{
    private RelayPointSave relay_point_save;
    public FadeController rest_ui_fade_controller;
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
            if (!relay_point_save.already_saved_with_places[this.gameObject])
            {
                rest_ui_fade_controller.FadeIn();
            }
            else
            {
            }
            Debug.Log("------Saveeeeeeeeee--------");
            relay_point_save.Save(this.transform.position, this.gameObject);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            rest_ui_fade_controller.FadeOut();
            start_in_player = false;
        }
    }
}
