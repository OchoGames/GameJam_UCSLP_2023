using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelManager : MonoBehaviour
{
    private GameObject BloodBG;
    [SerializeField] private GameManager Manager;
    // Start is called before the first frame update
    void Start()
    {
        BloodBG = GameObject.Find("BloodBG");
    }

    // Update is called once per frame
    void Update()
    {
        if (Manager.currentGameState == GameState.gameOver){
            BloodBG.SetActive(true);
        } else {
            BloodBG.SetActive(false);
        }
    }
}
