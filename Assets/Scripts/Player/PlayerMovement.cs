using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Audio;

public class PlayerMovement : MonoBehaviour
{
    // Singelton para player
    public static PlayerMovement Instance;

    [Header("Player")]
    [SerializeField] private float VelPlayer;
    [SerializeField] private Rigidbody2D PlayerRB;
    /*[Header("Insert 'GameManager'")]
    [SerializeField] GameManager Manager;*/
    [Header("Insert 'Particle Manager'")]
    [SerializeField] ParticleManager Particle;
    private Animator animator;
    [SerializeField] public bool hide;
    [SerializeField] private GameObject Weapon;
    public static bool HasWeapon;
    //[SerializeField] private GameObject Pared;

    private AudioSource audio;
    [SerializeField] private GameObject EnemiesFinal;
    [SerializeField] private int Objetos;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        HasWeapon = false;
        PlayerRB = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        hide = false;
        Weapon = GameObject.Find("Weapon");
        Weapon.SetActive(false);
        audio = GetComponent<AudioSource>();
        EnemiesFinal.SetActive(false);
        //Pared = GameObject.Find("Pared abajo");
    }

    // Update is called once per frame
    void Update()
    {
        //Movimiento de jugador
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        if (GameManager.Instance.currentGameState == GameState.inGame)
        {
            Vector2 movement = new Vector2(horizontal, vertical);
            PlayerRB.velocity = movement * VelPlayer;

            //Animacion del jugador

            if (Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") == 0) {
                animator.SetBool("Walking", false);
            } else {
                animator.SetBool("Walking", true);
            }

            if (Input.GetKeyDown(KeyCode.Z)) {
                GameObject Exclamation = Particle.RequestExclamationSign();
                Exclamation.transform.position = new Vector2(transform.position.x, transform.position.y + 0.9f);
            }

            if (hide == false) {
                Eyes.animator.SetBool("Rock Face", false);
            } else {
                Eyes.animator.SetBool("Rock Face", true);
            }

            //Infinite Map
            if (transform.position.x >= 42) {
                Vector3 newPos = transform.position;
                newPos.x = -42;
                transform.position = newPos;
            } else if (transform.position.x <= -42) {
                Vector3 newPos = transform.position;
                newPos.x = 42;
                transform.position = newPos;
            }

            if (transform.position.y >= 66){
                GameManager.Instance.LvlComplete();
            }

            Debug.Log("Hide: "+hide);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Enemy") && !hide){
            //Manager.GameOver();
            GameManager.Instance.SetNewGameState(GameState.gameOver);
            audio.Play();
        }

    }

    void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Wall")){
            if (Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") == 0){
                hide = true;
            }
            else
            {
                hide = false;
            }
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Wall"))
            hide = false;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Exit")){
            //Manager.LvlComplete();
            GameManager.Instance.LvlComplete();
        }

        if (other.gameObject.CompareTag("Enemy") && !hide){
            GameObject Exclamation = Particle.RequestExclamationSign();
            Exclamation.transform.position = new Vector2(transform.position.x, transform.position.y + 0.9f);
            GameManager.Instance.SetNewGameState(GameState.gameOver);
            audio.Play();
        }
    }
}
