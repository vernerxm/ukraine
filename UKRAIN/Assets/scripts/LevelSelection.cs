using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelection : MonoBehaviour
{
    public Button[] lvlButtons;

    // Start is called before the first frame update
    void Start()
    {
        int levelAt = PlayerPrefs.GetInt("levelAt", 5); 

        for (int i = 0; i < lvlButtons.Length; i++)
        {
            if (i + 5 > levelAt)
                lvlButtons[i].interactable = false;
        }
    }

}






