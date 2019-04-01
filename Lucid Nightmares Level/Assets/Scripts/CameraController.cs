using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject PlayerToFollow;
    private Vector3 tempPosition;

    void Update()
    {
        tempPosition.x = PlayerToFollow.transform.position.x;
        tempPosition.y = PlayerToFollow.transform.position.y;
        tempPosition.z = transform.position.z;

        transform.position = tempPosition;
    }
}
