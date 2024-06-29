using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using Sirenix.OdinInspector;
public class TransparentWall : SerializedMonoBehaviour
{
    public GameObject VirtualCamera;
    public List<string> TargetLayers;
    private GameObject Player;
    private PlayerController player_controller;
    private RaycastHit raycast_hit;
    public List<Animator> do_fade_animators = new List<Animator>();
    private int layer_only_mask;
    public string[] target_layers;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindWithTag("Player");
        player_controller = Player.GetComponent<PlayerController>();
        layer_only_mask = LayerMask.GetMask(target_layers);
    }

    // Update is called once per frame
    void Update()
    {

        if (Physics.Raycast(this.transform.position, (player_controller.BodyPositionObj.transform.position - this.transform.position), out raycast_hit, 100, layer_only_mask))
        {
            Debug.Log("ÉJÉÅÉâÇ©ÇÁîÚÇŒÇµÇƒìñÇΩÇ¡ÇƒÇ¢ÇÈï®ëÃ: " + raycast_hit.collider.gameObject);
            if(raycast_hit.collider.gameObject.tag == "Player")
            {
                if(do_fade_animators != null)
                {
                    foreach (Animator do_fade_animator in do_fade_animators)
                    {
                        if(do_fade_animator != null)
                        {
                            do_fade_animator.SetBool("Transparent_0point3", false);
                            do_fade_animator.SetBool("Transparent_0", false);
                        }

                    }
                    do_fade_animators.Clear();
                }
                else
                {
                    Debug.Log("do_fade_materialsÇ™nullÇ≈Ç∑ÅB playerÇÃÇ∆Ç±");
                }

            }
            else if(TargetLayers.Contains(LayerMask.LayerToName(raycast_hit.collider.gameObject.layer)))
            {

                Animator do_fade_anim;
                do_fade_anim = raycast_hit.collider.gameObject.GetComponent<Animator>();
                if(do_fade_animators != null)
                {
                    if (!do_fade_animators.Contains(do_fade_anim) && do_fade_anim != null)
                    {
                        do_fade_animators.Add(do_fade_anim);
                    }
                }
                else
                {
                    if(do_fade_anim != null)
                    {
                        do_fade_animators.Add(do_fade_anim);
                    }
                }
                if(raycast_hit.collider.gameObject.tag == "ObjectZero")
                {
                    if (do_fade_anim != null)
                    {
                        do_fade_anim.SetBool("Transparent_0", true);
                    }
                }
                else
                {
                    if (do_fade_anim != null)
                    {
                        Debug.Log("do_fade_material.DOFade(0.2f)");
                        do_fade_anim.SetBool("Transparent_0point3", true);
                    }
                    else
                    {
                        Debug.Log("DofadeeeeeeeeeeeeeeeDOFadematerialNUll");
                    }
                }


            }
        }
        else
        {

        }
    }
    private void OnDrawGizmos()
    {
        if(player_controller == null)
        {
            Player = GameObject.FindWithTag("Player");
            player_controller = Player.GetComponent<PlayerController>();
        }
        Gizmos.color = Color.blue;
        Gizmos.DrawRay(this.transform.position, (player_controller.BodyPositionObj.transform.position - this.transform.position).normalized * 10);
    }
}
