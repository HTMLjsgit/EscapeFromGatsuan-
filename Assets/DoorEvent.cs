using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using DG.Tweening;
using UnityEngine.Events;
public class DoorEvent : MonoBehaviour
{
    public float ToYRotation = 45;
    public UnityEvent ActionWhenOpenFunc;
    private GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    [Button]
    public void openDoor()
    {
        transform.DORotate(new Vector3(this.transform.rotation.eulerAngles.x, ToYRotation, this.transform.rotation.eulerAngles.z),1).SetLink(this.gameObject).OnComplete(() => {
            ActionWhenOpenFunc.Invoke();
        });
    }
    public void closeDoor()
    {

    }
    private void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<CharactorMovePermit>().Stop();
            openDoor();
        }
    }
}
