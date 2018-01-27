using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour {

    private PlayerInfo playerInfo;
    private PlayerLoot playerLoot;
    public bool canShoot = true;
    public float fireCooldown;

    public GameObject hotdog;
    public GameObject pizza;
    public GameObject drumstick;
    public GameObject apple;
    public GameObject grapes;
    public GameObject banana;

    public Transform spawnPoint;

    void Start () {
        playerLoot = GetComponent<PlayerLoot>();
        playerInfo = GetComponent<PlayerInfo>();	
	}
	
	void Update () {

        float rotX = Input.GetAxis("RotXP" + playerInfo.playerIndex);
        float rotY = Input.GetAxis("RotYP" + playerInfo.playerIndex);

        float heading = Mathf.Atan2(rotX, rotY);
        if((rotX != 0) || rotY != 0)
        {
            transform.rotation = Quaternion.Euler(0, heading * Mathf.Rad2Deg * -1,0);
            
        }

        if (Input.GetAxisRaw("FireP"+playerInfo.playerIndex) > 0 && canShoot)
        {
            StartCoroutine(FireFood());
            canShoot = false;
        }
    }
    
    
    IEnumerator FireFood()
    {
        switch (playerInfo.diet)
        {
            case Diet.Healthy:
                if(playerLoot.LootedHealthyFood.Count > 0)
                {
                    switch (playerLoot.LootedHealthyFood[playerLoot.LootedHealthyFood.Count-1])
                    {
                        case "Banana":
                            print("Fire BANANA!");
                            break;
                        case "Apple":
                            print("Fire APPLE!");
                            Instantiate(apple, spawnPoint.position, spawnPoint.transform.rotation);
                            playerLoot.LootedHealthyFood.RemoveAt(playerLoot.LootedHealthyFood.Count - 1);
                            break;
                        case "Grapes":
                            print("Fire GRAPES!");
                            break;
                    }
                    GetComponent<PlayerInfo>().firedShots++;
                    GetComponent<PlayerLoot>().HealthCount--;
                }else{
                    print("You dont have any healthy");
                }
                break;
            case Diet.JunkFood:
                if (playerLoot.LootedJunkFood.Count > 0)
                {
                    switch (playerLoot.LootedJunkFood[playerLoot.LootedJunkFood.Count - 1])
                    {
                        case "Hotdog":
                            Instantiate(hotdog, spawnPoint.position, spawnPoint.transform.rotation);
                            playerLoot.LootedJunkFood.RemoveAt(playerLoot.LootedJunkFood.Count - 1);
                            print("Fire HOTDOG!");
                            break;
                        case "Pizza":
                            print("Fire PIZZA!");
                            break;
                        case "Drumstick":
                            print("Fire DRUMSTICK!");
                            break;
                    }
                    GetComponent<PlayerInfo>().firedShots++;
                    GetComponent<PlayerLoot>().JunkCount--;
                }
                else
                {
                    print("You dont have any snacks");
                }
                break;
            default:
                break;
        }
        yield return new WaitForSeconds(fireCooldown);
        canShoot = true;
    }

}
