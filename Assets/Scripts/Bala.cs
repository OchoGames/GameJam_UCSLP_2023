using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    [SerializeField] private float velocidad;
    [SerializeField] private float tiempoDeVida;
    [SerializeField] private float daño;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.up * velocidad * Time.deltaTime);
        tiempoDeVida -= 1 * Time.deltaTime;
        if (tiempoDeVida <= 0){
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("EnemyF")){
            other.GetComponent<EnemyFinal>().TomarDaño(daño);
            Destroy(gameObject);
        }

        Destroy(gameObject);
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        Destroy(gameObject);
    }
}
