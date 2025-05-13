using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Connector : MonoBehaviour
{
    public GameObject Body;
    PathFinding pathfinding;
    private void Awake()
    {
        pathfinding = Body.GetComponent<PathFinding>();
    }

    private void TryTakeItemConnector()
    {
        pathfinding.TryTakeItem();
    }

    private void ActivateItemIsGrabbed()
    {
        pathfinding.ReadyForCheckOut = true;
        pathfinding.Trash = true;
    }
}
