﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class StartScreenController : MonoBehaviour {

    public Animator fadeOutAnimator;
    public GameObject Image1;
    public GameObject Image2;
    
    bool fadingOut = false;
    
    bool onSecondStory = false;
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
            bool startScreen = this.gameObject.CompareTag("Start");
            if (startScreen)
            {
                Invoke("doneFading", 1f);
            }
            else
            {
                if (onSecondStory) {
                    startFadeOut();
                } else {
                    Image1.SetActive(false);
                    Image2.SetActive(true);
                    onSecondStory = true;
                }
            }
       }
	}
    
    void startFadeOut(){
        fadingOut = true;
        fadeOutAnimator.SetTrigger("Fade");
        Invoke("doneFading", 1f);
    }
    
    void doneFading(){
        bool startScreen = this.gameObject.CompareTag("Start");
        if (startScreen)
        {
            SceneManager.LoadScene("Story");
        }
        else
        {
            SceneManager.LoadScene("Final");
        }
    }
    
    
}
