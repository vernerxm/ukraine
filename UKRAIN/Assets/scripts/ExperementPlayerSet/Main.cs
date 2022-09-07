using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
   
    public Transform playerPos;
    public GameObject[] players;
    private Player player;


    private void Awake()
    {
        player =Instantiate(players[PlayerPrefs.GetInt("Player")],playerPos.position,Quaternion.identity).GetComponent<Player>();
    }

    
}

