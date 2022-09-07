using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InvertoryManager : MonoBehaviour
{
    [SerializeField] private Image selectedSkin;
    
    [SerializeField] private PlayerManager playerManager;
    [SerializeField] private int playerIndex;

    // Update is called once per frame
    void Update()
    {
        if (playerManager.IsUnlocked(playerIndex))
        {
            selectedSkin.sprite = playerManager.GetSelectedPlayer().sprite;
        }
        



    }
}
