﻿using System.Collections;
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
		boardScript.SetupScene (1);
	}
	// Update is called once per frame
	void Update () {
		
	}
}