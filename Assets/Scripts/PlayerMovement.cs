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
    }
}
