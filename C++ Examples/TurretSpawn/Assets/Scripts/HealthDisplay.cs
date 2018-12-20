using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour {

    public Text HealthText;
    public GameObject Enemy;
    private float DisplayIn = 5;
    public Image Bar;
    
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        DisplayIn -= Time.deltaTime;

        if (DisplayIn <= 0)
        {
            HealthText.text = "Enemy Health: " + EnemyHealth.returnHealth();
            //Bar.GetComponent<Image>().Color = new Color32(0, 255, 0, 255);
        }
    }
}
