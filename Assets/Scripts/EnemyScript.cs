using UnityEngine;

public class EnemyScript : MonoBehaviour
{

    public float enemySpeed = 5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.up * enemySpeed * Time.deltaTime);    
    }
}
