using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerShopItem : MonoBehaviour
{

    [SerializeField] public PlayerManager playerManager;
    [SerializeField] private int playerIndex;
    [SerializeField] private Button buyButton;
    [SerializeField] private Text costText;
    [SerializeField] Animator noCoinsAnim;

    private player player;
    void Start()
    {
        player = playerManager.Players[playerIndex];
        GetComponent<Image>().sprite = player.sprite;
        
        if (playerManager.IsUnlocked(playerIndex))
        {
            buyButton.gameObject.SetActive(false);
        }
        else
        {
            buyButton.gameObject.SetActive(true);
            costText.text = player.cost.ToString();
        }
    }

    public void OnPlayerPressed()
    {
        if (playerManager.IsUnlocked(playerIndex))
        {
           playerManager.SelectPlayer(playerIndex);
        }
    }
    public void OnBuyButtonPressed()
    {
        int coins = PlayerPrefs.GetInt("Coins", 0);


        if (coins >= player.cost && !playerManager.IsUnlocked(playerIndex))
        {
            PlayerPrefs.SetInt("Coins", coins - player.cost);
            playerManager.Unlock(playerIndex);
            buyButton.gameObject.SetActive(false);
            playerManager.SelectPlayer(playerIndex);
        }
        else
        {
            noCoinsAnim.SetTrigger("NoCoins");
            Debug.Log("Not money");
        }
    }
}
