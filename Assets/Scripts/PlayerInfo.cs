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

    //used for end of match stats
    public float aimPercentage = 0f;
    public float firedShots = 0f;
    public float landedShots = 0f;
   

    private PlayerLoot playerLoot;

	// Use this for initialization
	void Start () {
        playerLoot = GetComponent<PlayerLoot>();
    }

    void UpdatePercentage(){
        junkPercentage = playerLoot.JunkCount / (playerLoot.JunkCount + playerLoot.HealthCount) * 100;
        healthyPercentage =  playerLoot.HealthCount / (playerLoot.JunkCount + playerLoot.HealthCount) * 100;
        //Debug.Log("junk" + junkPercentage);
        //Debug.Log("health" + healthyPercentage);
    }
	
	// Update is called once per frame
	void Update () {
        UpdatePercentage();
	}

    public float GetDietPoints()
    {
        //if(diet == Diet.JunkFood) return 
        return diet == Diet.JunkFood ? playerLoot.JunkCount : playerLoot.HealthCount;
            //playerLoot.HealthCount
    }
}
