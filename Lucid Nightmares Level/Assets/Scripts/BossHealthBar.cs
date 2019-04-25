using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealthBar : MonoBehaviour
{
    GameController gameController;
    BossData bossData;
    Slider healthSlider;

    // Use this for initialization
    void Start()
    {
        healthSlider = GameObject.FindGameObjectWithTag("BossHealthBar").GetComponent<Slider>();
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        bossData = GameObject.FindGameObjectWithTag("Boss").GetComponent<BossData>();
        healthSlider.maxValue = bossData.maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        healthSlider.value = bossData.currentHealth;

        if (gameController.BossFightActive)
        {
            healthSlider.gameObject.SetActive(true);
        }
        else if(gameController.BossFightActive == false)
        {
            healthSlider.gameObject.SetActive(false);
        }
    }
}
