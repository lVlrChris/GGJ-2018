using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInfo : MonoBehaviour {

    public int playerIndex;
    public new string name;
    public Diet diet;
    public float junkPercentage = 0f;
    public float healthyPercentage = 0f;

    //used for end of match stats
    public float aimPercentage = 0f;
    public float firedShots = 0f;
    public float landedShots = 0f;

    public Text junkText;
    public Text healthText;

    public Transform UIPanel;
    private Slider healthySlider, junkSlider;

    private PlayerLoot playerLoot;

	// Use this for initialization
	void Start () {
        playerLoot = GetComponent<PlayerLoot>();
        UIPanel = GameObject.Find("PanelP" + playerIndex).transform;
        healthySlider = UIPanel.Find("HealthSlider").GetComponent<Slider>();
        junkSlider = UIPanel.transform.Find("JunkSlider").GetComponent<Slider>();
        junkText = UIPanel.transform.Find("JunkPercentage").GetComponent<Text>();
        healthText = UIPanel.transform.Find("HealthPercentage").GetComponent<Text>();
    }

    void UpdatePercentage(){
        junkPercentage = playerLoot.JunkCount / (playerLoot.JunkCount + playerLoot.HealthCount) * 100;
        healthyPercentage =  playerLoot.HealthCount / (playerLoot.JunkCount + playerLoot.HealthCount) * 100;
        //Debug.Log("junk" + junkPercentage);
        //Debug.Log("health" + healthyPercentage);
        junkText.text = junkPercentage + "% ";
        healthText.text = healthyPercentage + "%";
        healthySlider.value = (healthyPercentage / 100);
        junkSlider.value = junkPercentage / 100;
    }
	
	// Update is called once per frame
	void Update () {
        UpdatePercentage();
	}

    public float GetDietPoints()
    {
        //if(diet == Diet.JunkFood) return 
        return diet == Diet.JunkFood ? playerLoot.JunkCount : playerLoot.HealthCount;
            //playerLoot.HealthCount
    }
}
