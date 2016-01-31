﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class StartScreenController : MonoBehaviour {

    public Animator fadeOutAnimator;
    
    bool fadingOut = false;
    
    public GameObject BackgroundMusicGO;
    
	// Use this for initialization
	void Start () {
	   GameObject backgroundController = GameObject.FindGameObjectWithTag("BackgroundMusic");
       if (backgroundController == null){
           backgroundController = GameController.Instantiate(BackgroundMusicGO, Vector3.zero, Quaternion.identity) as GameObject;
       }
	}
	
	// Update is called once per frame
	void Update () {
	   if (Input.GetButtonDown("Fire1") && !fadingOut){
           startFadeOut();
       }
	}
    
    void startFadeOut(){
        fadingOut = true;
        fadeOutAnimator.SetTrigger("Fade");
        Invoke("doneFading", 1f);
    }
    
    void doneFading(){
        SceneManager.LoadScene("Final");
    }
    
    
}
