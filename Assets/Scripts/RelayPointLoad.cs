using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class RelayPointLoad : MonoBehaviour
{
    private GameObject GameController;
    private RelayPointSave relay_point_save;
    private GameController game_controller;
    private bool StartNow;
    // Start is called before the first frame update
    void Start()
    {
        GameController = GameObject.FindWithTag("GameController");
        game_controller = GameController.GetComponent<GameController>();
        relay_point_save = GameController.GetComponent<RelayPointSave>();
        StartNow = true;
        game_controller.KeysWithPlaceName.Clear();
        if (relay_point_save.SavedPlayerPosition.magnitude != 0 )
        {
            //ÉçÅ[ÉhÇ∑ÇÈÇ∆Ç±ÇÎ
            this.transform.position = relay_point_save.SavedPlayerPosition;
            game_controller.KeysWithPlaceName = relay_point_save.KeysWithNameSavedOnSaved;
        }
        else
        {
            relay_point_save.AlreadySaved = false;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "RestPoint")
        {
            if (StartNow)
            {
                other.gameObject.GetComponent<RealyPoint>().start_in_player = true;
                StartNow = false;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "RestPoint")
        {

        }
    }
}
