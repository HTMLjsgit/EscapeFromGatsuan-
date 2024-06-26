using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Transform PlayersEyePosition;
    private GameController game_controller;
    private AudioSource audio_source;
    public bool chased_by_enemies;
    public GameObject BodyPositionObj;
    // Start is called before the first frame update
    void Start()
    {
        audio_source = this.gameObject.GetComponent<AudioSource>();
        game_controller = GameObject.FindWithTag("GameController").GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void DOGameOver()
    {
        audio_source.Play();
        game_controller.GameOver();
    }
}
