using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIControl : MonoBehaviour {

    //Components
    public Slider healthSlider;
    public Slider manaSlider;
    public Slider xpSlider;
    public GameObject loadingScreen;

    //Scripts
    private GameManager gm;
    private StatsScript stats; 


	// Use this for initialization
	void Start () {

        gm = GetComponentInParent<GameManager>();
        stats = gm.getPlayer().GetComponent<StatsScript>();

        healthSlider.maxValue = stats.getMaxHealth();
        manaSlider.maxValue = stats.getMaxMana();
        xpSlider.maxValue = stats.getMaxExp();

	}
	
	// Update is called once per frame
	void Update () {

        //healthSlider.maxValue = stats.getMaxHealth();
        //manaSlider.maxValue = stats.getMaxMana();
        //xpSlider.maxValue = stats.getMaxExp();

        //Sliders need to be initialised under the ui to accomodate visual changes

        healthSlider.value = stats.getHealth();
        manaSlider.value = stats.getMana();
        xpSlider.value = stats.getExp();

	}

    void runLoadingScreen()
    {
        //do things
    }


}
