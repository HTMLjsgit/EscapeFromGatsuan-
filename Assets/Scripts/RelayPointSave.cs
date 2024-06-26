using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class RelayPointSave : MonoBehaviour
{
    public Vector3 SavedPlayerPosition;
    public string BeforeStageNameForMoment;
    public List<string> VisitStageHistories;
    public List<string> KeysWithNameSaved;
    public string NowStageName;
    public bool AlreadySaved;
    private string BeforeStageNameSave;
    private GameObject Player;
    private GameController game_controller;
    // Start is called before the first frame update
    void Start()
    {
        SceneManager.sceneLoaded += SceneLoaded;
        SceneManager.sceneUnloaded += UnLoaded;
        NowStageName = SceneManager.GetActiveScene().name;
        game_controller = this.gameObject.GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Save(Vector3 PlayerPos)
    {
        AlreadySaved = true;
        this.SavedPlayerPosition = PlayerPos;
        KeysWithNameSaved = game_controller.KeysWithPlaceName;
        

    }
    public void SaveDataRemove()
    {
        this.SavedPlayerPosition = Vector3.zero;
        KeysWithNameSaved.Clear();
    }
    private void UnLoaded(Scene scene)
    {
        Debug.Log(SceneManager.GetActiveScene().name);
        if (scene.name.Contains("Scene"))
        {
            if (!VisitStageHistories.Contains(scene.name))
            {
                VisitStageHistories.Add(scene.name);
            }
        }
    }
    private void SceneLoaded(Scene scene,LoadSceneMode mode)
    {
        if (scene.name.Contains("Scene"))
        {

            NowStageName = SceneManager.GetActiveScene().name;
        }
    }
}
