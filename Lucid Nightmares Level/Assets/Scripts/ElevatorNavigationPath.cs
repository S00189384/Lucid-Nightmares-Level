using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorNavigationPath : MonoBehaviour
{
    public Transform[] Nodes;

    public int NodeCount { get { return Nodes.Length; } }
}
