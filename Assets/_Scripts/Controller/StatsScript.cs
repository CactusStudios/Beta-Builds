
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsScript : MonoBehaviour {
	public int health = 100;
	public int mana = 100;
    public int level = 1;
    public int currentHealth;
    public int currentMana;
    public int currentXp;
    public int xpCap = 83;
    public bool damage;
    public bool isDead;
    public Slider healthSlider;
    public Slider manaSlider;
    public Slider xpSlider;

    PlayerController PlayerController;

    // Use this for initialization
    void Start ()
    {
     //   PlayerController = GetComponent<moveSpeed> ();

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
            Debug.Log("Health Loss");
        }
    }

    public void TakeDamage(int amount)
    {
        damage = true;

        currentHealth -= amount;

        if (currentHealth <= 0)
        {
            currentHealth = 0;
        }

        healthSlider.value = currentHealth;

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

        manaSlider.value = currentMana;
    }

    public void GiveHealth(int amount)
    {
        currentHealth += amount;

        if(currentHealth > (level * 10) + health)
        {
            currentHealth = 100;
        }

        healthSlider.value = currentHealth;
    }

    public void GiveMana(int amount)
    {
        
        currentMana += amount;

        if(currentMana > (level * 10) + mana)
        {
            currentMana = 100;
        }

        manaSlider.value = currentMana;
    }

    public void GainXp(int amount)
    {
        currentXp += amount;

        if(currentXp >= xpCap)
        {
            LevelUp();
            currentXp = 0;
        }

        xpSlider.value = currentXp;
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

        xpSlider.maxValue = xpCap;

        health = (level * 10) + health;
        mana = (level * 10) + mana;

        healthSlider.maxValue = health;
        manaSlider.maxValue = mana;

        currentHealth = health;
        currentMana = mana;
    }
}
