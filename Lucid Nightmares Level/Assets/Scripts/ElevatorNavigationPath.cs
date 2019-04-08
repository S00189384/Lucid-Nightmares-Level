using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorNavigationPath : MonoBehaviour
{
    public Transform[] Nodes;

    public int NodeCount { get { return Nodes.Length; } }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        if(Nodes != null)
        {
            Gizmos.DrawLine(Nodes[0].position, Nodes[1].position);
  
        }
    }
}
