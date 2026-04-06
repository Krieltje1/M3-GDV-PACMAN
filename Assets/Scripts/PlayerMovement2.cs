using UnityEngine;
using System;
using NavMeshPlus.Components;
using UnityEngine.U2D.IK;


public class PlayerMovement2 : MonoBehaviour
{
    public Rigidbody2D rb;
    public GameObject WallPrefab;
    public bool CD = true;
    public bool CD2 = true;
    public BoxCollider2D Box;
    public bool Movement = true;
    public NavMeshSurface navMeshSurface;

    public float moveSpeed = 5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [Obsolete]
    void Start()
    {
        Box = GetComponent<BoxCollider2D>();
        if (navMeshSurface == null)
            navMeshSurface = FindObjectOfType<NavMeshSurface>();
    }

    // Update is called once per frame
    private Vector2 currentDirection = Vector2.zero;

    [Obsolete]
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
        
       if(Input.GetKeyDown(KeyCode.Tab) && CD) 
        {
            GameObject wall = Instantiate(WallPrefab, transform.position, Quaternion.identity);
            wall.transform.Rotate(0f, 0f, 90f);
            Box.enabled = false;
            StartCoroutine(ReEnableCollider(0.2f)); 
            BakeNavMesh();
            CD = false;
            StartCoroutine(Cooldown(3f));
        }

        if(Input.GetKeyDown(KeyCode.Backspace) && CD2)
        {
            GameObject wall = Instantiate(WallPrefab, transform.position, Quaternion.identity);
            
            Box.enabled = false;
            StartCoroutine(ReEnableCollider(0.5f));
            BakeNavMesh();
            CD2 = false;
            StartCoroutine(Cooldown2(3f));
        }
    }

    void FixedUpdate()
    {
        rb.linearVelocity = currentDirection * moveSpeed;
    }

    System.Collections.IEnumerator ReEnableCollider(float delay)
    {
        yield return new WaitForSeconds(delay);
        Box.enabled = true;
    }
    System.Collections.IEnumerator Cooldown(float delay)
    {
        yield return new WaitForSeconds(delay);
        CD = true;
    }
     System.Collections.IEnumerator Cooldown2(float delay)
    {
        yield return new WaitForSeconds(delay);
        CD2 = true;
    }

    [Obsolete]
    public void BakeNavMesh()
    {
        if (navMeshSurface == null)
            navMeshSurface = FindObjectOfType<NavMeshSurface>();

        if (navMeshSurface != null)
        {
            navMeshSurface.BuildNavMesh();
        }
        
    }
      void OnCollisionStay2D(Collision2D collision)
    {
        
         if(collision.gameObject.CompareTag("sped"))
        {
            moveSpeed *= 2f;
            Destroy(collision.gameObject);
            StartCoroutine(sped(5f));

        }
    }
    System.Collections.IEnumerator sped(float delay)
    {
        yield return new WaitForSeconds(delay);
        moveSpeed /= 2f;
    }
    
}

