﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHit : MonoBehaviour {
    public  PlayerLoot playerLoot;
    public PlayerInfo playerInfo;

	// Use this for initialization
	void Start () {
        playerLoot = GetComponent<PlayerLoot>();
        playerInfo = GetComponent<PlayerInfo>();           
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Projectile")
        {
            switch(playerInfo.diet){
                case Diet.Healthy:
                    playerLoot.LootedJunkFood.Add(col.gameObject.gameObject.name);
                    playerLoot.JunkCount++;
                    break;
                case Diet.JunkFood:
                    playerLoot.LootedHealthyFood.Add(col.gameObject.gameObject.name);
                    playerLoot.HealthCount++;
                    break;
            }
            Debug.Log(gameObject.name + " collided with " + col.gameObject.name);
            Destroy(col.gameObject);
        }
    }
}
