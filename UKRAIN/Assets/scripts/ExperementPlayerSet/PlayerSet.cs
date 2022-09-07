using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSet : MonoBehaviour
{
     [SerializeField] private PlayerManager playerManager;
    [SerializeField] private int playerIndex;
    public void SetPlayer(int index)
    {

        if (playerManager.IsUnlocked(playerIndex) )
        {
            PlayerPrefs.SetInt("Player", index);
        }
        else
        {
            Debug.Log("Not money");
        }
    }
}
