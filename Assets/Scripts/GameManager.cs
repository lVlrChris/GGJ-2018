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
    public Slider scoreSlider;
    public AudioSource audioSource;
    public AudioClip endMusic;
    public string winner;


    private int p1Score, p2Score;
    public bool inGame = false;


    void Start () {
        DontDestroyOnLoad(gameObject);
    }
	
	
    public void StartGame(string gameScene = "SceneMain")
    {
        audioSource.Stop();
        SceneManager.LoadScene(gameScene);
        StartCoroutine(SpawnPlayers());
    }

    private IEnumerator SpawnPlayers()
    {
        yield return new WaitForSeconds(2);
        spawnPosP1 = GameObject.Find("SpawnPosP1").transform;
        spawnPosP2 = GameObject.Find("SpawnPosP2").transform;
        p1 = Instantiate(fastFoodPlayer, spawnPosP1.position, spawnPosP1.rotation) as GameObject;
        p1.GetComponent<PlayerInfo>().playerIndex = 2;
        p2 = Instantiate(healthyPlayer, spawnPosP2.position, spawnPosP2.rotation) as GameObject;
        p2.GetComponent<PlayerInfo>().playerIndex = 1;
        inGame = true;
    }

    public void UnlockPlayerMovements()
    {
        p1.GetComponent<PlayerMovement>().canMove = true;
        p2.GetComponent<PlayerMovement>().canMove = true;
    }

    public void LockPlayerMovements()
    {
        p1.GetComponent<PlayerMovement>().canMove = false;
        p2.GetComponent<PlayerMovement>().canMove = false;
    }

    public void EndGame()
    {
        StartCoroutine(EndTheGame());
        inGame = false;
    }

    public IEnumerator EndTheGame()
    {
        audioSource.Play();

        PlayerInfo p1Info = p1.GetComponent<PlayerInfo>();
        PlayerInfo p2Info = p2.GetComponent<PlayerInfo>();


        PlayerEndScreenStats p1stats = new PlayerEndScreenStats(p1Info.firedShots, p1Info.landedShots,
                                                                p1Info.junkPercentage, p1Info.healthyPercentage, p1Info.GetDietPoints());
        PlayerEndScreenStats p2stats = new PlayerEndScreenStats(p2Info.firedShots,p2Info.landedShots,
                                                                p2Info.junkPercentage, p2Info.healthyPercentage, p2Info.GetDietPoints());
        SceneManager.LoadScene("VictoryScene");

        yield return new WaitForSeconds(0.1f);
        Transform panelP1 = GameObject.Find("PanelP1").transform;
        Transform panelP2 = GameObject.Find("PanelP2").transform;

        panelP1.Find("FiredShots").GetComponent<Text>().text = p1stats.FiredShots.ToString() + " fired shots";
        panelP1.Find("LandedShots").GetComponent<Text>().text = p1stats.LandedShots.ToString() + " landed shots";
        panelP1.Find("AimPercentage").GetComponent<Text>().text = "That's a hit percentage of " + p1stats.GetLandedShotPercentage().ToString() + "%";
        panelP1.Find("JunkPercentage").GetComponent<Text>().text = "Junk food: " + p1stats.JunkPercentage.ToString() + "%";
        panelP1.Find("HealthyPercentage").GetComponent<Text>().text = "Healthy food: " + p1stats.HealthyPercentage.ToString() + "%";
        panelP1.Find("DietPoints").GetComponent<Text>().text = "Diet Points: " + p1stats.DietPoints.ToString();

        panelP2.Find("FiredShots").GetComponent<Text>().text = p2stats.FiredShots.ToString() + " fired shots";
        panelP2.Find("LandedShots").GetComponent<Text>().text = p2stats.LandedShots.ToString() + " landed shots";
        panelP2.Find("AimPercentage").GetComponent<Text>().text = "That's a hit percentage of " + p2stats.GetLandedShotPercentage().ToString() + "%";
        panelP2.Find("JunkPercentage").GetComponent<Text>().text = "Junk food: " + p2stats.JunkPercentage.ToString() + "%";
        panelP2.Find("HealthyPercentage").GetComponent<Text>().text = "Healthy food: "+p2stats.HealthyPercentage.ToString() + "%";
        panelP2.Find("DietPoints").GetComponent<Text>().text = "Diet Points: " + p2stats.DietPoints.ToString();
       
        print("WINNEEEER" + winner);

        GameObject snackyWin = GameObject.Find("SnackyWin");
        GameObject snackyLose = GameObject.Find("FruityLose");
        // snackyLose.SetActive(true);

        GameObject fruityWin = GameObject.Find("SnackyWin");
        GameObject fruityLose = GameObject.Find("FruityLose");
        if(winner.Equals("snacky")) {
            snackyWin.transform.GetChild(0).gameObject.SetActive(true);
            fruityLose.transform.GetChild(0).gameObject.SetActive(true);
        } else if (winner.Equals("fruity")) {
            snackyLose.transform.GetChild(0).gameObject.SetActive(true);
            fruityWin.transform.GetChild(0).gameObject.SetActive(true);
        }


        Text winnerText = GameObject.Find("WinnerText").GetComponent<Text>();
        string winnerst = DetermineWinner(p1stats, p2stats);
        winnerText.text =  winnerst; 
        print(winnerText.text);
    }

    public string DetermineWinner(PlayerEndScreenStats p1stats, PlayerEndScreenStats p2stats)
    {
        /*
        int p1Score = 0;
        int p2Score = 0;

        //diet percentage HIER NOG DRAW
        if (p1stats.LandedShots > p2stats.LandedShots) { p1Score++; } else { p2Score++; }

        //diet points (percentage goed eten)
        if (p1stats.DietPoints > p2stats.DietPoints) { p1Score++; } else { p2Score++; }

        //aim percentage
        if (p1stats.GetLandedShotPercentage() > p2stats.GetLandedShotPercentage());
        print("p1 score: " + p1Score);
        print("p2 score: " + p2Score);
        */
        if (p1Score == p2Score) { return "DRAW"; }
        if (p1Score > p2Score) { winner = "snacky"; } else { winner = "fruity"; }
        return p1Score > p2Score ? "SNACKY WINS" : "FRUITY WINS";
    }


    void CalculateScore()
    {
        PlayerInfo p1Info = p1.GetComponent<PlayerInfo>();
        PlayerInfo p2Info = p2.GetComponent<PlayerInfo>();
        PlayerLoot p1Loot = p1.GetComponent<PlayerLoot>();
        PlayerLoot p2Loot = p2.GetComponent<PlayerLoot>();


        PlayerEndScreenStats p1stats = new PlayerEndScreenStats(p1Info.firedShots, p1Info.landedShots,
                                                                p1Info.junkPercentage, p1Info.healthyPercentage, p1Info.GetDietPoints());
        PlayerEndScreenStats p2stats = new PlayerEndScreenStats(p2Info.firedShots, p2Info.landedShots,
                                                                p2Info.junkPercentage, p2Info.healthyPercentage, p2Info.GetDietPoints());

        var p1Points =  p1stats.DietPoints * ScorePoints.dietfood;
        p1Points += p1stats.FiredShots * ScorePoints.shotPenalty;
        p1Points += p1stats.LandedShots * ScorePoints.accuracyBonus;

        p1Points += (p1Loot.HealthCount * ScorePoints.wrongFood);

        print(p1.name);

        var p2Points = p2stats.DietPoints * ScorePoints.dietfood;
        p2Points += p2stats.FiredShots * ScorePoints.shotPenalty;
        p2Points += p2stats.LandedShots * ScorePoints.accuracyBonus;

        p2Points += (p2Loot.JunkCount * ScorePoints.wrongFood);
        print("p2 score " + p2Points);

        if (p1Points < 0) p1Points = 0;
        if (p2Points < 0) p2Points = 0;
        if(p1Points <= 0 && p2Points <= 0) { }

        float p1Percentage, p2Percentage;
        p1Percentage = (p1Points / (p1Points + p2Points) ) * 100;
        p2Percentage = (p2Points / (p1Points + p2Points)) * 100;
        print("p1% : " + p1Percentage);
        print("p2% : " + p2Percentage);

        if (p1Points <= 0 && p2Points <= 0) { p2Percentage = 50;  }

        p1Score = (int)p1Points;
        p2Score = (int)p2Points;

        var healthbar = GameObject.FindWithTag("ScoreSlider");
        print(healthbar.GetComponent<Slider>().value);
        healthbar.GetComponent<Slider>().value = (p2Percentage / 100);  //.GetComponent<Slider>().value = (p1Percentage / 100);
    }

    private void Update()
    {
        if(inGame)
            CalculateScore();
    }
}
