﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLoot : MonoBehaviour {
    public int JunkCount, HealthCount;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter(Collision col)
    {
        var collisionTag = col.gameObject.tag;
        Debug.Log(collisionTag);
        if (collisionTag == "JunkFood"){
            JunkCount++;
            Destroy(col.gameObject);
        }           
        else if( collisionTag == "HealthyFood")
        {
            HealthCount++;
            Destroy(col.gameObject);
        }
    }
}
