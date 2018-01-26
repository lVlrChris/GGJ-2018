using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawner : MonoBehaviour {
    public Transform frikandel;
    public List<GameObject> spawnPoints = new List<GameObject>();
	// Use this for initialization
	void Start () {
		
	}

    Vector3 SelectSpawnPoint(){
        int randomIndex = Random.Range(0, spawnPoints.Count);
        return spawnPoints[randomIndex].transform.position;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("space")){
            Debug.Log(spawnPoints.Count);
            Instantiate(frikandel, SelectSpawnPoint(), Quaternion.identity);
        }
	}
}
