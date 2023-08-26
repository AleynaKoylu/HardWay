using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    
    GameObject Child;
    ChildScript childScript;
    void Start()
    {
        Child = GameObject.FindGameObjectWithTag("Player");
        childScript = Child.GetComponent<ChildScript>();
    }

    void Update()
    {
        float distance = Vector3.Distance(transform.position, Child.transform.position);

        if (childScript.takeMagnet == true)
        {
           
            if (distance <= 5)
            {
                transform.position = Vector3.MoveTowards(transform.position, Child.transform.position, 10 * Time.deltaTime);
            }
            
        }

        
    }
}
