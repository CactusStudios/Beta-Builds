﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {


	}

    void onTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);

        if (other.CompareTag("Player"))
        {
            Debug.Log("Touching");
        }
    }

}