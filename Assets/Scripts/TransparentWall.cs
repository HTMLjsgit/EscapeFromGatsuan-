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
    public List<DOFadeMaterial> do_fade_materials = new List<DOFadeMaterial>();
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
        if(Physics.Raycast(this.transform.position, (player_controller.BodyPositionObj.transform.position - this.transform.position), out raycast_hit, 100, layer_only_mask))
        {
            Debug.Log("ÉJÉÅÉâÇ©ÇÁîÚÇŒÇµÇƒìñÇΩÇ¡ÇƒÇ¢ÇÈï®ëÃ: " + raycast_hit.collider.gameObject);
            if(raycast_hit.collider.gameObject.tag == "Player")
            {
                if(do_fade_materials != null)
                {
                    foreach (DOFadeMaterial do_fade_material in do_fade_materials)
                    {
                        Debug.Log("do_fade_materiallll: " + do_fade_material);
                        if(do_fade_material != null)
                        {
                            do_fade_material.DOFade(1);
                        }

                    }
                    do_fade_materials.Clear();
                }

            }
            else if(TargetLayers.Contains(LayerMask.LayerToName(raycast_hit.collider.gameObject.layer)))
            {

                DOFadeMaterial do_fade_material;
                do_fade_material = raycast_hit.collider.gameObject.GetComponent<DOFadeMaterial>();
                if(do_fade_materials != null)
                {
                    if (!do_fade_materials.Contains(do_fade_material) && do_fade_material != null)
                    {
                        do_fade_materials.Add(do_fade_material);
                    }
                }
                else
                {
                    if(do_fade_material != null)
                    {
                        do_fade_materials.Add(do_fade_material);
                    }
                }
                if(raycast_hit.collider.gameObject.tag == "ObjectZero")
                {
                    if (do_fade_material != null)
                    {
                        do_fade_material.DOFade(0f);
                    }
                }
                else
                {
                    if (do_fade_material != null)
                    {
                        do_fade_material.DOFade(0.2f);
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
