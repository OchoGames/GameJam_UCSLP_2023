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
    [Header("Estado de juego")]
    public GameState currentGameState;
    public int score;

    [SerializeField] private GameObject Blood;
    [SerializeField] private float VelBlood;
    
    //[SerializeField] public static string GameStat;
    [SerializeField] Vector3 AAA;
    private float SorteoF;
    [SerializeField] private int SorteoInt;


    void Awake()
    {
        if (Instance == null){
            Instance = this;
            //DontDestroyOnLoad(gameObject);
        } 
    }
    // Start is called before the first frame update
    void Start()
    {
        //GameObject Blood = GameObject.Find("GameOverBG");
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


        if (currentGameState == GameState.inGame)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                // Set pausa
                SetNewGameState(GameState.pause);
            }
        }
        else if (currentGameState == GameState.pause)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                // Set game
                SetNewGameState(GameState.inGame);
            }
        }

        //Estado de Juego
        /*switch (GameStat){
            case "GameOver":
                if (Blood.transform.position.y < 420 && Blood.transform.position.y > 380){
                    Blood.transform.position = new Vector3(400, 400, 0);
                } else {

                    Blood.transform.Translate(0, VelBlood * Time.deltaTime, 0);
                }
            break;

            case "PlayMode":
                if (Blood.transform.position.y < -790 && Blood.transform.position.y > -810)
                {
                    Blood.transform.position = new Vector3(400, -800, 0);
                }
                else
                {
                    Blood.transform.Translate(0, VelBlood * Time.deltaTime, 0);
                }
            break;
        }*/
    }
    public void GameOver(){
        Blood.transform.position = new Vector3(400, 1600, 0);
        //GameStat = "GameOver";
        SetNewGameState(GameState.gameOver);
    }

    public void TryAgain(){
        //GameStat = "PlayMode";
        SetNewGameState(GameState.inGame);
    }

    public void StartGame()
    {
        SetNewGameState(GameState.inGame);
    }


    public void LvlComplete(){
        print("Nivel Completado");
    }

    public void SetNewGameState(GameState newGameState)
    {
        switch (newGameState)
        {
            case GameState.mainMenu: // Es para el menu principal
                Time.timeScale = 0;
                break;

            case GameState.inGame: // Para cuando se esta jugando
                Time.timeScale = 1;
                if (Blood.transform.position.y < -790 && Blood.transform.position.y > -810)
                {
                    Blood.transform.position = new Vector3(400, -800, 0);
                }
                else
                {
                    Blood.transform.Translate(0, VelBlood * Time.deltaTime, 0);
                }
                break;

            case GameState.pause: // Cuando pones pausa
                Time.timeScale = 0;
                break;

            case GameState.gameOver:// Para el game over
                Time.timeScale = 0;
                if (Blood.transform.position.y < 420 && Blood.transform.position.y > 380)
                {
                    Blood.transform.position = new Vector3(400, 400, 0);
                }
                else
                {

                    Blood.transform.Translate(0, VelBlood * Time.deltaTime, 0);
                }
                break;
        }

        currentGameState = newGameState;
    }
}

public enum GameState
{
    mainMenu,
    inGame,
    pause,
    gameOver
}
