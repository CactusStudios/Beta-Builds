using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public BoardManager boardScript;
	public GameObject player;
	public GameObject HUD;

	// Use this for initialization
	void Awake () {
		boardScript = GetComponent<BoardManager>();
		initGame ();
	}

	void initGame(){
		
		boardScript.setupScene (0);//default to 0 for the homeworld board
		Debug.Log ("Board Created");

		GameObject playerObject = new GameObject ("Player");
		playerObject = Instantiate (player, new Vector3 (0f, 0f, 0f), Quaternion.identity) as GameObject;
		Debug.Log("Player Generated");

		GameObject HUDObject = new GameObject ("HUD");
		HUDObject = Instantiate (HUD, new Vector3 (0f, 0f, 0f), Quaternion.identity) as GameObject;
		Debug.Log("HUD Generated");
	}

	void reset(){
		//boardScript.deactivate();
		boardScript.setupScene (0);
		Debug.Log ("Board Reset");
	}

	/*
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown ("p")) {
			Debug.Log ("Reset Called");
			reset ();

		}
	}
	*/
}
