﻿using UnityEngine;

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
          
        // create and position all powerups, catchers, etc.
        for (int i = 0; i < enemies.Length; i++)
        {
            enemies[i].GetComponent<Human>().active = true;
        }
    }
}
