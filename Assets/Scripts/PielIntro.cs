using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PielIntro : MonoBehaviour {

    bool fade = false;
    private GameObject fadeObject;
    private Material material;

	// Use this for initialization
	void Start () {
        fadeObject = GameObject.Find("Fade");
        material = fadeObject.GetComponent<MeshRenderer>().material;

        StartCoroutine(WaitForFade());
	}
	
    void Update()
    {
        if(fade)
        {
            float alpha = Mathf.Lerp(material.color.a, 1f, 1 * Time.deltaTime);
            material.SetColor("_Color", new Color(material.color.r, material.color.g, material.color.b, alpha));
        }
    }

    IEnumerator WaitForFade()
    {
        yield return new WaitForSeconds(6);
        fade = true;
        StartCoroutine(WaitAndLoadMenu());
    }

    IEnumerator WaitAndLoadMenu()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("MainMenu");
    }
}
