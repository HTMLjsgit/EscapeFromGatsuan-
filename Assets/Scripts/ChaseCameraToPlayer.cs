using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseCameraToPlayer : MonoBehaviour
{
    public GameObject Player;
    private Vector3 DefaultPosition;
    // Start is called before the first frame update
    void Start()
    {
        DefaultPosition = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = Vector3.Slerp(this.transform.position, Player.transform.position + DefaultPosition, 1f);
    }
}
