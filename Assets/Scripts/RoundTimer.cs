using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoundTimer : MonoBehaviour {
    public float gameTime = 90f;
    
    public Text GameTimer;
    private GameManager gameManager;
	// Use this for initialization
	void Start () {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
	}
	
	// Update is called once per frame
	void Update () {
        gameTime -= Time.deltaTime;
        int min = Mathf.FloorToInt(gameTime / 60);
        int sec = Mathf.FloorToInt(gameTime % 60);
        GameTimer.text = min.ToString("00") + ":" + sec.ToString("00");
        if (gameTime <= 0){
            print("end game");
            gameManager.EndGame();
        }
	}
}
