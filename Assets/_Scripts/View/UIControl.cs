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
    private GameObject screenInstance;

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

    //Instanciate the loading screen
    public void runLoadingScreen(float time)
    {
        screenInstance = Instantiate(loadingScreen, new Vector2(0f, 0f), Quaternion.identity);
        screenInstance.transform.SetParent(gm.gameObject.transform);
        Debug.Log("Screen Built");

        //begins a separate thread to run the screeen while loadings happen in the background
        StartCoroutine(dramaticWait(time));
       
    }

    private IEnumerator dramaticWait(float time)
    {
        Debug.Log("Screen started");
        yield return new WaitForSeconds(time);
        Destroy(screenInstance);
        Debug.Log("Screen ended");
    }


}
