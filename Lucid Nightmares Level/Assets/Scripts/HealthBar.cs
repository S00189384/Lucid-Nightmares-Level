using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    PlayerData playerData;
    public Slider healthSlider;

	// Use this for initialization
	void Start ()
    {
        playerData = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerData>();
        healthSlider.maxValue = playerData.maxHealth;
	}
	
	// Update is called once per frame
	void Update ()
    {
        healthSlider.value = playerData.currentHealth;
	}
}
