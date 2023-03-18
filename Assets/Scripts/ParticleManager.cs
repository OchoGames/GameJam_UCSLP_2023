using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleManager : MonoBehaviour
{
    [Header ("Insert Particle 'Exclamation'")]
    [SerializeField] private GameObject ExclamationSign;
    [SerializeField] private List<GameObject> ExclamationSignList;
    [Header("Amount of Elements")]
    [SerializeField] private int PoolSize;
    // Start is called before the first frame update
    void Start()
    {
        AddParticlesToPool(PoolSize);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void AddParticlesToPool(int amount){
        for(int i = 0; i< PoolSize ; i ++){
            GameObject Exclamation = Instantiate(ExclamationSign);
            Exclamation.SetActive(false);
            ExclamationSignList.Add(Exclamation);
            Exclamation.transform.parent = transform;

        }
    }
}
