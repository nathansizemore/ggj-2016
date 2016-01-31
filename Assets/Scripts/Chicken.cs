using UnityEngine;

public class Chicken : MonoBehaviour {

	public float ChickenSpeed = 20.5f;
    
    public GameObject UpImageSet;
    public GameObject DownImageSet;
    public GameObject LeftImageSet;
    public GameObject RightImageSet;
    
    
    public SpriteRenderer UpSprite0;
    public SpriteRenderer UpSprite1;
    public SpriteRenderer DownSprite0;
    public SpriteRenderer DownSprite1;
    public SpriteRenderer LeftSprite0;
    public SpriteRenderer LeftSprite1;
    public SpriteRenderer RightSprite0;
    public SpriteRenderer RightSprite1;
    
    public AudioSource[] caughtSounds;
   
	GameController gc;
    
    
    public float SpriteSwapInterval = 0.150f; // Seconds
    private float tSinceLastSpriteSwap = 0;
    
    private enum Position
    {
        Up,
        Down,
        Left,
        Right
    };
    private uint currentSprite = 0;
    private Position currentFacingDirection;
    
	void Start()
    {
        gc = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        SwapSpriteUp();
    }
    
	void Update() 
	{
        this.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
		if (Input.GetKey(KeyCode.W)) 
		{
			MoveChickenUp();
		}
        else if (Input.GetKey(KeyCode.S))
        {
            MoveChickenDown();
        }
        else if (Input.GetKey(KeyCode.A))
        {
            MoveChickenLeft();
        }
        else if (Input.GetKey(KeyCode.D))
        {
            MoveChickenRight();
        }
        
        tSinceLastSpriteSwap += Time.deltaTime;
        if (tSinceLastSpriteSwap > SpriteSwapInterval)
        {
            SwapAnimationSprites();
            tSinceLastSpriteSwap = 0;
        }
	}
    
    private void OnCollisionEnter(Collision collision)
    {
        bool caught = collision.gameObject.CompareTag("Human");
        if (caught)
        {
            Debug.Log("caught");
            for (int i = 0; i < caughtSounds.Length; i++){
                caughtSounds[i].Play();
            }
           
            Invoke("StartGameOverScreen", .5f);
            //StartGameOverScreen();
        }
    }
    
    private void MoveChickenUp()
    {
        SwapSpriteUp();
        this.transform.rotation = Quaternion.Euler(0, 0, 0);
        this.transform.position += this.transform.forward * Time.deltaTime * ChickenSpeed;
    }
    
    private void MoveChickenDown()
    {
        SwapSpriteDown();
        this.transform.rotation = Quaternion.Euler(0, 180, 0);
        this.transform.position += this.transform.forward * Time.deltaTime * ChickenSpeed;
    }
    
    private void MoveChickenLeft()
    {
        SwapSpriteLeft();
        this.transform.rotation = Quaternion.Euler(0, 270, 0);
        this.transform.position += this.transform.forward * Time.deltaTime * ChickenSpeed;
    }
    
    private void MoveChickenRight()
    {
        SwapSpriteRight();
        this.transform.rotation = Quaternion.Euler(0, 90, 0);
        this.transform.position += this.transform.forward * Time.deltaTime * ChickenSpeed;
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
    
    private void SwapAnimationSprites()
    {
        switch (currentFacingDirection)
        {
            case Position.Up:
                {
                    if (currentSprite == 0)
                    {
                        UpSprite0.gameObject.SetActive(false);
                        UpSprite1.gameObject.SetActive(true);
                        currentSprite = 1;
                    }
                    else
                    {
                        UpSprite0.gameObject.SetActive(true);
                        UpSprite1.gameObject.SetActive(false);
                        currentSprite = 0;
                    }
                }
                break;
            case Position.Down:
                {
                    if (currentSprite == 0)
                    {
                        DownSprite0.gameObject.SetActive(false);
                        DownSprite1.gameObject.SetActive(true);
                        currentSprite = 1;
                    }
                    else
                    {
                        DownSprite0.gameObject.SetActive(true);
                        DownSprite1.gameObject.SetActive(false);
                        currentSprite = 0;
                    }
                }
                break;
            case Position.Left:
                {
                    if (currentSprite == 0)
                    {
                        LeftSprite0.gameObject.SetActive(false);
                        LeftSprite1.gameObject.SetActive(true);
                        currentSprite = 1;
                    }
                    else
                    {
                        LeftSprite0.gameObject.SetActive(true);
                        LeftSprite1.gameObject.SetActive(false);
                        currentSprite = 0;
                    }
                }
                break;
            case Position.Right:
                {
                    if (currentSprite == 0)
                    {
                        RightSprite0.gameObject.SetActive(false);
                        RightSprite1.gameObject.SetActive(true);
                        currentSprite = 1;
                    }
                    else
                    {
                        RightSprite0.gameObject.SetActive(true);
                        RightSprite1.gameObject.SetActive(false);
                        currentSprite = 0;
                    }
                }
                break;
        }
    }
    
    private void StartGameOverScreen()
    {
         Destroy(this.gameObject);
        gc.gameOver();
    }
}
