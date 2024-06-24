using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReviveBeforeStage : MonoBehaviour
{
    private RelayPointSave relay_point_save;
    private SceneMove scene_move;
    // Start is called before the first frame update
    void Start()
    {
        relay_point_save = GameObject.FindWithTag("GameController").GetComponent<RelayPointSave>();
        scene_move = this.gameObject.GetComponent<SceneMove>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ReviveStage()
    {
        scene_move.scene_move(relay_point_save.NowStageName);
    }
}
