using UnityEngine;

public class Chicken : MonoBehaviour {

	public float ChickenSpeed = 20.5f;
	GameController gc;
    
	void Start(){
        gc = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
       
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
        
        if (Input.GetButtonDown("Fire1")){
            usePowerup();
        }
	}
    
    private void MoveChickenUp()
    {
        this.transform.rotation = Quaternion.Euler(0, 0, 0);
        this.transform.position += this.transform.forward * Time.deltaTime * ChickenSpeed;
    }
    
    private void MoveChickenDown()
    {
        this.transform.rotation = Quaternion.Euler(0, 180, 0);
        this.transform.position += this.transform.forward * Time.deltaTime * ChickenSpeed;
    }
    
    private void MoveChickenLeft()
    {
        this.transform.rotation = Quaternion.Euler(0, 270, 0);
        this.transform.position += this.transform.forward * Time.deltaTime * ChickenSpeed;
    }
    
    private void MoveChickenRight()
    {
        this.transform.rotation = Quaternion.Euler(0, 90, 0);
        this.transform.position += this.transform.forward * Time.deltaTime * ChickenSpeed;
    }
    
      
    void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Powerup"){
             gc.setQueuedPowerup(other.gameObject.GetComponent<Powerup>());
        }
        Destroy(other.gameObject);
    }
    
    void usePowerup(){
        // use it here
        
        
        // clean it up
        gc.setQueuedPowerup(null);
        
    }
    
}
