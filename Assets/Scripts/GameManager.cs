using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public GameObject fastFoodPlayer;
    public GameObject healthyPlayer;

    public Transform spawnPosP1;
    public Transform spawnPosP2;

    void Start () {
        DontDestroyOnLoad(gameObject);
	}
	
	
    public void StartGame()
    {
        SceneManager.LoadScene("NielsScene");
        SpawnPlayers();
    }

    private void SpawnPlayers()
    {
        GameObject p1 = Instantiate(fastFoodPlayer, spawnPosP1.position, spawnPosP1.rotation) as GameObject;
        p1.GetComponent<PlayerInfo>().playerIndex = 1;
        GameObject p2 = Instantiate(healthyPlayer, spawnPosP2.position, spawnPosP2.rotation) as GameObject;
        p2.GetComponent<PlayerInfo>().playerIndex = 2;
    }

    public void EndGame()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
