using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerShopController : MonoBehaviour
{
    [SerializeField] private Image selectedPlayer;
    [SerializeField] private Text coinsText;
    [SerializeField] private PlayerManager playerManager;

    // Update is called once per frame
    void Update()
    {
        coinsText.text = "Coins:" + PlayerPrefs.GetInt("Coins");
        selectedPlayer.sprite = playerManager.GetSelectedPlayer().sprite;

    }
}