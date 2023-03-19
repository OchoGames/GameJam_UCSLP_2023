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
    public static float BloodPosY;
    [Header("Estado de juego")]
    [SerializeField] public static string GameStat;


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
        BloodPosY = 800;
    }

    // Update is called once per frame
    void Update()
    {
        Blood.transform.position = new Vector3 (378.5f, BloodPosY, 0);

        if (Input.GetKeyDown(KeyCode.F)){
            BloodPosY = 800;
            GameStat = "GameOver";
            }
        //Estado de Juego
        switch (GameStat){
            case "GameOver":
            //Muerte de personaje
            Blood.SetActive(true);
            BloodPosY -= 1000 * Time.deltaTime;
            if (Blood.transform.position.y < 80)
                BloodPosY = 80;
            break;
        }
    }

    public void LvlComplete(){
        print("Nivel Completado");
    }
}
