using UnityEngine;
using System;


public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public GameObject WaypointPrefab;
    
    public float moveSpeed = 5f;
    
    public bool spacePressed = false;
    public bool Movement = true;
    
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    private Vector2 currentDirection = Vector2.zero;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A) && Movement)
        {
            currentDirection = Vector2.left;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D) && Movement)
        {
            currentDirection = Vector2.right;
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W) && Movement)
        {
            currentDirection = Vector2.up;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S) && Movement)
        {
            currentDirection = Vector2.down;
        }
        
        if(Input.GetKeyDown(KeyCode.RightBracket) && Movement)
        {
            Movement = false;
        }
        else if(Input.GetKeyDown(KeyCode.RightBracket) && !Movement)
        {
            Movement = true;
        }
        
        //if(Input.GetKeyDown(KeyCode.Space))   //dit is code voor waypoint stuff
        //{
           // GameObject up = Instantiate(WaypointPrefab);
         //   up.transform.position = transform.position;
           // 
       // }
       if(Input.GetKeyDown(KeyCode.Space))
        {
            spacePressed = true;
            StartCoroutine(DisableSpacepressed(0.5f));
        }
       
    
        
   
    }

    void FixedUpdate()
    {
        rb.linearVelocity = currentDirection * moveSpeed;
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        
        if(spacePressed && collision.gameObject.CompareTag("Wall"))
        {
            Destroy(collision.gameObject);
        }
        
    }
     System.Collections.IEnumerator DisableSpacepressed(float delay)
    {
        yield return new WaitForSeconds(delay);
        spacePressed = false;
    }

    


}