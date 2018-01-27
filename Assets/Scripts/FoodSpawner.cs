using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class FoodSpawner : MonoBehaviour {
    public Transform[] JunkFood;
    public Transform[] HealthyFood;
    public List<GameObject> spawnPoints = new List<GameObject>();
    private List<GameObject> freeSpawnPoints;
    public int maxFoodSpawns;
    private int spawnedFood;


    public List<GameObject> JunkFoods = new List<GameObject>();
    public List<GameObject> HealthyFoods = new List<GameObject>();

	// Use this for initialization
	void Start () {
        maxFoodSpawns = spawnPoints.Count - 1;
        SelectSpawnPoint();
	}

    public void SelectSpawnPoint(){
        JunkFoods.RemoveAll(item => item == null); 
        HealthyFoods.RemoveAll(item => item == null); 
        while ((JunkFoods.Count + HealthyFoods.Count) < maxFoodSpawns)
        {
            int randomIndex = Random.Range(0, spawnPoints.Count);
            //Debug.Log("INDEX" + randomIndex);
            GameObject spawnPoint = spawnPoints[randomIndex];
            //     Debug.Log(CheckIfSpawnIsFree(spawnPoint));
            /*
            foreach (var spwnpnt in spawnPoints)
            {
                if (CheckIfSpawnIsFree(spwnpnt.transform.position))
                {
                    //Debug.Log("free: " + spwnpnt);
                    SpawnNewFood(spwnpnt);
                    return;
                }
                else {
                    Debug.Log("not free");
                }
            }*/
            if (CheckIfSpawnIsFree(spawnPoint.transform.position))
            {
                SpawnNewFood(spawnPoint);
            }
            else
            {
                SelectSpawnPoint();
            }
        }
 
    }
    
    void SpawnNewFood( GameObject spawnPoint){
        //nog random
        int healthyIndex = Random.Range(0, HealthyFood.Length);
        int junkIndex = Random.Range(0, JunkFood.Length);

        Transform food = (JunkFoods.Count > HealthyFoods.Count) ? HealthyFood[healthyIndex] : JunkFood[junkIndex];
        Transform go = Instantiate(food, spawnPoint.transform.position, Quaternion.identity, spawnPoint.transform) as Transform;
        go.name = go.name.Split('(')[0];
        UpdateFoodLists();
    }

    bool CheckIfSpawnIsFree(Vector3 spawnPoint){
        
        var spawnPointColliders = Physics.OverlapSphere(spawnPoint, 1);
        //Debug.Log("COLLLL" + spawnPointColliders.Length);
        return !(spawnPointColliders.Length > 1);
    }


    void UpdateFoodLists(){
        JunkFoods = GameObject.FindGameObjectsWithTag("JunkFood").ToList();;
        HealthyFoods = GameObject.FindGameObjectsWithTag("HealthyFood").ToList();
    }
	
	// Update is called once per frame
	void Update () {
        /*
        if (Input.GetKeyDown("space")){
            Debug.Log(spawnPoints.Count);
            SelectSpawnPoint();
        }
        */
	}
}
