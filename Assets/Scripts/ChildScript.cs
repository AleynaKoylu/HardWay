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

    [SerializeField]
    GameManager gameManager;

    public bool takeMagnet;

    [SerializeField]
    GameObject Road1, Road2;

    bool start = false;

    [SerializeField]
    GameObject LosePanel, PauseButton;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }


    void Update()
    {
        MouseControl();
       
        TouchControl();
       
    }

    void MouseControl()
    {
        if (Input.GetKey(KeyCode.D))
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(1.5f, transform.position.y, transform.position.z), directionSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(-1.5f, transform.position.y, transform.position.z), directionSpeed * Time.deltaTime);
        }

        transform.Translate(0, 0, childSpeed * Time.deltaTime);
        if (Input.GetKey(KeyCode.W))
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
            if (t.phase == TouchPhase.Began)
            {
                start = true;
            }

        }
        if (start == true)
        {
            transform.Translate(0, 0, childSpeed * Time.deltaTime);
        }
        
    }
   
    void Jump()
    {
        if (jump == false)
        {
            rb.velocity = Vector3.zero;
            rb.velocity = Vector3.up * jumpValue ;
            animator.SetTrigger("JumpUp");
        }
    }
    void TakeMagnet()
    {
        takeMagnet = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject==Road1)
        {
            
            Road2.transform.position = new Vector3(Road2.transform.position.x,Road2.transform.position.y, other.gameObject.transform.position.z + 10);
        }
        if (other.gameObject == Road2)
        {

            Road1.transform.position = new Vector3(Road1.transform.position.x, Road1.transform.position.y, other.gameObject.transform.position.z + 10);
        }
        if (other.gameObject.CompareTag("Coin")) 
        {
            other.gameObject.SetActive(false);
            gameManager.AddScore(10); 
            

        }
        if (other.gameObject.CompareTag("Magnet"))
        {
            other.gameObject.SetActive(false);

            takeMagnet = true;
            Invoke("TakeMagnet", 10);
          
        }
      
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Time.timeScale = 0;
            LosePanel.SetActive(true);
            PauseButton.SetActive(false);
        }
    }

}
