using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFinal : MonoBehaviour
{
    [SerializeField] private float vida;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TomarDaño(float daño){
        vida -= daño;
        if (vida <= 0){
            Destroy(gameObject);
        }
    }
}
