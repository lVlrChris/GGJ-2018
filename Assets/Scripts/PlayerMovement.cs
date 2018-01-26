using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float moveSpeed;
    private PlayerInfo playerInfo;

	void Start () {
        playerInfo = GetComponent<PlayerInfo>();
	}
	
	void Update ()
    {
        float moveX = Input.GetAxis("HorizontalP"+playerInfo.playerIndex);
        float moveZ = Input.GetAxis("VerticalP"+playerInfo.playerIndex);
        transform.Translate(moveX * moveSpeed * Time.deltaTime, 0, moveZ * moveSpeed * Time.deltaTime);
	}
}
