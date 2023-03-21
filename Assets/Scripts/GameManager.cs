using System;
using System.Dynamic;
using System.Linq.Expressions;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

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

    [Header("Paneles")]
    [SerializeField] private GameObject MainMenuPanel;
    [SerializeField] private GameObject CreditsPanel;
    [SerializeField] private GameObject InstructionsPanel;
    [SerializeField] private GameObject GameOverPanel;
    [SerializeField] private GameObject PausePanel;
    [SerializeField] private GameObject GameCompleted;

    private AudioSource audio;


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
        SetNewGameState(GameState.mainMenu);
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {


        if (currentGameState == GameState.inGame)
        {
            audio.Play();
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                // Set pausa
                SetNewGameState(GameState.pause);
            }
        }
        else if (currentGameState == GameState.pause)
        {
            audio.Play();
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                // Set game
                SetNewGameState(GameState.inGame);
            }
        }

    }
    public void GameOver(){
        //GameStat = "GameOver";
        SetNewGameState(GameState.gameOver);
    }

    public void TryAgain(){
        audio.Play();
        //GameStat = "PlayMode";
        SetNewGameState(GameState.inGame);
    }

    public void StartGame()
    {
        audio.Play();
        SetNewGameState(GameState.inGame);
    }

    public void Instructions(){
        audio.Play();
        SetNewGameState(GameState.instructions);
    }

    public void GoToMenu(){
        audio.Play();
        SceneManager.LoadScene("Game");
    }

    public void Credits(){
        audio.Play();
        SetNewGameState(GameState.credits);
    }

    public void LvlComplete(){
        SetNewGameState(GameState.gamecompleted);
    }

    public void pause(){
        audio.Play();
        if(currentGameState == GameState.inGame){
            SetNewGameState(GameState.pause);
        } else if(currentGameState == GameState.pause){
            SetNewGameState(GameState.inGame);
        }
    }

    public void SetNewGameState(GameState newGameState)
    {
        switch (newGameState)
        {
            case GameState.mainMenu: // Es para el menu principal
                MainMenuPanel.SetActive(true);
                CreditsPanel.SetActive(false);
                InstructionsPanel.SetActive(false);
                GameOverPanel.SetActive(false);
                PausePanel.SetActive(false);
                GameCompleted.SetActive(false);
                Time.timeScale = 1;
                break;

            case GameState.credits: // Para los creditos
                CreditsPanel.SetActive(true);
                MainMenuPanel.SetActive(false);
                GameCompleted.SetActive(false);
                break;

            case GameState.inGame: // Para cuando se esta jugando
                MainMenuPanel.SetActive(false);
                InstructionsPanel.SetActive(false);
                GameOverPanel.SetActive(false);
                PausePanel.SetActive(false);
                Time.timeScale = 1;
                break;

            case GameState.instructions: // Para las instrucciones
                InstructionsPanel.SetActive(true);
                MainMenuPanel.SetActive(false);
                break;

            case GameState.tryAgain: // Para cuando se pierde
                GameOverPanel.SetActive(true);
                Time.timeScale = 1;
                break;

            case GameState.pause: // Cuando pones pausa
                PausePanel.SetActive(true);
                Time.timeScale = 0;
                break;

            case GameState.gameOver:// Para el game over
                GameOverPanel.SetActive(true);
                Time.timeScale = 0;
                break;
            case GameState.gamecompleted:
                GameCompleted.SetActive(true);
                break;
        }

        currentGameState = newGameState;
    }
}

public enum GameState
{
    mainMenu,
    credits,
    instructions,
    inGame,
    tryAgain,
    pause,
    gameOver,
    gamecompleted
}
