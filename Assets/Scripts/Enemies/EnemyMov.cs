using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMov : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed;
    public bool pared;
    int angle;
    [Header("Options: Vertical / Horizontal")]
    [SerializeField] private Options options;

    enum Options
    {
        Vertical,
        Horizontal,
        Both
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        pared = false;
        angle = -1;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (GameManager.Instance.currentGameState == GameState.inGame)
        {
            /*if (transform.position.x <= -34)
            {
                if (pared)
                {
                    transform.rotation = Quaternion.Euler(0, 0, -90);
                    pared = false;
                }
                else if (!pared)
                {
                    transform.rotation = Quaternion.Euler(0, 0, 90);
                    pared = true;
                }
                speed *= -1;
            }
            else if (transform.position.x >= 34)
            {
                if (pared)
                {
                    transform.rotation = Quaternion.Euler(0, 0, -90);
                    pared = false;
                }
                else if (!pared)
                {
                    transform.rotation = Quaternion.Euler(0, 0, 90);
                    pared = true;
                }
                speed *= -1;
            }*/

            switch (options){
                case Options.Vertical:
                    rb.velocity = new Vector2(0, speed);
                    break;
                case Options.Horizontal:
                    rb.velocity = new Vector2(speed, 0);
                    break;
                case Options.Both:
                    rb.velocity = new Vector2(1, 1) * speed;
                    break;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Limit"))
        {
            speed *= -1;
            angle *= -1;
            transform.rotation = Quaternion.Euler(angle*180, angle*180, 180*angle);

            /*pared = true;

            if (pared)
            {
                pared = false;
                transform.rotation = Quaternion.Euler(180, 180, -90);
                speed *= -1;
            } else if (!pared){
                transform.rotation = Quaternion.Euler(-180, -180, 90);
                pared = true;
            }*/
        }
    }
}
