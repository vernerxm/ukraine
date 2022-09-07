using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    
    
    [SerializeField] Text[] allCoinsUIText;
    #region SIngleton:Game
    public static Game instance;
    // Start is called before the first frame update
    void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    #endregion
    public int Coins;

    private void Start()
    {
        UpdateAllCoinsUIText();
    }
    
    public void UseCoins(int amount)
    {
        Coins -= amount;
        
    }
    public bool HasEnoughCoins(int amount)
    {
        return(Coins >= amount);

    }
    public void UpdateAllCoinsUIText()
    {
        for (int i = 0; i < allCoinsUIText.Length; i++)
        {
            allCoinsUIText[i].text = Coins.ToString();
        }
    }
    
}

