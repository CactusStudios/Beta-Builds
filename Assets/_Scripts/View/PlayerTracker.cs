using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTracker : MonoBehaviour {

	private GameObject player;

    private GameManager gm;


	private Vector3 offset;

	// Use this for initialization
	void Start () {

        //set up communication wiht the Game Manager
        gm = GetComponentInParent<GameManager>();

        //retrieve player instance
        this.player = gm.getPlayer();

		offset = transform.position - player.transform.position;

	}

	// Update is called once per frame
	void Update () {

		transform.position = player.transform.position + offset;

	}


}