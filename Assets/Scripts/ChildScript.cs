using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildScript : MonoBehaviour
{
    Rigidbody rb;

    float jumpValue = 5f;
    float childSpeed = 5f;
    float directionSpeed=10;

    bool left;
    bool right;

    bool jump=false;

    [SerializeField]
    GameObject jumpEffeckt;

    Animator animator;

  
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }


    void Update()
    {
        //MouseControl();
       
        TouchControl();
        if (aldý == true)
        {
           cn.gameObject.transform.position = Vector3.Lerp(cn.transform.position, transform.position, .1f);
        }
       
    }

    void MouseControl()
    {
        float horizontal = Input.GetAxis("Horizontal");
        
        transform.Translate(horizontal ,transform.position.y, childSpeed*Time.deltaTime);
        if (Input.GetMouseButtonDown(0))
        {
            Jump();
        }
    }
    private void OnCollisionStay(Collision collision)
    {

        jump = false; 
        jumpEffeckt.SetActive(true);
        
    }
    private void OnCollisionExit(Collision collision)
    {
        jump = true;
        jumpEffeckt.SetActive(false);
        
    }
   
    void TouchControl()
    {
        if (Input.touchCount > 0)
        {
            Touch t = Input.GetTouch(0);
            float deltaPosx = t.deltaPosition.x;
            float deltaPosy = t.deltaPosition.y;

            if (deltaPosx >= 50f)
            {
                left = false;
                right = true;

                transform.position = Vector3.Lerp(transform.position, new Vector3(1.5f, transform.position.y,transform.position.z),directionSpeed*Time.deltaTime);
                
            }
            if (deltaPosx<= -50f)
            {
                left = true;
                right =false;

                 transform.position=Vector3.Lerp(transform.position, new Vector3(-1.5f, transform.position.y, transform.position.z),directionSpeed* Time.deltaTime);

            }
            if (deltaPosy >=50)
            {
                Jump();
            }

        }
        transform.Translate(0, 0, childSpeed * Time.deltaTime);
    }
    public GameObject cn;
    bool aldý;
    void Jump()
    {
        if (jump == false)
        {
            rb.velocity = Vector3.zero;
            rb.velocity = Vector3.up * jumpValue ;
            animator.SetTrigger("JumpUp");
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Road"))
        {
            
            other.gameObject.transform.position = new Vector3(0,0, transform.position.z + 10);
        }
        if (other.gameObject.CompareTag("Coin")) 
        {
            other.gameObject.SetActive(false);

        }
        if (other.gameObject.CompareTag("Magnet"))
        {
            other.gameObject.SetActive(false);
            aldý = true;
        }
      
    }

}
