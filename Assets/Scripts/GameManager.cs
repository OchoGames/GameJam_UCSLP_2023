using System;
using System.Dynamic;
using System.Linq.Expressions;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] private GameObject Blood;
    [SerializeField] private float VelBlood;
    [Header("Estado de juego")]
    [SerializeField] public static string GameStat;
    [SerializeField] Vector3 AAA;
    private float SorteoF;
    [SerializeField] private int SorteoInt;


    void Awake()
    {
        if (GameManager.Instance == null){
            GameManager.Instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        GameObject Blood = GameObject.Find("GameOverBG");
    }

    // Update is called once per frame
    void Update()
    {
        //Blood.transform.position = new Vector3(AAA.x, AAA.y, AAA.z);
        if (Input.GetKeyDown(KeyCode.F)){
            GameOver();
            } else if (Input.GetKeyDown(KeyCode.G)){
                TryAgain();
            }
        //Estado de Juego
        switch (GameStat){
            case "GameOver":
            if (Blood.transform.position.y < 420 && Blood.transform.position.y > 380){
                Blood.transform.position = new Vector3(400, 400, 0);
                } else {

                Blood.transform.Translate(0, VelBlood * Time.deltaTime, 0);
                }
            break;

            case "PlayMode":
            if (Blood.transform.position.y < -790 && Blood.transform.position.y > -810){
                Blood.transform.position = new Vector3(400, -800, 0);
                } else {
                Blood.transform.Translate(0, VelBlood * Time.deltaTime, 0);
                }
            break;
        }
    }
    public void GameOver(){
        Blood.transform.position = new Vector3(400, 1600, 0);
        GameStat = "GameOver";
    }

    public void TryAgain(){
        GameStat = "PlayMode";
    }


    public void LvlComplete(){
        print("Nivel Completado");
    }
}
