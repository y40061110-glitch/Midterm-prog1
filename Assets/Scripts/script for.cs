using UnityEngine;
using UnityEngine.InputSystem;
public class NewMonoBehaviourScript : MonoBehaviour
{
    public Vector3 direction; 
    public float speed = 10f;
    public Rigidbody2D myRB;
    public float jumpForce = 40f;
    public bool isGrounded;
    public float timer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        myRB = GetComponent<Rigidbody2D>();
        isGrounded = false;
        Debug.Log("Hi Miku");
    }

private void Update()

    {
        timer += Time.deltaTime;
    
       // Update is called once per frame

    
       
//then we set the y based off whatever existing y is 
         direction.y = myRB.linearVelocity.y;
         //then we set the linearVelocity = to this new vector
          myRB.linearVelocity = direction;
            if(Keyboard.current.spaceKey.wasPressedThisFrame && isGrounded)
          {
    
             myRB.AddForce (jumpForce * Vector3.up * speed);
          }
    
    }

           private void FixedUpdate()
    {
         direction = Vector3.zero;
        if (Keyboard.current.aKey.isPressed)
        {
            direction += Vector3.left;
        }
        if (Keyboard.current.dKey.isPressed)
        {
            direction += Vector3.right;
        
        //one way to move objects is by manually moving the transform
        //this is ok but not interact with the physics engine
        //maybe good for moving background sprites clouds
        }
                  direction = direction * speed;
    
         
//then we set the y based off whatever existing y is 
         direction.y = myRB.linearVelocity.y;
         //then we set the linearVelocity = to this new vector
          myRB.linearVelocity = direction;
           
    
    
    }


void OnCollisionEnter2D(Collision2D collision)
         {
               if(collision.gameObject.tag == "Ground")
               {
                   isGrounded = true;
            
               }
          }

void OnCollisionExit2D(Collision2D collision)
          {
              if(collision.gameObject.tag == "Ground")
              {
                  isGrounded = false;
              }
          }
        void OnCollisionStay2D(Collision2D collision)
        { if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }

        }
    }
        

