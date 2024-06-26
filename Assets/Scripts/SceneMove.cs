using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Sirenix.OdinInspector;
public class SceneMove : SerializedMonoBehaviour
{
    private RelayPointSave relay_point_save;
    public bool SceneMoveFromStart;
    [HideIf("SceneMoveFromStart")]
    public bool NextStageByDoor;
    [ShowIf("SceneMoveFromStart")]
    public string NextStageNameBySelect = "Scene1";

    // Start is called before the first frame update
    void Start()
    {
        if (!SceneMoveFromStart)
        {
            relay_point_save = GameObject.FindWithTag("GameController").GetComponent<RelayPointSave>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void scene_move(string SceneName)
    {
        if (NextStageByDoor && !SceneMoveFromStart)
        {
            relay_point_save.SaveDataRemove();
        }
        SceneManager.LoadScene(SceneName);
    }
    public void scene_move_from_start()
    {
        SceneManager.LoadScene(NextStageNameBySelect);
    }
}
