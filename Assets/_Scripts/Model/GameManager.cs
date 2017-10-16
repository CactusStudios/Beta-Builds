using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public BoardManager boardScript;


	// Use this for initialization
	void Awake () {
		boardScript = GetComponent<BoardManager>();
		initGame ();
	}

	void initGame(){
		boardScript.setupScene (0);//default to 0 for the homeworld board
		Debug.Log ("Board Created");
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
