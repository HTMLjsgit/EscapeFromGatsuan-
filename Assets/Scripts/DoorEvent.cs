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
    private float DefaultYRotation;
    public bool NeedKey = false;
    private CharactorMovePermit player_move_permit;
    private GameController game_controller;
    public FadeController canvas_fade_controller;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindWithTag("Player");
        player_move_permit = Player.GetComponent<CharactorMovePermit>();
        game_controller = GameObject.FindWithTag("GameController").GetComponent<GameController>();
        DefaultYRotation = this.transform.eulerAngles.y;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    [Button]
    public void openDoor()
    {
        player_move_permit.Stop();
        if (NeedKey == true)
        {
            //�����Ɍ����K�v�ł��Ƃ���UI��`��
            if (game_controller.KeysWithPlaceName.Contains(this.gameObject.name))
            {
                //���������Ă�����return���܂���
            }
            else
            {
                //���������Ă��Ȃ������献�������Ă܂����UI��\������Return;
                canvas_fade_controller.gameObject.SetActive(true);
                canvas_fade_controller.FadeIn();
                return;
            }
        }
        transform.DORotate(new Vector3(this.transform.rotation.eulerAngles.x, ToYRotation, this.transform.rotation.eulerAngles.z),1).SetLink(this.gameObject).OnComplete(() => {
            ActionWhenOpenFunc.Invoke();
        });
    }
    [Button]
    public void closeDoor()
    {
        transform.DORotate(new Vector3(this.transform.rotation.eulerAngles.x, DefaultYRotation, this.transform.rotation.eulerAngles.z), 1).SetLink(this.gameObject).OnComplete(() => {
            player_move_permit.Move();
            canvas_fade_controller.gameObject.SetActive(false);
        });
    }
    private void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            openDoor();
        }
    }
}
