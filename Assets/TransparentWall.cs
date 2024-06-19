using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class TransparentWall : MonoBehaviour
{
    public GameObject VirtualCamera;
    private GameObject Player;
    private PlayerController player_controller;
    private RaycastHit raycast_hit;
    private List<DOFadeMaterial> do_fade_materials = new List<DOFadeMaterial>();
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindWithTag("Player");
        player_controller = Player.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Physics.Raycast(this.transform.position, (player_controller.BodyPositionObj.transform.position - this.transform.position), out raycast_hit, 1000))
        {
            if(raycast_hit.collider.gameObject.tag == "Player")
            {
                if(do_fade_materials != null)
                {
                    foreach (DOFadeMaterial do_fade_material in do_fade_materials)
                    {
                        do_fade_material.DOFade(1);

                    }
                    do_fade_materials.Clear();
                }

            }
            else if(LayerMask.LayerToName(raycast_hit.collider.gameObject.layer) == "Object")
            {
                Debug.Log("Obj�ɓ������Ă��player�����܂���I");
                DOFadeMaterial do_fade_material;
                do_fade_material = raycast_hit.collider.gameObject.GetComponent<DOFadeMaterial>();
                if(do_fade_materials != null)
                {
                    if (!do_fade_materials.Contains(do_fade_material))
                    {
                        do_fade_materials.Add(do_fade_material);
                    }
                }
                else
                {
                    do_fade_materials.Add(do_fade_material);
                }
                if(do_fade_material != null) { 
                    do_fade_material.DOFade(0.3f);
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
        Gizmos.DrawRay(this.transform.position, (player_controller.BodyPositionObj.transform.position - this.transform.position).normalized * 1000);
    }
}