using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class RelayPointSave : MonoBehaviour
{
    public Vector3 SavedPlayerPosition;
    public string BeforeStageNameForMoment;
    public List<string> VisitStageHistories;
    public string NowStageName;
    public bool AlreadySaved;
    private string BeforeStageNameSave;
    private GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        SceneManager.sceneLoaded += SceneLoaded;
        SceneManager.sceneUnloaded += UnLoaded;
        NowStageName = SceneManager.GetActiveScene().name;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Save(Vector3 PlayerPos)
    {
        AlreadySaved = true;
        this.SavedPlayerPosition = PlayerPos;

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
