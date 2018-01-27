using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInfo : MonoBehaviour {

    public int playerIndex;
    public new string name;
    public Diet diet;
    public float junkPercentage = 0f;
    public float healthyPercentage = 0f;

    public Text scoreText;

    private PlayerLoot playerLoot;

	// Use this for initialization
	void Start () {
        playerLoot = GetComponent<PlayerLoot>();
	}

    void UpdatePercentage(){
        junkPercentage = playerLoot.JunkCount / (playerLoot.JunkCount + playerLoot.HealthCount) * 100;
        healthyPercentage =  playerLoot.HealthCount / (playerLoot.JunkCount + playerLoot.HealthCount) * 100;
        Debug.Log("junk" + junkPercentage);
        Debug.Log("health" + healthyPercentage);
        scoreText.text = "Junk: " + junkPercentage + "% " + "Healthy: " + healthyPercentage + "%"; 
    }
	
	// Update is called once per frame
	void Update () {
        UpdatePercentage();
	}
}
