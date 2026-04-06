using UnityEngine;
using System;


public class PlayerMovementa : MonoBehaviour
{
    public Rigidbody2D rb;
    public GameObject WaypointPrefab;
    
    public bool WallEatCD = true;
    public float moveSpeed = 5f;
    
    public bool spacePressed = false;
    public bool Movemen = true;
    
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    private Vector2 currentDirection = Vector2.zero;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A) && Movemen)
        {
            currentDirection = Vector2.left;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D) && Movemen)
        {
            currentDirection = Vector2.right;
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W) && Movemen)
        {
            currentDirection = Vector2.up;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S) && Movemen)
        {
            currentDirection = Vector2.down;
        }
        
        if(Input.GetKeyDown(KeyCode.RightBracket) && Movemen)
        {
            Movemen = false;
        }
        else if(Input.GetKeyDown(KeyCode.RightBracket) && !Movemen)
        {
            Movemen = true;
        }
        
        //if(Input.GetKeyDown(KeyCode.Space))   //dit is code voor waypoint stuff
        //{
           // GameObject up = Instantiate(WaypointPrefab);
         //   up.transform.position = transform.position;
           // 
       // }
       if(Input.GetKeyDown(KeyCode.Space) && WallEatCD)
        {
            spacePressed = true;
            StartCoroutine(DisableSpacepressed(0.5f));
            WallEatCD = false;
            StartCoroutine(WalleatCD(2f));

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
        if(collision.gameObject.CompareTag("sped"))
        {
            moveSpeed *= 2f;
            Destroy(collision.gameObject);
            StartCoroutine(sped(5f));

        }
        
    }
     System.Collections.IEnumerator DisableSpacepressed(float delay)
    {
        yield return new WaitForSeconds(delay);
        spacePressed = false;
    }
    System.Collections.IEnumerator WalleatCD(float delay)
    {
        yield return new WaitForSeconds(delay);
        WallEatCD = true;
    }

    System.Collections.IEnumerator sped(float delay)
    {
        yield return new WaitForSeconds(delay);
        moveSpeed /= 2f;
    }
    
    

    


}