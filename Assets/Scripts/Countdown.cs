using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Countdown : MonoBehaviour {

    public delegate void Elapsed();
    public event Elapsed OnElapsed;
    
    Animator anim;
    public Text cText;
    int currentCount = 3;
    
	// Use this for initialization
	void Start () {
	   anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    
    public void startCountdown(){
        
        anim.SetTrigger("start");
        cText.text = "3";
        Invoke("tick", 1f);
    }
    
    void tick(){
        Debug.Log("tick");
        currentCount -=1;
        if (currentCount < 0){
            if (OnElapsed != null){
                OnElapsed();
            }
            this.gameObject.SetActive(false);
               
        }else{
            cText.text = currentCount.ToString();
            Invoke("tick", 1f);
        }
    }
    
}
