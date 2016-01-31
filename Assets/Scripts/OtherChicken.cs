using UnityEngine;

public class OtherChicken : MonoBehaviour 
{    
    public GameObject UpImageSet;
    public GameObject DownImageSet;
    public GameObject LeftImageSet;
    public GameObject RightImageSet;
    
    private float tSinceLastDestination = 0f;
    private float DestinationChangeInterval = 3f;
    
    public AudioSource cluck;
    
    private GameController gc;
    
    private enum Position
    {
        Up,
        Down,
        Left,
        Right
    };
    
    private Position currentFacingDirection;
    
    private NavMeshAgent navMeshAgent;
    private GameObject groundBoundsBox;
    public bool active = false;
    
	void Start()
    {
        gc = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        navMeshAgent = this.gameObject.GetComponent<NavMeshAgent>();
        groundBoundsBox = GameObject.FindGameObjectWithTag("GroundBounds");
        SwapSpriteUp();
    }
    
	void Update() 
	{
        if (!active)
        {
            return;
        }
        
        tSinceLastDestination += Time.deltaTime;
        if (tSinceLastDestination > DestinationChangeInterval)
        {
            MoveToNewDestination();
            tSinceLastDestination = 0f;
        }
        
        AdjustSpritesBasedOnAngle();
	}
    
    private void OnCollisionEnter(Collision collision)
    {
        bool caught = collision.gameObject.CompareTag("Human");
        if (caught)
        {
           cluck.Play();
           Invoke("killChicken", .5f);
        }
    }
    
    void killChicken(){
        Destroy(this.gameObject);
        gc.nextRound();
    }
    
    private void SwapSpriteUp()
    {
        UpImageSet.gameObject.SetActive(true);
        
        DownImageSet.gameObject.SetActive(false);
        LeftImageSet.gameObject.SetActive(false);
        RightImageSet.gameObject.SetActive(false);
        
        currentFacingDirection = Position.Up;
    }
    
    private void SwapSpriteDown()
    {
        DownImageSet.gameObject.SetActive(true);
        
        UpImageSet.gameObject.SetActive(false);
        LeftImageSet.gameObject.SetActive(false);
        RightImageSet.gameObject.SetActive(false);
        
        currentFacingDirection = Position.Down;
    }
    
    private void SwapSpriteLeft()
    {
        LeftImageSet.gameObject.SetActive(true);
        
        DownImageSet.gameObject.SetActive(false);
        UpImageSet.gameObject.SetActive(false);
        RightImageSet.gameObject.SetActive(false);
        
        currentFacingDirection = Position.Left;
    }
    
    private void SwapSpriteRight()
    {
        RightImageSet.gameObject.SetActive(true);
        
        DownImageSet.gameObject.SetActive(false);
        LeftImageSet.gameObject.SetActive(false);
        UpImageSet.gameObject.SetActive(false);
        
        currentFacingDirection = Position.Right;
    }
    
    private void MoveToNewDestination()
    {
        Vector3 nextPos = FindNewPosition();
        
        // If walkable, return, else recurse
        NavMeshHit hit;
        bool blocked = NavMesh.Raycast(transform.position, nextPos, out hit, NavMesh.AllAreas);
		//Debug.DrawLine(transform.position, nextPos, blocked ? Color.red : Color.green);
        
		if (blocked)
        {
            MoveToNewDestination();
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
    
    private void AdjustSpritesBasedOnAngle()
    {
        float currentAngle = this.gameObject.transform.rotation.eulerAngles.y;
        if (currentAngle < 90)
        {
            currentFacingDirection = Position.Up;
            SwapSpriteUp();
        }
        else if (currentAngle < 180)
        {
            currentFacingDirection = Position.Right;
            SwapSpriteRight();
        }
        else if (currentAngle < 270)
        {
            currentFacingDirection = Position.Down;
            SwapSpriteDown();
        }
        else if (currentAngle < 360)
        {
            currentFacingDirection = Position.Left;
            SwapSpriteLeft();
        }
    }
}
