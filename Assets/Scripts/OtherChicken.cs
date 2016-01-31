using UnityEngine;

public class OtherChicken : MonoBehaviour 
{
    public float ChickenChangeInterval = 1.0f;
    
    public bool active = true;
    private float tSinceLastUpdate = 0;
    
	private NavMeshAgent navMeshAgent;
    private GameObject groundBoundsBox;
    
    
    private void Start()
    {
        navMeshAgent = this.gameObject.GetComponent<NavMeshAgent>();
        groundBoundsBox = GameObject.FindGameObjectWithTag("GroundBounds");
        
    }
    
    private void Update()
    {
        if (!active)
        {
            return;
        }
        
        tSinceLastUpdate += Time.deltaTime;
        if (tSinceLastUpdate > ChickenChangeInterval)
        {
            MoveChickenMove();
            tSinceLastUpdate = 0;
        }
    }
    
    private void MoveChickenMove()
    {
        Vector3 nextPos = FindNewPosition();
        
        // If walkable, return, else recurse
        NavMeshHit hit;
        bool blocked = NavMesh.Raycast(transform.position, nextPos, out hit, NavMesh.AllAreas);
		Debug.DrawLine(transform.position, nextPos, blocked ? Color.red : Color.green);
        
		if (blocked)
        {
            MoveChickenMove();
        }
        else
        {
            navMeshAgent.SetDestination(nextPos);
        }
    }
    
    private Vector3 FindNewPosition()
    {
        // Find a position within bounds
        Vector3 posWithinGrounds;
        posWithinGrounds = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f));
        posWithinGrounds = groundBoundsBox.transform.TransformPoint(posWithinGrounds * .5f);
        
        return posWithinGrounds;
    }
}
