using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class PlayerMovement : MonoBehaviour
{
    [Header("Player")]
    [SerializeField] private float VelPlayer;
    [SerializeField] private Rigidbody2D PlayerRB;
    /*[Header("Insert 'GameManager'")]
    [SerializeField] GameManager Manager;*/
    [Header("Insert 'Particle Manager'")]
    [SerializeField] ParticleManager Particle;
    private Animator animator;
    [SerializeField] public bool Hide;
    // Start is called before the first frame update
    void Start()
    {
        PlayerRB = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        Hide = false;
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

            if (Hide == false) {
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
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Enemy")){
            //Manager.GameOver();
            GameManager.Instance.SetNewGameState(GameState.gameOver);
        }

    }

    void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Wall")){
            if (Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") == 0){
                Hide = true;
            } else {
                Hide = false;
            }
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        Hide = false;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Exit")){
            //Manager.LvlComplete();
            GameManager.Instance.LvlComplete();
        }

        if (other.gameObject.CompareTag("Enemy")){
            GameObject Exclamation = Particle.RequestExclamationSign();
            Exclamation.transform.position = new Vector2(transform.position.x, transform.position.y + 0.9f);
        }

        if(other.gameObject.CompareTag("Weapon Coin")){
            Destroy(other.gameObject);
        }
    }
}
