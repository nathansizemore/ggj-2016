﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameOverScene : MonoBehaviour {

	// Use this for initialization
	void Start () {
	   Invoke("backHome", 4f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    
    void backHome(){
        SceneManager.LoadScene("StartScreen");
    }
}
