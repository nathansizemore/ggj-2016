using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
  
public class GameController : MonoBehaviour {

    public Text dayText;
    int currentDay;
    Scene activeLevelScene;
    
    Chicken chicken;
    
    Powerup queuedPowerup;
    
    LevelController lvlController;
    
    public Text powerupText;
    
	// Use this for initialization
	void Start () {
          SceneManager.UnloadScene(1);
       chicken = GameObject.FindGameObjectWithTag("Chicken").GetComponent<Chicken>();
	   startGame();
        
	}
	
	// Update is called once per frame
	void Update () {
	   if (Input.GetKeyDown(KeyCode.Space)){
         //  nextRound();
       }
	}
    
    void startGame(){
         nextRound();
    }
    
    void nextRound(){
        currentDay += 1;
        setDayText();
        StartCoroutine(LoadNextLevel());
    }
    
    public void setQueuedPowerup(Powerup p){
        queuedPowerup = p;
        if (p != null){
            powerupText.text = p.getDisplayText();
        }else{
            powerupText.text = "None";
        }
        
    }
    
    void setDayText(){
        dayText.text = "Day " + currentDay;
    }
    
    public void usePowerup(){
        // if global thing, do here 
        
        // cleanup
        setQueuedPowerup(null);    
    }
    
    IEnumerator LoadNextLevel() {
        AsyncOperation async = SceneManager.LoadSceneAsync("Level" + currentDay, LoadSceneMode.Additive);
        yield return async;
        if (activeLevelScene != null){
            SceneManager.UnloadScene(activeLevelScene.name);
        }
       activeLevelScene = SceneManager.GetSceneAt(1); 
       lvlController = GameObject.FindGameObjectWithTag("LevelGeometry").GetComponent<LevelController>();
       
       // call transition, after transition call start day
       
       
       // HOLD this
       startDay();
    }
    
    void startDay(){
        GameObject spawnPoint = GameObject.FindGameObjectWithTag("SpawnPoint");
        chicken.gameObject.transform.position =spawnPoint.transform.position;
        chicken.gameObject.transform.rotation = spawnPoint.transform.rotation;
        
        lvlController.begin();
        
    }
  
}
