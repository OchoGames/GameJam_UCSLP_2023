using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMov : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed;
    public bool pared;
    [Header("Options: Vertical / Horizontal")]
    [SerializeField] private string direction;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        pared = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x <= -34){
            if (pared)
            {
                transform.rotation = Quaternion.Euler(0, 0, -90);
                pared = false;
            } else if (!pared){
                transform.rotation = Quaternion.Euler(0, 0, 90);
                pared = true;
            }
            speed *= -1;
        } else if (transform.position.x >= 34){
            if (pared)
            {
                transform.rotation = Quaternion.Euler(0, 0, -90);
                pared = false;
            } else if (!pared){
                transform.rotation = Quaternion.Euler(0, 0, 90);
                pared = true;
            }
            speed *= -1;
        }
        if (GameManager.Instance.currentGameState == GameState.inGame)
        {
            switch(direction){
                case "Vertical":
                    rb.velocity = new Vector2(0, speed);
                    break;
                case "Horizontal":
                    rb.velocity = new Vector2(speed, 0);
                    break;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            if (pared)
            {
                transform.rotation = Quaternion.Euler(0, 0, -90);
                pared = false;
            } else if (!pared){
                transform.rotation = Quaternion.Euler(0, 0, 90);
                pared = true;
            }
        }

        speed *= -1;
    }
}
