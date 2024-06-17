using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageSelect : MonoBehaviour
{
    private SceneMove scene_move;
    // Start is called before the first frame update
    void Start()
    {
        scene_move = this.gameObject.GetComponent<SceneMove>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StageChange(int stage_index)
    {
        string StageName = "Scene" + (stage_index + 1).ToString();
        scene_move.NextStageNameBySelect = StageName;
    }
}
