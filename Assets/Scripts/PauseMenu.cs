using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!GameIsPaused)
            {
                Pause();
            }
            else
            {
                Resume();
            }

        }
	}

    public void Resume()
    {

              AudioListener.pause = false;
              GameIsPaused = false;
            if (!dialogueManager.dialogueActive)
                Time.timeScale = 1f;
            pauseMenuUI.SetActive(false);
    }

    public void resetBtn()
    {
        dialogueManager.dialogueActive = false;
        Time.timeScale = 1f;
    }

    
    

    void Pause()
    {
        AudioListener.pause = true;
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0.0f;
        GameIsPaused = true;
    }
    
}
