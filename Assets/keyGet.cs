using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keyGet : MonoBehaviour
{
    private GameController game_controller;
    private bool col;
    private bool col_once;
    public string KeyName;
    public List<AudioSource> audio_sources;
    public FadeController fade_controller;
    private CharactorMovePermit player_move_permit;
    // Start is called before the first frame update
    void Start()
    {
        game_controller = GameObject.FindWithTag("GameController").GetComponent<GameController>();
        player_move_permit = GameObject.FindWithTag("Player").GetComponent<CharactorMovePermit>();
    }

    // Update is called once per frame
    void Update()
    {
        if (col)
        {
            if (!game_controller.KeysWithPlaceName.Contains(KeyName))
            {
                if (!col_once)
                {
                    audio_sources.ForEach((s) =>
                    {
                        s.Play();
                    });
                    PlayerStop();
                    fade_controller.FadeIn();
                    game_controller.KeysWithPlaceName.Add(KeyName);
                    col_once = true;
                }
            }
        }
        else
        {
            col_once = false;
        }
    }
    public void PlayerStop()
    {
        player_move_permit.Stop();
    }
    public void PlayerMove()
    {
        player_move_permit.Move();
    }
    private void OnCollisionStay(Collision other)
    {
        if(other.gameObject.tag == "Player")
        {
            col = true;
        }
    }
    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            col = false;
        }
    }
}
