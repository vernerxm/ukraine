using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    // Start is called before the first frame update
     private AudioSource FinishSound;
    
     
    private bool LevelCompleted = false;
    public int nextSceneLoad;
    private void Start()
    {
        FinishSound =  GetComponent<AudioSource>();
        nextSceneLoad = SceneManager.GetActiveScene().buildIndex + 1;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player" )&& !LevelCompleted)
        {
            SceneManager.LoadScene(nextSceneLoad);
            FinishSound.Play();
            LevelCompleted = true;
            if (nextSceneLoad > PlayerPrefs.GetInt("levelAt"))
            {
                PlayerPrefs.SetInt("levelAt",nextSceneLoad);
            }
            
            
            
        }
    }
    

}
