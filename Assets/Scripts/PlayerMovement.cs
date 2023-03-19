using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Player")]
    [SerializeField] private float VelPlayer;
    [SerializeField] private Rigidbody2D PlayerRB;
    [Header("Insert 'GameManager'")]
    [SerializeField] GameManager Manager;
    [Header("Insert 'Particle Manager'")]
    [SerializeField] ParticleManager Particle;
    // Start is called before the first frame update
    void Start()
    {
        PlayerRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(horizontal, vertical);
        PlayerRB.velocity = movement * VelPlayer;

        if (Input.GetKeyDown(KeyCode.Z)){
            GameObject Exclamation = Particle.RequestExclamationSign();
            Exclamation.transform.position = new Vector2(transform.position.x, transform.position.y + 0.9f);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Exit")){
            Manager.LvlComplete();
        }
    }
}
