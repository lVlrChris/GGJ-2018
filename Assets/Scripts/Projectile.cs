using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    public float moveSpeed;
    
    void Update () {
        transform.Translate(0, 0, moveSpeed * Time.deltaTime);
	}
}
