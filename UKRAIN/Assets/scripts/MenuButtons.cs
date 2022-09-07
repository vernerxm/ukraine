using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene(3);
    }
    public void Shop()
    {
        SceneManager.LoadScene("Shop");
        
    }
    public void Inventory()
    {
        SceneManager.LoadScene(2);
    }
    public void Menu()
    {
        SceneManager.LoadScene(0);
    }
    public void LevelsMap1()
    {
        SceneManager.LoadScene(4);
    }
    
}
