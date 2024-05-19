using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayIfInDIstance : MonoBehaviour
{
    private AudioSource audio_source;
    private bool once;
    public float PlayDistance;
    private float PlayerToDistance;
    private GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        audio_source = this.gameObject.GetComponent<AudioSource>();
        if (audio_source.clip != null)
        {
            Player = GameObject.FindWithTag("Player");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(audio_source.clip != null)
        {
            PlayerToDistance = Vector3.Distance(Player.transform.position, this.transform.position);
            if (PlayerToDistance <= PlayDistance)
            {
                if (!once)
                {
                    audio_source.Play();
                    once = true;
                }
            }
            else
            {
                audio_source.Stop();
                once = false;
            }
        }

    }
}
