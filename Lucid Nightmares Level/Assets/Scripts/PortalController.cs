using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PortalController : MonoBehaviour
{
    public string portalDestination;
    public string interactMessage;
    public TextMeshPro destinationText;
    public TextMeshPro interactText;
    public GameObject player;
    public float distanceFromPlayer;
    public float interactDistance = 1.9f;
    public float textDisplayDistance = 5f;

	// Use this for initialization
	void Start ()
    {
        destinationText.text = portalDestination;
        interactText.text = interactMessage;
    }
	
	// Update is called once per frame
	void Update ()
    {
        distanceFromPlayer = Vector2.Distance(transform.position, player.transform.position);

        if (distanceFromPlayer <= interactDistance && Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene(0);
        }
        if (distanceFromPlayer <= textDisplayDistance)
        {
            destinationText.enabled = true;
            interactText.enabled = true;
        }

        else
        {
            destinationText.enabled = false;
            interactText.enabled = false;
        }
    }
}