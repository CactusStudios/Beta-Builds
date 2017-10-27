using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	private BoardManager boardScript;
	private PlayerController player;

	// Use this for initialization
	void Awake () {
		boardScript = GetComponent<BoardManager>();
		player = GetComponentInChildren<PlayerController> ();

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

	//Interaction function controls interaction between player and other outside objects
	public void interaction(string tag){

		Debug.Log ("Interaction called");

		if (tag.CompareTo ("Unmoveable")!= 0) {

			//query for portal entry
			Debug.Log("Press E for portal");

			//if (Input.GetKeyDown ("e")) {

				player.resetPlayer ();
				reset ();
			//}

		}

		if (tag.CompareTo ("Unit")!= 0) {
			//query for unit interaction
		}



	}
}
