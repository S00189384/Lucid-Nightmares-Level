using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavigationPath : MonoBehaviour
{
    public Transform[] Nodes;

    public int NodeCount { get { return Nodes.Length; } }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        if (Nodes != null)
        {

            for (int i = 0; i < Nodes.Length; i++)
            {
                if (i != Nodes.Length - 1)
                {
                    Gizmos.DrawLine(Nodes[i].position, Nodes[i + 1].position);
                }

                else
                {
                    Gizmos.DrawLine(Nodes[i].position, Nodes[0].position);
                }

            }

        }
    }


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
