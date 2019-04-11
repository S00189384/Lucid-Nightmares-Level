using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpecialAbilityBar : MonoBehaviour
{
    PlayerData playerData;
    public Slider specialSlider;

    // Use this for initialization
    void Start()
    {
        playerData = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerData>();
        specialSlider.maxValue = playerData.maxSpecial;
    }

    // Update is called once per frame
    void Update()
    {
        specialSlider.value = playerData.currentSpecial;
    }
}
