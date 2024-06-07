using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class RelayPointLoad : MonoBehaviour
{
    private GameObject GameController;
    private RelayPointSave relay_point_save;
    // Start is called before the first frame update
    void Start()
    {
        GameController = GameObject.FindWithTag("GameController");
        relay_point_save = GameController.GetComponent<RelayPointSave>();
        //if(relay_point_save.BeforeStageName == SceneManager.GetActiveScene().name 
        //   && relay_point_save.SavedPlayerPosition.magnitude != 0)
        //{
        //    this.transform.position = relay_point_save.SavedPlayerPosition;
        //}
    }

    // Update is called once per frame
    void Update()
    {

    }
}
