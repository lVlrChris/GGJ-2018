using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoundTimer : MonoBehaviour {
    public float gameTime = 90f;

    private bool startedEndTimer = false;

    public AudioSource audioSource;
    public AudioClip mainMusic;
    public AudioClip endMusic;

    bool endMusicPlaying = false;
    bool countingDown = true;
    public Text gameTimer;
    public Text countdownText;
    public Transform gameIntro;
    private GameManager gameManager;
	// Use this for initialization
	void Start () {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        audioSource.Play();


        StartCoroutine(WaitForIntroAndCount());
	}
	
	// Update is called once per frame
	void Update () {
        if (!countingDown)
        {
            gameTime -= Time.deltaTime;
            int min = Mathf.FloorToInt(gameTime / 60);
            int sec = Mathf.FloorToInt(gameTime % 60);
            gameTimer.text = min.ToString("00") + ":" + sec.ToString("00");

            if (gameTime < 6 && !startedEndTimer)
            {
                StartCoroutine(AnimateSeconds(5));
                StartCoroutine(Countdown(5));
                audioSource.Stop();
                audioSource.clip = endMusic;
                audioSource.Play();
                startedEndTimer = true;
            }
            if (gameTime < 1)
            {
                if (gameTime <= 0)
                {
                    print("end game");
                    gameManager.EndGame();
                }
            }
        }
	}

    IEnumerator WaitForIntroAndCount()
    {
        yield return new WaitForSeconds(5f);
        Destroy(gameIntro.gameObject);
        StartCoroutine(Countdown(3, "FIGHT!"));
    }

    IEnumerator Countdown(int n, string doneMessage ="")
    {
        if (n > 0)
        {
            countdownText.text = n.ToString();
            yield return new WaitForSeconds(1f);
            StartCoroutine(Countdown(n - 1,doneMessage));
        }else
        {
            countdownText.text = doneMessage;
            gameManager.UnlockPlayerMovements();
            yield return new WaitForSeconds(1f);
            countdownText.text = "";
            //Destroy(countdownText.gameObject);
            countingDown = false;
        }
    }

    IEnumerator AnimateSeconds(int n)
    {
        gameTimer.gameObject.GetComponent<Animator>().SetBool("Blink", true);
        if (n > 0)
        {
            yield return new WaitForSeconds(1f);
            gameTimer.gameObject.GetComponent<Animator>().SetBool("Blink", false);
            StartCoroutine(AnimateSeconds(n - 1));
        }
    }
}
