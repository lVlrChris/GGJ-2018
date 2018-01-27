using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLoot : MonoBehaviour {
    public float JunkCount, HealthCount;
    public List<string> LootedJunkFood = new List<string>();
    public List<string> LootedHealthyFood = new List<string>();
    public FoodSpawner foodSpawner;

	// Use this for initialization
	void Start () {
        foodSpawner = GameObject.Find("Spawner").GetComponent<FoodSpawner>();
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
            foodSpawner.SelectSpawnPoint();
        }           
        else if( collisionTag == "HealthyFood")
        {
            HealthCount++;
            LootedHealthyFood.Add(col.gameObject.name);
            Destroy(col.gameObject);
            foodSpawner.SelectSpawnPoint();

        }
    }
}
