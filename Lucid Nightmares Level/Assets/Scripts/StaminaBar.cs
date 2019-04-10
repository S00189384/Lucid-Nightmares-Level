using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaBar : MonoBehaviour
{
    PlayerData playerData;
    public Slider staminaSlider;

    // Use this for initialization
    void Start()
    {
        playerData = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerData>();
        staminaSlider.maxValue = playerData.maxStamina;
    }

    // Update is called once per frame
    void Update()
    {
        staminaSlider.value = playerData.currentStamina;
    }

}
