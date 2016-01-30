using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public Text dayText;
    int currentDay;
    
	// Use this for initialization
	void Start () {
	   startGame();
	}
	
	// Update is called once per frame
	void Update () {
	   
	}
    
    void startGame(){
         nextRound();
    }
    
    void nextRound(){
        currentDay += 1;
        setDayText();
        // load next level
        
    }
    
    void setDayText(){
        dayText.text = "Day " + currentDay;
    }
}
