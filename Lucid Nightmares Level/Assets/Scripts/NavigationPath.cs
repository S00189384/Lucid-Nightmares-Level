using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavigationPath : MonoBehaviour
{
    public Transform[] Nodes;

    public int NodeCount { get { return Nodes.Length; } }

    public Vector2 GetNodePosition(int index)
    {
        if (index >= 0 && index < Nodes.Length)
        {
            return Nodes[index].position;
        }
        else
        {
            return Vector2.zero;
        }
    }
}
