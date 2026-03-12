using UnityEngine;
using System;


public class PlayerMovement2 : MonoBehaviour
{
    public Rigidbody2D rb;
    public GameObject WallPrefab;
 public GameObject rotatedWall;
    public BoxCollider2D boxCollider;
    public bool Movement = true;

    public float moveSpeed = 5f;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
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
        if(Input.GetKeyDown(KeyCode.LeftBracket) && Movement)
        {
            Movement = false;
        }
        else if(Input.GetKeyDown(KeyCode.LeftBracket) && !Movement)
        {
            Movement = true;
        }
        
       if(Input.GetKeyDown(KeyCode.Tab))
        {
            GameObject wall = Instantiate(WallPrefab, transform.position, Quaternion.identity);
            wall.transform.Rotate(0f, 0f, 90f);
            boxCollider.enabled = false;
            StartCoroutine(ReEnableCollider(1f)); 
        }

        if(Input.GetKeyDown(KeyCode.Backspace))
        {
            GameObject wall = Instantiate(WallPrefab, transform.position, Quaternion.identity);
            
            boxCollider.enabled = false;
            StartCoroutine(ReEnableCollider(1f)); 
        }
    }

    void FixedUpdate()
    {
        rb.linearVelocity = currentDirection * moveSpeed;
    }

    System.Collections.IEnumerator ReEnableCollider(float delay)
    {
        yield return new WaitForSeconds(delay);
        boxCollider.enabled = true;
    }
}
