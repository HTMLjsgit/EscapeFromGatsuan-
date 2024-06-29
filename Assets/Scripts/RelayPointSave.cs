using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Sirenix.OdinInspector;
public class RelayPointSave : SerializedMonoBehaviour
{
    public Vector3 SavedPlayerPosition;
    public string BeforeStageNameForMoment;
    public List<string> VisitStageHistories;
    public List<string> KeysWithNameSavedOnSaved;
    public string NowStageName;
    public bool AlreadySaved;
    private string BeforeStageNameSave;
    private GameObject Player;
    private GameController game_controller;
    public Dictionary<GameObject, bool> already_saved_with_places = new Dictionary<GameObject, bool>(); 
    // Start is called before the first frame update
    void Start()
    {
        SceneManager.sceneLoaded += SceneLoaded;
        SceneManager.sceneUnloaded += UnLoaded;
        NowStageName = SceneManager.GetActiveScene().name;
        game_controller = this.gameObject.GetComponent<GameController>();
        GameObject[] objs = GameObject.FindGameObjectsWithTag("RestPoint");
        Debug.Log("objs--------: " + objs.Length);
        already_saved_with_places.Clear();
        foreach (GameObject obj in objs)
        {
            if (!already_saved_with_places.ContainsKey(obj))
            {
                already_saved_with_places.Add(obj, false);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Save(Vector3 PlayerPos, GameObject rest_point)
    {

        AlreadySaved = true;
        this.SavedPlayerPosition = PlayerPos;
        already_saved_with_places[rest_point] = true;
        this.KeysWithNameSavedOnSaved = new List<string>(game_controller.KeysWithPlaceName);

        Debug.Log("RelayPointSave:Save()");
    }
    public void SaveDataRemove()
    {
        Debug.Log("SaveDataRemove!?!??");
        this.SavedPlayerPosition = Vector3.zero;
        KeysWithNameSavedOnSaved.Clear();
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
        already_saved_with_places.Clear();
        if (scene.name.Contains("Scene")) {

           GameObject[] objs = GameObject.FindGameObjectsWithTag("RestPoint");
            Debug.Log("objs--------: " + objs.Length);
            foreach(GameObject obj in objs)
            {
                if (!already_saved_with_places.ContainsKey(obj))
                {
                    already_saved_with_places.Add(obj, false);
                }
            }
            NowStageName = SceneManager.GetActiveScene().name;

        }
    }
}
