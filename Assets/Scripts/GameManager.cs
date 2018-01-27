using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public GameObject fastFoodPlayer;
    public GameObject healthyPlayer;

    public Transform spawnPosP1;
    public Transform spawnPosP2;

    public GameObject p1;
    public GameObject p2;

    void Start () {
        DontDestroyOnLoad(gameObject);
    }
	
	
    public void StartGame()
    {
        SceneManager.LoadScene("NielsScene");
        StartCoroutine(SpawnPlayers());
    }

    private IEnumerator SpawnPlayers()
    {
        yield return new WaitForSeconds(2);
        spawnPosP1 = GameObject.Find("SpawnPosP1").transform;
        spawnPosP2 = GameObject.Find("SpawnPosP2").transform;
        p1 = Instantiate(fastFoodPlayer, spawnPosP1.position, spawnPosP1.rotation) as GameObject;
        p1.GetComponent<PlayerInfo>().playerIndex = 1;
        p2 = Instantiate(healthyPlayer, spawnPosP2.position, spawnPosP2.rotation) as GameObject;
        p2.GetComponent<PlayerInfo>().playerIndex = 2;
    }

    public void EndGame()
    {
        StartCoroutine(EndTheGame());
    }

    public IEnumerator EndTheGame()
    {

        PlayerEndScreenStats p1stats = new PlayerEndScreenStats(p1.GetComponent<PlayerInfo>().firedShots, p1.GetComponent<PlayerInfo>().landedShots,
                                                                p1.GetComponent<PlayerInfo>().junkPercentage, p1.GetComponent<PlayerInfo>().healthyPercentage, p1.GetComponent<PlayerInfo>().GetDietPoints());
        PlayerEndScreenStats p2stats = new PlayerEndScreenStats(p2.GetComponent<PlayerInfo>().firedShots, p2.GetComponent<PlayerInfo>().landedShots,
                                                                p2.GetComponent<PlayerInfo>().junkPercentage, p2.GetComponent<PlayerInfo>().healthyPercentage, p2.GetComponent<PlayerInfo>().GetDietPoints());
        SceneManager.LoadScene("EndGame");

        yield return new WaitForSeconds(1);
        Transform panelP1 = GameObject.Find("PanelP1").transform;
        Transform panelP2 = GameObject.Find("PanelP2").transform;

        panelP1.Find("FiredShots").GetComponent<Text>().text = p1stats.FiredShots.ToString() + " fired shots";
        panelP1.Find("LandedShots").GetComponent<Text>().text = p1stats.LandedShots.ToString() + " landed shots";
        panelP1.Find("AimPercentage").GetComponent<Text>().text = "That's a hit percentage of " + p1stats.GetLandedShotPercentage().ToString() + "%";
        panelP1.Find("JunkPercentage").GetComponent<Text>().text = "Junk food: " + p1stats.JunkPercentage.ToString() + "%";
        panelP1.Find("HealthyPercentage").GetComponent<Text>().text = "Healthy food: " + p1stats.HealthyPercentage.ToString() + "%";

        panelP2.Find("FiredShots").GetComponent<Text>().text = p2stats.FiredShots.ToString() + " fired shots";
        panelP2.Find("LandedShots").GetComponent<Text>().text = p2stats.LandedShots.ToString() + " landed shots";
        panelP2.Find("AimPercentage").GetComponent<Text>().text = "That's a hit percentage of " + p2stats.GetLandedShotPercentage().ToString() + "%";
        panelP2.Find("JunkPercentage").GetComponent<Text>().text = "Junk food: " + p2stats.JunkPercentage.ToString() + "%";
        panelP2.Find("HealthyPercentage").GetComponent<Text>().text = "Healthy food: "+p2stats.HealthyPercentage.ToString() + "%";

        Text winnerText = GameObject.Find("WinnerText").GetComponent<Text>();
        int winner = DetermineWinner(p1stats, p2stats);
            winnerText.text = "Player " + winner + " wins";
        print(winnerText.text);
    }

    public int DetermineWinner(PlayerEndScreenStats p1stats, PlayerEndScreenStats p2stats)
    {

        int p1Score = 0;
        int p2Score = 0;

        //diet percentage
        if (p1stats.LandedShots > p2stats.LandedShots) { p1Score++; } else { p2Score++; }

        //diet points (percentage goed eten)
        if (p1stats.DietPoints > p2stats.DietPoints) { p1Score++; } else { p2Score++; }

        //aim percentage
        if (p1stats.GetLandedShotPercentage() > p2stats.GetLandedShotPercentage());


        return p1Score > p2Score ? 1 : 2;
    }
}
