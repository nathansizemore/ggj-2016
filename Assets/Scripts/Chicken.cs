using UnityEngine;

public class Chicken : MonoBehaviour {

	public float ChickenSpeed = 20.5f;
    
    public SpriteRenderer UpSprite;
    public SpriteRenderer DownSprite;
    public SpriteRenderer LeftSprite;
    public SpriteRenderer RightSprite;
   
	GameController gc;
    
	void Start()
    {
        gc = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        SwapSpriteUp();
    }
    
	void Update() 
	{
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
        
        if (Input.GetButtonDown("Fire1"))
        {
            usePowerup();
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
    
      
    void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Powerup")
        {
             gc.setQueuedPowerup(other.gameObject.GetComponent<Powerup>());
        }
        Destroy(other.gameObject);
    }
    
    void usePowerup(){
        // use it here
        
        
        // clean it up
        gc.setQueuedPowerup(null);
        
    }
    
    private void SwapSpriteUp()
    {
        UpSprite.gameObject.SetActive(true);
        
        DownSprite.gameObject.SetActive(false);
        LeftSprite.gameObject.SetActive(false);
        RightSprite.gameObject.SetActive(false);
    }
    
    private void SwapSpriteDown()
    {
        DownSprite.gameObject.SetActive(true);
        
        UpSprite.gameObject.SetActive(false);        
        LeftSprite.gameObject.SetActive(false);
        RightSprite.gameObject.SetActive(false);
    }
    
    private void SwapSpriteLeft()
    {
        LeftSprite.gameObject.SetActive(true);
        
        UpSprite.gameObject.SetActive(false);
        DownSprite.gameObject.SetActive(false);        
        RightSprite.gameObject.SetActive(false);
    }
    
    private void SwapSpriteRight()
    {
        RightSprite.gameObject.SetActive(true);
        
        UpSprite.gameObject.SetActive(false);
        DownSprite.gameObject.SetActive(false);
        LeftSprite.gameObject.SetActive(false);
    }
}
