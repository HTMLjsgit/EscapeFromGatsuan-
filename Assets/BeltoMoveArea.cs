using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeltoMoveArea : MonoBehaviour
{
    public List<GameObject> ObjectsInArea;
    private BeltoAreaController belto_area_controller;
    // Start is called before the first frame update
    void Start()
    {
        //beltoAreaを取得してBeltoAreaControllerを取得しておく
        belto_area_controller = this.transform.parent.parent.gameObject.GetComponent<BeltoAreaController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(ObjectsInArea.Count >= 2)
        {
            if (ObjectsInArea.Contains(this.gameObject))
            {
                //Areaの中に２つ以上オブジェクト君がいてさらにプレイヤーもいたら
                belto_area_controller.BeltoAreaError = true;
            }
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Player" || other.gameObject.tag == "Enemy")
        {
            if (!ObjectsInArea.Contains(other.gameObject))
            {
                ObjectsInArea.Add(other.gameObject);
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "Enemy")
        {
            if (ObjectsInArea.Contains(other.gameObject))
            {
                ObjectsInArea.Remove(other.gameObject);
            }
        }
    }
}
