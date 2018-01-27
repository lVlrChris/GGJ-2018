using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoundTimer : MonoBehaviour {
    public float gameTime = 30f;
    
    public Text GameTimer;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        gameTime -= Time.deltaTime;
        GameTimer.text = Mathf.Round(gameTime).ToString();
        if(gameTime <= 0){
            GameTimer.text = "KLAAAAAR";
        }
	}
}
