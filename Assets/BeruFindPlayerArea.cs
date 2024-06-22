using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeruFindPlayerArea : MonoBehaviour
{
    public BeruAreaController beru_area_controller;
    public float ChasedByEnemyDistance = 5;
    private GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            beru_area_controller.col_mode = BeruAreaController.ColMode.PlayerInto;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            beru_area_controller.col_mode = BeruAreaController.ColMode.PlayerOutside;
        }
    }
}
