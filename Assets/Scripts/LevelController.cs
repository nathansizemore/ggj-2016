using UnityEngine;
using System.Collections;

public class LevelController : MonoBehaviour {

    public GameObject[] enemies;
    public GameObject[] chickens;
    
// DON"T USE START

	// Update is called once per frame
	void Update () {
	
	}
    
    public void begin()
    {
        enemies = GameObject.FindGameObjectsWithTag("Human");
        chickens = GameObject.FindGameObjectsWithTag("Chicken");
          
        // create and position all powerups, catchers, etc.
        for (int i = 0; i < enemies.Length; i++)
        {
            enemies[i].GetComponent<Human>().active = true;
        }
        
        for (int x = 0; x < chickens.Length; x++)
        {
            chickens[x].GetComponent<OtherChicken>().active = true;
        }
    }
}
