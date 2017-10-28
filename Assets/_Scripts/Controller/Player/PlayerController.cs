using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private float moveSpeed = 5.0f;

    private Animator anim;

	private GameManager gm;

    private bool isMoving;
    private Vector2 lastMove;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
		gm = GetComponentInParent<GameManager>();
		//gm = GameObject.Find("GameManager").GetComponent("GameManager");
	}
	
	// Update is called once per frame
	void Update () {

        isMoving = false;

        //Player Movement

		if (Input.GetAxisRaw ("Horizontal") > 0f || Input.GetAxisRaw ("Horizontal") < 0f) {
			transform.Translate (new Vector3 (Input.GetAxisRaw ("Horizontal") * moveSpeed * Time.deltaTime, 0f, 0f));
			isMoving = true;
			lastMove = new Vector2 (Input.GetAxisRaw ("Horizontal"), 0f);
		}
		if (Input.GetAxisRaw ("Vertical") > 0f || Input.GetAxisRaw ("Vertical") < 0f) {
			transform.Translate (new Vector3 (0f, Input.GetAxisRaw ("Vertical") * moveSpeed * Time.deltaTime, 0f));
			isMoving = true;
			lastMove = new Vector2 (0f, Input.GetAxisRaw ("Vertical"));
		}

		//sets direction for when the player stops moving
        anim.SetFloat("MoveX", Input.GetAxisRaw("Horizontal"));
        anim.SetFloat("MoveY", Input.GetAxisRaw("Vertical"));
        anim.SetBool("isMoving",isMoving);
        anim.SetFloat("LastMoveX", lastMove.x);
        anim.SetFloat("LastMoveY", lastMove.y);

    }

	//controlls the interact option
	void OnTriggerStay2D(Collider2D other)
	{
		if (other.CompareTag("Unmoveable"))
		{
			
			gm.interaction ("String");
		}
	}

	public void resetPlayer(){

		transform.SetPositionAndRotation (new Vector3 (0f, 0f, 0f),Quaternion.identity);

	}

}



