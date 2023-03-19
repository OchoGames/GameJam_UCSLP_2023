using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeTime : MonoBehaviour
{
    [Header("Insert 'Lifetime'")]
    [SerializeField] private float Lifetime;
    private float time;
    void Start()
    {
        time = Lifetime;
    }

    // Update is called once per frame
    void Update()
    {
        time -= 1 * Time.deltaTime;
        if (time <= 0){
            gameObject.SetActive(false);
            time = Lifetime;
        }
    }
}
