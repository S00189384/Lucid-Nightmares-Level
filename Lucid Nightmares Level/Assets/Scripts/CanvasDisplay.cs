using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasDisplay : MonoBehaviour
{
    PlayerData playerData;

    public Image Key1;
    public Image Key2;
    public Image Key3;

	// Use this for initialization
	void Start ()
    {
        Key1.enabled = false;
        Key2.enabled = false;
        Key3.enabled = false;
        playerData = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerData>();
	}

    public void DisplayKey()
    {
        if (playerData.HasKey1 == true)
            Key1.enabled = true;
        if (playerData.HasKey2 == true)
            Key2.enabled = true;
        if (playerData.HasKey3 == true)
            Key3.enabled = true;
    }
}
