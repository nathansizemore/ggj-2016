using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
  
public class GameController : MonoBehaviour {

    public Text dayText;
    int currentDay;
    Scene activeLevelScene;
    
    
	// Use this for initialization
	void Start () {
	   startGame();
	}
	
	// Update is called once per frame
	void Update () {
	   if (Input.GetKeyDown(KeyCode.Space)){
           nextRound();
       }
	}
    
    void startGame(){
         nextRound();
    }
    
    void nextRound(){
        currentDay += 1;
        setDayText();
        // load next level
        StartCoroutine(LoadNextLevel());
    }
    
    void setDayText(){
        dayText.text = "Day " + currentDay;
    }
    
    IEnumerator LoadNextLevel() {
        AsyncOperation async = SceneManager.LoadSceneAsync("Level" + currentDay, LoadSceneMode.Additive);
        yield return async;
        if (activeLevelScene != null){
            SceneManager.UnloadScene(activeLevelScene.name);
        }
       activeLevelScene = SceneManager.GetSceneAt(1);
       
    }
    
}
