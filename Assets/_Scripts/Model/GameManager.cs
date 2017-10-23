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
		
	}	

	void reset(){
		boardScript.deactivate();
		boardScript.setupScene (0);
		Debug.Log ("Board Reset");
	}

    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            reset();
        }
    }
}
