using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawBladeController : MonoBehaviour
{
    public float rotation = 2;
    public int damage = 50;

	// Update is called once per frame
	void Update ()
    {
        transform.Rotate(0,0,rotation);
	}
}
