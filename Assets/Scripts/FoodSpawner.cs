using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawner : MonoBehaviour {
    public Transform JunkFood;
    public Transform[] HealthyFood;
    public List<GameObject> spawnPoints = new List<GameObject>();
    private List<GameObject> freeSpawnPoints; 



    public GameObject[] JunkFoods;
    public GameObject[] HealthyFoods;

	// Use this for initialization
	void Start () {
        freeSpawnPoints = new List<GameObject>(spawnPoints);
        SelectSpawnPoint();
	}

    public void SelectSpawnPoint(){
        int randomIndex = Random.Range(0, spawnPoints.Count);
        Debug.Log("INDEX" + randomIndex);
   //     Vector3 spawnPoint =  spawnPoints[randomIndex].transform.position;
   //     Debug.Log(CheckIfSpawnIsFree(spawnPoint));

        foreach (var spwnpnt in spawnPoints)
        {
            if (CheckIfSpawnIsFree(spwnpnt.transform.position))
            {
                Debug.Log("free: " + spwnpnt);
                SpawnNewFood(spwnpnt);
                return;
            }
            else {
                Debug.Log("not free");
            }
        }
 
    }


    void SpawnNewFood( GameObject spawnPoint){
        //nog random
        Transform food = (JunkFoods.Length > HealthyFoods.Length) ? HealthyFood[0] : JunkFood;
        Transform go = Instantiate(food, spawnPoint.transform.position, Quaternion.identity) as Transform;
        go.name = go.name.Split('(')[0];
        UpdateFoodLists();
    }

    bool CheckIfSpawnIsFree(Vector3 spawnPoint){
        
        var spawnPointColliders = Physics.OverlapSphere(spawnPoint, 1);
        Debug.Log("COLLLL" + spawnPointColliders.Length);
        return !(spawnPointColliders.Length > 2);
    }


    void UpdateFoodLists(){
        JunkFoods = GameObject.FindGameObjectsWithTag("JunkFood");
        HealthyFoods = GameObject.FindGameObjectsWithTag("HealthyFood");
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("space")){
            Debug.Log(spawnPoints.Count);
            SelectSpawnPoint();
        }
	}
}
