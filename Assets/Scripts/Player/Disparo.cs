using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparo : MonoBehaviour
{
    [SerializeField] private Transform controladorDisparo;
    [SerializeField] private GameObject bala;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && PlayerMovement.HasWeapon){
            Disparar();
        }
        
    }

    void Disparar(){
        Instantiate(bala, controladorDisparo.position, controladorDisparo.rotation);
    }
}
