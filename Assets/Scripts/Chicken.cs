using UnityEngine;

public class Chicken : MonoBehaviour {

	public float ChickenSpeed = 20.5f;
	
	
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
}
