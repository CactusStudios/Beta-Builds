using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	private BoardManager boardScript;
	private PlayerController playerController;

    public GameObject player;
    private GameObject playerInstance;

    public Camera camera;
    private Camera cameraInstance;

    public GameObject HUD;
    private GameObject hudInstance;





	// Use this for initialization
	void Awake () {

        //Instanciate Prefabs
        
        playerInstance = Instantiate(player, new Vector2(0f,0f), Quaternion.identity);
        playerInstance.transform.parent = this.gameObject.transform;

        cameraInstance = Instantiate(camera, new Vector3(0f, 0f, -10f), Quaternion.identity);
        cameraInstance.transform.parent = this.gameObject.transform;

        hudInstance = Instantiate(HUD, new Vector2(333f,229f), Quaternion.identity);
        hudInstance.transform.SetParent(this.gameObject.transform);

		boardScript = GetComponent<BoardManager>();
		playerController = GetComponentInChildren<PlayerController> ();


        //Initialise the game
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

    public GameObject getPlayer()
    {
        return this.playerInstance;
    }


	//Interaction function controls interaction between player and other outside objects
	public void interaction(string tag){

		Debug.Log ("Interaction called");

		if (tag.CompareTo ("Unmoveable")!= 0) {

			//query for portal entry
			Debug.Log("Press E for portal");

			//if (Input.GetKeyDown ("e")) {

                playerController.resetPlayer();
				reset ();
			//}

		}

		if (tag.CompareTo ("Unit")!= 0) {
			//query for unit interaction
		}



	}
}
