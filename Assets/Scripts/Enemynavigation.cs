using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Rendering;

public class enemynavigation : MonoBehaviour
{
    // Start is called once before th
    [SerializeField] private Transform target;
    [SerializeField] private Transform target2;
    NavMeshAgent agent;
    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
 void Update()
{
    

    float avoidRadius = 60f; 
    float destroyRadius = 1.5f; 

    Vector3 toPlayer = target.position - transform.position;
    Vector3 toPlayer2 = target2.position - transform.position;
    float dist = toPlayer.magnitude;
    float dist2 = toPlayer2.magnitude;

    if (dist < destroyRadius || dist2 < destroyRadius)
    {
        Destroy(gameObject);
        return;
    }

    if (dist < avoidRadius || dist2 < avoidRadius)
    {
        Vector3 away = Vector3.zero;
        
        if (dist < avoidRadius)
        {
            away += (transform.position - target.position).normalized;
        }
        if (dist2 < avoidRadius)
        {
            away += (transform.position - target2.position).normalized;
        }
        
        away = away.normalized;
        Vector3 escapePoint = transform.position + away * 10f;
        NavMeshHit hit;
        if (NavMesh.SamplePosition(escapePoint, out hit, 5f, NavMesh.AllAreas))
        {
            agent.SetDestination(hit.position);
        }
        else
        {
            agent.SetDestination(transform.position - away * 5f);
            
        }
        
    
    }
  
}
}