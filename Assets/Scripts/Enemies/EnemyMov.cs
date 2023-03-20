using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMov : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed,x,y;
    public bool pared;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        pared = false;
        x = Random.Range(-1, 1);
        y = Random.Range(-1, 1);
    }

    // Update is called once per frame
    void Update()
    {
        if (/*GameManager.Instance.currentGameState == GameState.pause*/true)
        {

            rb.velocity = new Vector2 (x, y) * speed;
            
            //rb.velocity = new Vector3(x, y, 0) * speed;

            if (pared)
            {
                pared = false;
                x *= -1;
                y *= -1;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            pared = true;
        }
    }
}
