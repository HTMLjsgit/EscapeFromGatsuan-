using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using DG.Tweening;
public class SettingController : MonoBehaviour
{
    private CinemachineVirtualCamera cinemachine_virtualcamera;
    private CinemachinePOV cinemachine_pov;
    public Camera MainCamera;
    private PlayerInput player_input;
    public GameObject GameController;
    private GameController game_controller_script;
    public bool Opened = false;
    private bool menu_open_once = false;
    private bool menu_close_once = false;
    private CanvasGroup canvas_group;
    public bool MenuPermitOpen;
    public Text MouseSenseNumberTextUI;
    public GameObject UIs;
    public float defaultMouseSense = 0.2f;
    private float MouseSensNow;
    // Start is called before the first frame update
    void Start()
    {
        MainCamera = Camera.main;
        cinemachine_virtualcamera = GameObject.FindWithTag("VirtualCamera").GetComponent<CinemachineVirtualCamera>();
        cinemachine_pov = cinemachine_virtualcamera.GetCinemachineComponent<CinemachinePOV>();
        player_input = GameController.GetComponent<PlayerInput>();
        canvas_group = this.gameObject.GetComponent<CanvasGroup>();
        game_controller_script = GameController.GetComponent<GameController>();
        Debug.Log("MouseSens指定: " + defaultMouseSense);
        MouseSens(defaultMouseSense);
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    // Update is called once per frame
    void Update()
    {
        if (player_input.currentActionMap["menu_open"].triggered && MenuPermitOpen)
        {
            if (Opened)
            {
                //既に開いていたら
                menu_close_once = false;
                if (!menu_open_once)
                {
                    //閉じる動作
                    canvas_group.DOFade(0, 0.3f).SetLink(this.gameObject).OnComplete(() => {
                        UIs.SetActive(false);
                    });
                    game_controller_script.CursorDOFixed(true);
                    menu_open_once = true;
                }
                Opened = false;
            }
            else
            {
                //閉じていたら
                menu_open_once = false;
                if (!menu_close_once)
                {
                    //開く動作
                    canvas_group.DOFade(1, 0.3f).SetLink(this.gameObject);
                    game_controller_script.CursorDOFixed(false);
                    UIs.SetActive(true);
                    menu_close_once = true;
                }
                Opened = true;
            }
        }
        if (Opened)
        {
            //開いていてかつ開く許可がなかったら消します。メニューを
            if (!MenuPermitOpen)
            {
                UIs.SetActive(false);
                menu_close_once = false;
                Opened = false;
            }
        }
    }
    public void MouseSens(float value)
    {
        cinemachine_pov.m_HorizontalAxis.m_MaxSpeed = value;
        cinemachine_pov.m_VerticalAxis.m_MaxSpeed = value;
        MouseSenseNumberTextUI.text = value.ToString();
        MouseSensNow = value;
    }
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if(scene.name == "GameOver" || scene.name == "GameClear")
        {
            MenuPermitOpen = false;
        }
        else
        {
            if(cinemachine_virtualcamera == null)
            {
                cinemachine_virtualcamera = GameObject.FindWithTag("VirtualCamera").GetComponent<CinemachineVirtualCamera>();
            }
            if (cinemachine_pov == null)
            {
                cinemachine_pov = cinemachine_virtualcamera.GetCinemachineComponent<CinemachinePOV>();
            }
            Debug.Log("Startのはずなのに呼ばれる？");
            if(MouseSensNow != 0)
            {
                this.MouseSens(MouseSensNow);
            }
            else
            {
                this.MouseSens(defaultMouseSense);
            }
            MenuPermitOpen = true;
        }
    }
}
