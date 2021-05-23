using UnityEngine;

public class Follow_the_path : MonoBehaviour
{
    public Transform[] waypoints; //prendo le posizioni delle caselle dai waypoints
    public GameObject dice; //prendo valori del dado

    [HideInInspector]
    public int waypointIndex = 0;


    // Start is called before the first frame update
    private void Start()
    {
        transform.position = waypoints[waypointIndex].position; //posiziono le caselle nel punto del primo waypoint
    }

    public void Move()
    {
        waypointIndex += dice.GetComponent<Dice>().numberExtracted; //rendo la variabile waypointindex uguale al suo valore iniziale aumentato del valore uscito dal dado
        if(waypointIndex >= waypoints.Length)
        {
            waypointIndex = waypointIndex - waypoints.Length;
        }
        gameObject.transform.position = waypoints[waypointIndex].position; //cambio posizione x e y
        gameObject.transform.position = new Vector3(transform.position.x, transform.position.y, 6f); //rendo predefinita la posizione z pari a 6
    }
}
