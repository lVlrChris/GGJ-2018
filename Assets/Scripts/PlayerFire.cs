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
        
        if(Application.platform == RuntimePlatform.WindowsPlayer || Application.platform == RuntimePlatform.WindowsEditor)
        {
            float rotX = Input.GetAxis("RotXP" + playerInfo.playerIndex);
            float rotY = Input.GetAxis("RotYP" + playerInfo.playerIndex);

            float heading = Mathf.Atan2(rotX, rotY);
            if ((rotX != 0) || rotY != 0)
            {
                transform.rotation = Quaternion.Euler(0, heading * Mathf.Rad2Deg * -1, 0);

            }
            if (Input.GetAxisRaw("FireP" + playerInfo.playerIndex) > 0 && canShoot)
            {
                StartCoroutine(FireFood());
                canShoot = false;
            }
        }else if(Application.platform == RuntimePlatform.OSXEditor || Application.platform == RuntimePlatform.OSXPlayer)
        {
            float rotX = Input.GetAxis("RotOSXXP" + playerInfo.playerIndex);
            float rotY = Input.GetAxis("RotOSXYP" + playerInfo.playerIndex);

            float heading = Mathf.Atan2(rotX, rotY);
            if ((rotX != 0) || rotY != 0)
            {
                transform.rotation = Quaternion.Euler(0, heading * Mathf.Rad2Deg * -1, 0);

            }
            if (Input.GetAxisRaw("FireOSXP" + playerInfo.playerIndex) > 0 && canShoot)
            {
                StartCoroutine(FireFood());
                canShoot = false;
            }
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
                            Instantiate(banana, spawnPoint.position, spawnPoint.transform.rotation);
                            break;
                        case "Apple":
                            print("Fire APPLE!");
                            Instantiate(apple, spawnPoint.position, spawnPoint.transform.rotation);
                            break;
                        case "Grapes":
                            Instantiate(grapes, spawnPoint.position, spawnPoint.transform.rotation);
                            print("Fire GRAPES!");
                            break;
                    }
                    playerLoot.LootedHealthyFood.RemoveAt(playerLoot.LootedHealthyFood.Count - 1);
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
                            print("Fire HOTDOG!");
                            break;
                        case "Pizza":
                            print("Fire PIZZA!");
                            break;
                        case "Drumstick":
                            print("Fire DRUMSTICK!");
                            break;
                    }
                    playerLoot.LootedJunkFood.RemoveAt(playerLoot.LootedJunkFood.Count - 1);
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
