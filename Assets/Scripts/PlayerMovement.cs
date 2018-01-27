using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float moveSpeed;
    private PlayerInfo playerInfo;
    private Animator animator;
    public bool canMove = false;

	void Start () {
        playerInfo = GetComponent<PlayerInfo>();
        animator = transform.GetChild(0).GetComponent<Animator>();
	}
	
	void Update ()
    {
        if (canMove)
        {
            float moveX = Input.GetAxis("HorizontalP"+playerInfo.playerIndex);
            float moveZ = Input.GetAxis("VerticalP"+playerInfo.playerIndex);
            if(moveX != 0 || moveZ != 0)
            {
                animator.SetBool("Running", true);
                transform.Translate(moveX * moveSpeed * Time.deltaTime, 0, moveZ * moveSpeed * Time.deltaTime, Space.World);
            }else
            {
                animator.SetBool("Running", false);
            }
        }
	}
}
