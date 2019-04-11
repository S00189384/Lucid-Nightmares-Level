using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSourceController : MonoBehaviour
{
    Vector3 position;

	void Update ()
    {
        //When spawning in the Light Source, camera to world point was putting the objects z position to be 0. 
        //This script sets the z position to -1 so that the light is visible.
        position.z = -1;
        position.x = transform.position.x;
        position.y = transform.position.y;
        transform.position = position;
	}
	
}
