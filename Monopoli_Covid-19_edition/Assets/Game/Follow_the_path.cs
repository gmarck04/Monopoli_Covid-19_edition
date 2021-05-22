using UnityEngine;

public class Follow_the_path : MonoBehaviour
{
    public Transform[] waypoints;
    public GameObject dice;

    [HideInInspector]
    public int waypointIndex = 0;


    // Start is called before the first frame update
    private void Start()
    {
        transform.position = waypoints[waypointIndex].position;
    }

    public void Move()
    {
        waypointIndex += dice.GetComponent<Dice>().numberExtracted;
        if(waypointIndex >= waypoints.Length)
        {
            waypointIndex = waypointIndex - waypoints.Length;
        }
        gameObject.transform.position = waypoints[waypointIndex].position;
        gameObject.transform.position = new Vector3(transform.position.x, transform.position.y, 6f);
    }
}
