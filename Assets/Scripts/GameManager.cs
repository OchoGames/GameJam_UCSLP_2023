using System.Linq.Expressions;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.CompilerServices;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Estado de juego")]
    public GameState currentGameState;

    [SerializeField] private GameObject Blood;
    public static float BloodPosY;
    
    //[SerializeField] public static string GameStat;


    void Awake()
    {
        // Singleton
        if (Instance == null){
            Instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        BloodPosY = 800;
        SetNewGameState(GameState.mainMenu);
    }

    // Update is called once per frame
    void Update()
    {
        Blood.transform.position = new Vector3(378.5f, BloodPosY, 0);

        if (Input.GetKeyDown(KeyCode.F)) {
            BloodPosY = 800;
            //GameStat = "GameOver";
            SetNewGameState(GameState.gameOver);
        } else if (Input.GetKeyDown(KeyCode.G)) {
            //GameStat = "PlayMode";
            SetNewGameState(GameState.inGame);
        }
    
        //Estado de Juego
        // **Cambie el GameState a una funcion para hacerlo mas modular**
        
        /*switch (GameStat){
            case "GameOver":
                //Muerte de personaje
                Blood.SetActive(true);
                if (Blood.transform.position.y <= 80){
                    BloodPosY = 80;
                } else {

                    BloodPosY -= 1500 * Time.deltaTime;
                }
            break;

            case "PlayMode":
                BloodPosY = 800;
                Blood.SetActive(false);
            break;
        }*/
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
                Time.timeScale = 0;
            break;

            case GameState.inGame: // Es igual al PlayMode
                Time.timeScale = 1;
                BloodPosY = 800;
                Blood.SetActive(false);
            break;

            case GameState.pause:
                Time.timeScale = 0;
            break;

            case GameState.gameOver:
                Time.timeScale = 0.7f;
                //Muerte de personaje
                Blood.SetActive(true);
                if (Blood.transform.position.y <= 80)
                {
                    BloodPosY = 80;
                }
                else
                {

                    BloodPosY -= 1500 * Time.deltaTime;
                }
            break;
        }

        currentGameState = newGameState;
    }
}

public enum GameState
{
    // Aqui se declaran los estados del juego
    mainMenu,
    inGame,
    pause,
    gameOver
}
