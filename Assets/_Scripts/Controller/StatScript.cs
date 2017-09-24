using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatScript : MonoBehaviour {

	public int health;
	public int mana;

	// Use this for initialization
	void Start () {
		health = 100;
		mana = 100;

	}
	
	// Update is called once per frame
	void Update () {

		if (health >= 0) {

			if (Input.GetKeyDown (KeyCode.K)) {
				setHealth (10);
			}

			if (Input.GetKeyDown (KeyCode.F)) {
				setMana (10);
			}
		} else {
				Debug.Log("Dead");
				health = 100;
		}



	}

	void setHealth(int health)
	{
		this.health -= health;
	}

	void setMana(int mana)
	{
		this.mana -= mana;
	}
}
