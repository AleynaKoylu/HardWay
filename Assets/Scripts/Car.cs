using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    [SerializeField]
    float carSpeed;
    void Start()
    {
        
    }


    void Update()
    {
        transform.Translate(0, 0, carSpeed * Time.deltaTime);
    }
}
