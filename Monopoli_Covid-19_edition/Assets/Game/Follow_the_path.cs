using UnityEngine;

public class Follow_the_path : MonoBehaviour
{
    public Transform[] waypoints;
    public GameObject dice;

    [SerializeField]
    private float moveSpeed = 1f;

    [HideInInspector]
    public int waypointIndex = 0;

    //public bool moveAllowed = false;

    // Start is called before the first frame update
    private void Start()
    {
        transform.position = waypoints[waypointIndex].position;
    }

    // Update is called once per frame
    private void Update()
    {
        //if (moveAllowed == true)
        //{
        //    Move();
        //}            
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
