using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawner : MonoBehaviour {
    public Transform JunkFood;
    public Transform HealthyFood;
    public List<GameObject> spawnPoints = new List<GameObject>();

    public GameObject[] JunkFoods;
    public GameObject[] HealthyFoods;

	// Use this for initialization
	void Start () {
		
	}

    Vector3 SelectSpawnPoint(){
        int randomIndex = Random.Range(0, spawnPoints.Count);
        return spawnPoints[randomIndex].transform.position;
    }

    void SpawnNewFood(){
        Transform food = (JunkFoods.Length > HealthyFoods.Length) ? HealthyFood : JunkFood;

        Instantiate(food, SelectSpawnPoint(), Quaternion.identity);
        UpdateFoodLists();
    }

    void UpdateFoodLists(){
        JunkFoods = GameObject.FindGameObjectsWithTag("JunkFood");
        HealthyFoods = GameObject.FindGameObjectsWithTag("HealthyFood");
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("space")){
            Debug.Log(spawnPoints.Count);
            SpawnNewFood();
        }
	}
}
