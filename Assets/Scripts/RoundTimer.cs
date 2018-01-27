using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoundTimer : MonoBehaviour {
    public float gameTime = 30f;
    
    public Text GameTimer;
    private GameManager gameManager;
	// Use this for initialization
	void Start () {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
	}
	
	// Update is called once per frame
	void Update () {
        gameTime -= Time.deltaTime;
        GameTimer.text = Mathf.Round(gameTime).ToString();
        if(gameTime <= 0){
            print("end game");
            gameManager.EndGame();
        }
	}
}
