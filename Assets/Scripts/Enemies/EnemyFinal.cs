using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFinal : MonoBehaviour
{
    [SerializeField] float Life;

    //movimiento enemigo
    [SerializeField] float speed;
    [SerializeField] GameObject target;
    private float distance;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        //Movimiento enemigo
        distance = Vector2.Distance(transform.position, target.transform.position);
        Vector2 direction = target.transform.position - transform.forward;

        transform.position = Vector2.MoveTowards(this.transform.position, target.transform.position, speed * Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Bala"))
        {
            print("aaa");
            Life -= 20;
            if (Life <= 0)
            {
                Destroy(gameObject);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Bala"))
        {
            print("aaa");
            Life -= 20;
            if (Life <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
