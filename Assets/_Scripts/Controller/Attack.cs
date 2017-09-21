using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour {

    public GameObject bulletPrefab;
    public Transform bulletSpawn;
	public float attackSpeed;
	private float lastShotTime;

    // Use this for initialization
    void Start () {
		lastShotTime = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.Space))
        {
            Fire();
        }
    }

    void Fire()
    {
		if(Time.time > (attackSpeed*Time.deltaTime)+lastShotTime){
        // Create the Bullet from the Bullet Prefab
        var bullet = (GameObject)Instantiate(
            bulletPrefab,
            bulletSpawn.position,
            bulletSpawn.rotation);
		

        // Add velocity to the bullet
        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 6;


        // Destroy the bullet after 2 seconds
        Destroy(bullet, 2.0f);
			lastShotTime = Time.time;
	}


    }
}
