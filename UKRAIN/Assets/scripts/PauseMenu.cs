using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPaused =  false;
     [SerializeField]        public GameObject PauseUI;

   
    // Update is called once per frame

    public void PAUSE()
    {
        if (gameIsPaused)
        {
            Resume();
        }
        else
        {
            Pause();
        }
    }
    

    public void Resume()
    {
        PauseUI.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false ;
    }
    void Pause()
    {
        
        PauseUI.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
        
        
       
    }
    public void LevelsMap1()
    {
        SceneManager.LoadScene(4);
        Resume();
    }
    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +0);
        Time.timeScale = 1f;
        gameIsPaused = false;
    }
}
