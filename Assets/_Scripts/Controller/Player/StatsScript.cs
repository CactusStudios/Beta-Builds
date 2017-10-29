
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class StatsScript : MonoBehaviour {
	private int health = 100;
    private int mana = 100;
    private int level = 1;
    private int currentHealth;
    private int currentMana;
    private int currentXp;
    private int xpCap;
    public bool damage;
    public bool isDead;


    PlayerController PlayerController;

    // Use this for initialization
    void Start ()
    {
     //   PlayerController = GetComponent<moveSpeed> ();

        xpCap = 83;

        currentHealth = health;
        currentMana = mana;
    }
	
	// Update is called once per frame
	void Update ()
    {
		if (Input.GetKeyDown (KeyCode.F))
        {
            TakeDamage(10);
			Debug.Log("Health Loss");
		}

		if (Input.GetKeyDown (KeyCode.K)) {
            TakeMana(10);
			Debug.Log("Mana Loss");
		}

        if (Input.GetKeyDown(KeyCode.L))
        {
            GiveMana(10);
            Debug.Log("Mana given");
        }

        if (Input.GetKeyDown(KeyCode.G))
        {
            GiveHealth(10);
            Debug.Log("Health given");
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            GainXp(100);
            Debug.Log("XP Gain");
        }
    }

    public int getHealth(){
        return this.currentHealth;
    }

    public int getMana()
    {
        return this.currentMana;
    }

    public int getMaxHealth()
    {
        return this.health;
    }

    public int getMaxMana()
    {
        return this.mana;
    }

    public int getExp()
    {
        return this.currentXp;
    }

    public int getMaxExp()
    {
        return this.xpCap;
    }


    public void TakeDamage(int amount)
    {
        damage = true;

        currentHealth -= amount;

        if (currentHealth <= 0)
        {
            currentHealth = 0;
        }

        if(currentHealth <= 0 && !isDead)
        {
            death();
        }
    }

    public void death()
    {
        isDead = true;
    }

    public void TakeMana(int amount)
    {
        currentMana -= amount;

        if (currentMana <= 0)
        {
            currentMana = 0;
        }

    }

    public void GiveHealth(int amount)
    {
        currentHealth += amount;

        if(currentHealth > (level * 10) + health)
        {
            currentHealth = 100;
        }
    }

    public void GiveMana(int amount)
    {
        
        currentMana += amount;

        if(currentMana > (level * 10) + mana)
        {
            currentMana = 100;
        }

    }

    public void GainXp(int amount)
    {
        currentXp += amount;

        if(currentXp >= xpCap)
        {
            LevelUp();
            currentXp = 0;
        }

    }

    private void LevelUp()
    {
        if(level < 100)
        {
            level += 1;
        }
        else
        {
            level = 100;
        }

        xpCap += (xpCap * 10) / 4;

        health = (level * 10) + health;
        mana = (level * 10) + mana;

        currentHealth = health;
        currentMana = mana;
    }
}
