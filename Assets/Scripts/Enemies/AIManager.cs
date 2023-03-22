using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIManager : MonoBehaviour
{
    AIPath controller;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<AIPath>();
        controller.canMove = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.currentGameState == GameState.inGame)
        {
            controller.canMove = true;
        }
        else
        {
            controller.canMove = false;
        }
    }
}
