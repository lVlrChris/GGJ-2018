using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoundTimer : MonoBehaviour {
    public float gameTime = 90f;
<<<<<<< Updated upstream
    private bool startedEndTimer = false;
=======
    public AudioSource audioSource;
    public AudioClip mainMusic;
    public AudioClip endMusic;

    bool endMusicPlaying = false;

>>>>>>> Stashed changes
    public Text GameTimer;
    private GameManager gameManager;
	// Use this for initialization
	void Start () {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        audioSource.Play();
	}
	
	// Update is called once per frame
	void Update () {
        gameTime -= Time.deltaTime;
        int min = Mathf.FloorToInt(gameTime / 60);
        int sec = Mathf.FloorToInt(gameTime % 60);
        GameTimer.text = min.ToString("00") + ":" + sec.ToString("00");
<<<<<<< Updated upstream
        if (gameTime < 7 && !startedEndTimer)
        {
            StartCoroutine(AnimateSeconds(5));
            startedEndTimer = true;
        }
        if (gameTime < 1){
=======
        if(gameTime <= 5 && !endMusicPlaying) {
            endMusicPlaying = true;
            audioSource.Stop();
            audioSource.clip = endMusic;
            audioSource.Play();

        }
        if (gameTime <= 0){

>>>>>>> Stashed changes
            print("end game");
            gameManager.EndGame();
        }
	}

    IEnumerator AnimateSeconds(int n)
    {
        GameTimer.gameObject.GetComponent<Animator>().SetBool("Blink", true);
        if (n > 0)
        {
            yield return new WaitForSeconds(1f);
            GameTimer.gameObject.GetComponent<Animator>().SetBool("Blink", false);
            StartCoroutine(AnimateSeconds(n - 1));
        }
    }
}
