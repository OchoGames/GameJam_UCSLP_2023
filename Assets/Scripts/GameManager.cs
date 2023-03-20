using System.Dynamic;
using System;
using System.Net.NetworkInformation;
using System.Linq.Expressions;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Runtime.CompilerServices;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [Header("Estado de juego")]
    public GameState currentGameState;

    //Paneles de juego

    [Header("animaciones Panel")]
    [SerializeField] public Animator MenuPanel;
    [SerializeField] public Animator TitleMenu;
    [SerializeField] public Animator CreditsPanel;
    [SerializeField] public Animator GameOverPanel;


    void Awake()
    {
        //singleton
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        SetNewGameState(GameState.mainMenu);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void LvlComplete(){
        print("Nivel Completado");
    }

    public void SetNewGameState(GameState newGameState)
    {
        // Esta funcion se utiliza para manejar los estados del juego
        switch (newGameState)
        {
            case GameState.mainMenu:
                //Time.timeScale = 0;
                MenuPanel.SetBool("onMenu", true);
                MenuPanel.SetBool("onMenu", false);
            break;

            case GameState.inGame:

                Time.timeScale = 1;
            break;

            case GameState.pause:
                Time.timeScale = 0;
            break;

            case GameState.gameOver:
                GameOverPanel.SetBool("gameOver", true);
                GameOverPanel.SetBool("gameOver", false);
                Time.timeScale = 0.7f;
            break;
        }

        currentGameState = newGameState;
    }

/*     public void DisableAllPanels(){
        //
        MenuPanel.SetBool("onMenu", false);
        MenuPanel.SetBool("returnMenu", false);
        MenuPanel.SetBool("StartVideo", false);
        //TitleMenu
        TitleMenu.SetBool("onCredits", false);
        TitleMenu.SetBool("returnToMenu", false);
        TitleMenu.SetBool("onMenu", false);
        //Credits
        CreditsPanel.SetBool("onCredits", false);
        CreditsPanel.SetBool("onMenu", false);
        CreditsPanel.SetBool("returnToMenu", false);
        //GameOver
        GameOverPanel.SetBool("tryAgain", false);
        GameOverPanel.SetBool("onGame", false);
        GameOverPanel.SetBool("gameOver", false);
    } */

    //Botones Panel

    public void StartVideo(){
        print("AAAA");
        MenuPanel.SetBool("StartVideo", true);
        MenuPanel.SetBool("StartVideo", false);
        SetNewGameState(GameState.inGame);
    }
    public void StartGame(){
        SetNewGameState(GameState.inGame);
    }

    public void Credits(){
        SetNewGameState(GameState.Credits);
    }
}

public enum GameState
{
    // Aqui se declaran los estados del juego
    mainMenu,
    Credits,
    inGame,
    pause,
    gameOver
}

