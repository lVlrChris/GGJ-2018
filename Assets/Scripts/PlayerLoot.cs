using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLoot : MonoBehaviour {
    public float JunkCount, HealthCount;
    public List<string> LootedJunkFood = new List<string>();
    public List<string> LootedHealthyFood = new List<string>();
    public FoodSpawner foodSpawner;

    private AudioSource audioSource;
    private float voiceVolume = 0.4f;
    public AudioClip eatNice;
    public AudioClip eatDirty;


    private PlayerInfo player;

	// Use this for initialization
	void Start () {
        foodSpawner = GameObject.Find("Spawner").GetComponent<FoodSpawner>();
        audioSource = GetComponent<AudioSource>();
        player = GetComponent<PlayerInfo>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter(Collision col)
    {
        var collisionTag = col.gameObject.tag;

        if (collisionTag == "JunkFood"){
            JunkCount++;
            LootedJunkFood.Add(col.gameObject.name);
            Destroy(col.transform.parent.gameObject);
            if (player.diet == Diet.JunkFood) { audioSource.PlayOneShot(eatNice, voiceVolume); }
            else { audioSource.PlayOneShot(eatDirty, voiceVolume); }
           // foodSpawner.SelectSpawnPoint();
        }           
        else if( collisionTag == "HealthyFood")
        {
            HealthCount++;
            LootedHealthyFood.Add(col.gameObject.name);
            Destroy(col.transform.parent.gameObject);
            if (player.diet == Diet.Healthy) { audioSource.PlayOneShot(eatNice, voiceVolume); }
            else { audioSource.PlayOneShot(eatDirty, voiceVolume); }
            //foodSpawner.SelectSpawnPoint();

        }
    }
}
