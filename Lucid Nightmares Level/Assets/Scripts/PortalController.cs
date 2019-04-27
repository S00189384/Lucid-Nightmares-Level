using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PortalController : MonoBehaviour
{
    public string portalDestination;
    TextMeshPro text;
    public GameObject player;
    public float distanceFromPlayer;
    public float interactDistance = 1.9f;
    public float textDisplayDistance = 5f;

	// Use this for initialization
	void Start ()
    {
        text = GetComponentInChildren<TextMeshPro>();
        text.text = portalDestination;
    }
	
	// Update is called once per frame
	void Update ()
    {
        distanceFromPlayer = Vector2.Distance(transform.position, player.transform.position);

        if (distanceFromPlayer <= interactDistance && Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            //Load Scene
        }
        if (distanceFromPlayer <= textDisplayDistance)
            text.enabled = true;
        else
            text.enabled = false;
  
    }
}
