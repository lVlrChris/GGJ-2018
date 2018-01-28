using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerHit : MonoBehaviour {
    public  PlayerLoot playerLoot;
    public PlayerInfo playerInfo;

    private Material material;
	// Use this for initialization
	void Start () {
        playerLoot = GetComponent<PlayerLoot>();
        playerInfo = GetComponent<PlayerInfo>();
        material = transform.GetChild(0).GetChild(1).GetComponent<SkinnedMeshRenderer>().material;
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
            StartCoroutine(OnHitShader());
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraShake>().ShakeCamera();
            GetComponent<Rigidbody>().AddForce((transform.position - col.transform.position).normalized * 15, ForceMode.Impulse);
            GameObject otherPlayer = GameObject.FindGameObjectsWithTag("Player").First(go => go.GetComponent<PlayerInfo>().playerIndex != GetComponent<PlayerInfo>().playerIndex);
            otherPlayer.GetComponent<PlayerInfo>().landedShots++;
            Debug.Log(gameObject.name + " collided with " + col.gameObject.name);
            Destroy(col.gameObject);
        }
    }

    IEnumerator OnHitShader()
    {

        material.SetFloat("_OnHit", 1);
        yield return new WaitForSeconds(0.1f);
        material.SetFloat("_OnHit", 0);
    }
}
