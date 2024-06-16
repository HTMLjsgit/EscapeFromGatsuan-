using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public bool CursorFixed = true;
    private AudioSource audio_source;
    // Start is called before the first frame update
    void Start()
    {
        audio_source = this.gameObject.GetComponent<AudioSource>();
        SceneManager.sceneLoaded += OnSceneLoaded;
        CursorDOFixed(CursorFixed);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GameOver()
    {
        Invoke("SceneMoveToOver", 2f);
    }
    private void SceneMoveToOver()
    {
        SceneManager.LoadScene("GameOver");
    }
    private void CursorDOFixed(bool _fix)
    {
        if (_fix)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;

        }
    }
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("Scene Change" + scene.name);
        if(scene.name == "GameOver" || scene.name == "GameStart" || scene.name == "GameClear")
        {
            CursorDOFixed(false);
        }
        else
        {
            CursorDOFixed(true);
        }
    }
}
