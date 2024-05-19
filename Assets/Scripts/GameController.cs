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
        if (CursorFixed)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GameOver()
    {
        //audio_source.Play();
        Invoke("SceneMoveToOver", 1f);
    }
    private void SceneMoveToOver()
    {
        SceneManager.LoadScene("GameOver");
    }
}
