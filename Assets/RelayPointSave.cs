using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class RelayPointSave : MonoBehaviour
{
    public Vector3 SavedPlayerPosition;
    public string BeforeStageNameForMoment;
    public string BeforeStageName;
    public string NowStageName;
    private string BeforeStageNameSave;
    private GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        SceneManager.sceneLoaded += SceneLoaded;
        SceneManager.sceneUnloaded += UnLoaded;
        if(BeforeStageName == "")
        {
            BeforeStageName = SceneManager.GetActiveScene().name;
        }
        NowStageName = SceneManager.GetActiveScene().name;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Save(Vector3 PlayerPos)
    {
        this.SavedPlayerPosition = PlayerPos;
    }
    private void UnLoaded(Scene scene)
    {
        Debug.Log(SceneManager.GetActiveScene().name);
        if (scene.name.Contains("Scene") && BeforeStageName != scene.name && NowStageName != BeforeStageName)
        {
            BeforeStageName = scene.name;
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
