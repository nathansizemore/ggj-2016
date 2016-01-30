using UnityEngine;
using System.Collections;

public class LevelController : MonoBehaviour {

    public Transform[] enemySpawns;
    
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    
    public void begin(){
        // create and position all powerups, catchers, etc.
        for (int i = 0; i < enemySpawns.Length; i++){
            
            // instantiate and position enemies
            
        }
    }
}
