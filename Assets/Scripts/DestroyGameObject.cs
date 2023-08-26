using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyGameObject : MonoBehaviour
{
    GameObject Child;
    void Start()
    {
        Child = GameObject.FindGameObjectWithTag("Player");
    }

    
    void Update()
    {
        if (transform.position.z < (Child.transform.position.z - 5.0f))
        {
            gameObject.SetActive(false);
        }
    }
}
