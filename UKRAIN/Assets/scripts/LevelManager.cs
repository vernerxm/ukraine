using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    private Player player;
    public Transform playerPos;
    public GameObject[] players;
    private void Awake()
    {
        player = Instantiate(players[PlayerPrefs.GetInt("Skins")],playerPos.position,Quaternion.identity).GetComponent<Player>();
    }
}
