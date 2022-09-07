using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "PlayerManager", menuName = "PlayerManager")]

public class PlayerManager : ScriptableObject
{
    [SerializeField] public player[] Players;
    private const string Prefix = "Player_";
    

    public void SelectPlayer(int playerIndex) => PlayerPrefs.SetInt("Player", playerIndex);
    public player GetSelectedPlayer()
    {
        int playerIndex = PlayerPrefs.GetInt("Player", 0);
        if(playerIndex >= 0 && playerIndex < Players.Length)
        {

            
            
               return Players[playerIndex];
            
                
              
               
            

        }
        else
        {
            return null;
        }
    }

    public void Unlock(int playerIndex) => PlayerPrefs.SetInt("Player" + playerIndex, 1);

    public bool IsUnlocked(int playerIndex) => PlayerPrefs.GetInt("Player" + playerIndex, 0) == 1;
}
