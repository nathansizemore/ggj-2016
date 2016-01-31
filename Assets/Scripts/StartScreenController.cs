using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class StartScreenController : MonoBehaviour {

    public Animator fadeOutAnimator;
    
    bool fadingOut = false;
	// Use this for initialization
	void Start () {
	
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
