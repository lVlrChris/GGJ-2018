using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkLight : MonoBehaviour {
    public float minRange;
    public float maxRange;
    public float speed;
    public bool increasing = true;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float currentRange = GetComponent<Light>().range;

        if (increasing)
        {
            GetComponent<Light>().range += speed;

            if (currentRange >= maxRange)
            {
                increasing = false;
            }
        }

        if (!increasing)
        {
            GetComponent<Light>().range -= speed;

            if (currentRange <= minRange)
            {
                increasing = true;
            }
        }
        
	}
}
