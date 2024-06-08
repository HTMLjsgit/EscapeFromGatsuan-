using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMove : MonoBehaviour
{
    private RelayPointSave relay_point_save;
    public bool NextStageByDoor;
    // Start is called before the first frame update
    void Start()
    {
        relay_point_save = GameObject.FindWithTag("GameController").GetComponent<RelayPointSave>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void scene_move(string SceneName)
    {
        if (NextStageByDoor)
        {
            relay_point_save.SavedPlayerPosition = Vector3.zero;
        }
        SceneManager.LoadScene(SceneName);
    }
}
