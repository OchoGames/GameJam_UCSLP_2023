using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/*  
    El objetivo de este script es hacer que el enemigo
    busque al jugador en caso de que este ultimo se encuentré
    creca del enemigo 
*/

public class EnemyMove : MonoBehaviour
{
    public Transform player; // guardará la posicion del jugador
    private NavMeshAgent enemy; // Auxiliara a darle el comportamiento al enemigo
    
    // Start is called before the first frame update
    void Start()
    {
        enemy = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        Enemy_Move();
    }

    void Enemy_Move()
    {
        // Busca la posicion del jugador
        enemy.destination = player.position;
    }
}
