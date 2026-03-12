using UnityEngine;

public class WaypointFollower : MonoBehaviour
{
    public GameObject[] waypoints; 
    
    public float speed = 5f; 
    private int currentWaypointIndex = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (waypoints != null && waypoints.Length > 0 && currentWaypointIndex < waypoints.Length)
        {
            
            Vector3 targetPosition = waypoints[currentWaypointIndex].transform.position;
            
            
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
            
            
            if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
            {
                
                currentWaypointIndex++;
                
               
                if (currentWaypointIndex >= waypoints.Length)
                {
                    currentWaypointIndex = 0; 
                }
            }
        }
        waypoints = GameObject.FindGameObjectsWithTag("Waypoint");
    }
}
