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
    [SerializeField] Vector3 AAA;


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
        BloodPosY = 1400;
    }

    // Update is called once per frame
    void Update()
    {
        Blood.transform.position = new Vector3 (400, BloodPosY, AAA.z);

        if (Input.GetKeyDown(KeyCode.F)){
            BloodPosY = 1400;
            GameStat = "GameOver";
            } else if (Input.GetKeyDown(KeyCode.G)){
                GameStat = "PlayMode";
            }
        //Estado de Juego
        switch (GameStat){
            case "GameOver":
            //Muerte de personaje
            Blood.SetActive(true);
            if (Blood.transform.position.y <= 400){
                BloodPosY = 400;
            } else {

                BloodPosY -= 2000 * Time.deltaTime;
            }
            break;
            case "PlayMode":
            BloodPosY = 1400;
            Blood.SetActive(false);
            break;
        }
    }

    public void LvlComplete(){
        print("Nivel Completado");
    }
}
