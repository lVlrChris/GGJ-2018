using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLoot : MonoBehaviour {
    public int JunkCount, HealthCount;
    public List<string> LootedJunkFood = new List<string>();
    public List<string> LootedHealthyFood = new List<string>();


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
            LootedJunkFood.Add(col.gameObject.name);
            Destroy(col.gameObject);
        }           
        else if( collisionTag == "HealthyFood")
        {
            HealthCount++;
            LootedHealthyFood.Add(col.gameObject.name);
            Destroy(col.gameObject);
        }
    }
}
