using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour {
	

	public GameObject[] boards;
	private GameObject board;
	private Transform boardHolder;



	public void boardSetup(int boardNumber){
		board = new GameObject ("Board");
		boardHolder = board.transform;

		GameObject instance = Instantiate (boards [boardNumber], new Vector3 (0f, 0f, 0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent (boardHolder);
	}

	public void setupScene(int boardNumber)
    {
		boardSetup (boardNumber);
	}

    public void deactivate()
    {
        Destroy(board.gameObject);
    }
	
}
