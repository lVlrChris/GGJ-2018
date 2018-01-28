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
    public GameObject nope;

    public Transform aimingArrow;
    public float arrowFadeSpeed;
    private Material material;
    public Transform spawnPoint;

    private AudioSource audioSource;
    public AudioClip fireBlank, fire;
    private float voiceVolume= 0.3f;


    void Start () {
        playerLoot = GetComponent<PlayerLoot>();
        playerInfo = GetComponent<PlayerInfo>();

        material = aimingArrow.GetComponent<SpriteRenderer>().material;
        audioSource = GetComponent<AudioSource>();
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
                float alpha = Mathf.Lerp(material.color.a, 1f, arrowFadeSpeed * Time.deltaTime);
                material.SetColor("_Color", new Color(material.color.r, material.color.g, material.color.b, alpha));
            }
            else
            {
                float alpha = Mathf.Lerp(material.color.a, 0f, arrowFadeSpeed * Time.deltaTime);
                material.SetColor("_Color", new Color(material.color.r, material.color.g, material.color.b, alpha));

            }
            if (Input.GetAxisRaw("FireP" + playerInfo.playerIndex) > 0.2f && canShoot)
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
                float alpha = Mathf.Lerp(material.color.a, 1f, arrowFadeSpeed * Time.deltaTime);
                material.SetColor("_Color", new Color(material.color.r, material.color.g, material.color.b, alpha));

            }
            else
            {
                float alpha = Mathf.Lerp(material.color.a, 0f, arrowFadeSpeed * Time.deltaTime);
                material.SetColor("_Color", new Color(material.color.r, material.color.g, material.color.b, alpha));

            }
            if (Input.GetAxisRaw("FireOSXP" + playerInfo.playerIndex) > 0.2f && canShoot)
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
                            Instantiate(banana, new Vector3(spawnPoint.position.x, spawnPoint.position.y + banana.transform.position.y,spawnPoint.position.z), spawnPoint.transform.rotation);
                            break;
                        case "Apple":
                            print("Fire APPLE!");
                            Instantiate(apple, new Vector3(spawnPoint.position.x, spawnPoint.position.y + apple.transform.position.y, spawnPoint.position.z), spawnPoint.transform.rotation);
                            break;
                        case "Grapes":
                            Instantiate(grapes, new Vector3(spawnPoint.position.x, spawnPoint.position.y + grapes.transform.position.y, spawnPoint.position.z), spawnPoint.transform.rotation);
                            print("Fire GRAPES!");
                            break;
                    }
                    audioSource.PlayOneShot(fire, voiceVolume);

                    playerLoot.LootedHealthyFood.RemoveAt(playerLoot.LootedHealthyFood.Count - 1);
                    GetComponent<PlayerInfo>().firedShots++;
                    GetComponent<PlayerLoot>().HealthCount--;
                }else
                {
                    audioSource.PlayOneShot(fireBlank,voiceVolume);
                    Instantiate(nope, spawnPoint.transform.position, spawnPoint.transform.rotation, transform);
                    print("You dont have any healthy");
                }
                break;
            case Diet.JunkFood:
                if (playerLoot.LootedJunkFood.Count > 0)
                {
                    switch (playerLoot.LootedJunkFood[playerLoot.LootedJunkFood.Count - 1])
                    {
                        case "Hotdog":
                            Instantiate(hotdog, new Vector3(spawnPoint.position.x, spawnPoint.position.y + hotdog.transform.position.y, spawnPoint.position.z), spawnPoint.transform.rotation);
                            print("Fire HOTDOG!");
                            break;
                        case "Pizza":
                            Instantiate(pizza, new Vector3(spawnPoint.position.x, spawnPoint.position.y + pizza.transform.position.y, spawnPoint.position.z), spawnPoint.transform.rotation);
                            print("Fire PIZZA!");
                            break;
                        case "DrumStick":
                            Instantiate(drumstick, new Vector3(spawnPoint.position.x, spawnPoint.position.y + drumstick.transform.position.y, spawnPoint.position.z), spawnPoint.transform.rotation);

                            print("Fire DRUMSTICK!");
                            break;
                    }
                    playerLoot.LootedJunkFood.RemoveAt(playerLoot.LootedJunkFood.Count - 1);
                    GetComponent<PlayerInfo>().firedShots++;
                    GetComponent<PlayerLoot>().JunkCount--;
                }
                else
                {
                    Instantiate(nope, spawnPoint.transform.position, spawnPoint.transform.rotation, transform);
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
