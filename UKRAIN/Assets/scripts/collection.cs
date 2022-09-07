using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class collection : MonoBehaviour
{
    public int coin;
     private Text coinsText;
    [SerializeField] private AudioSource CollectSound;
    private void Awake()
    {
        if (!PlayerPrefs.HasKey("Coins"))
        {
            PlayerPrefs.SetInt("Coins", 0);
        }
    }
    public void Start()
    {
        coinsText = GameObject.FindGameObjectWithTag("CoinText").GetComponent<Text>();
        coin = PlayerPrefs.GetInt("Coins");
        coinsText.text = "HRN:" + coin.ToString();
        


    }
    
   
    
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("COINS"))
        {
            coin++;
            coinsText.text = "HRN:" + coin.ToString();

            CollectSound.Play();
            Destroy(collision.gameObject);
            PlayerPrefs.SetInt("Coins", coin);


        }
    }
}
