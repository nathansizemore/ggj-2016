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
    
    public Countdown countdown;
    
    public DayCompleteOverlay dayCompleteOverlay;
    
    public GameObject BackgroundMusicGo;
	// Use this for initialization
	void Start () {
       SceneManager.UnloadScene(1);
       chicken = GameObject.FindGameObjectWithTag("Chicken").GetComponent<Chicken>();
	   startGame();
       GameObject backgroundController = GameObject.FindGameObjectWithTag("BackgroundMusic");
       if (backgroundController == null){
           backgroundController = GameController.Instantiate(BackgroundMusicGo, Vector3.zero, Quaternion.identity) as GameObject;
       }
       backgroundController.GetComponent<BackgroundMusicController>().playInGame();
       
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
    
    public void nextRound(){
        currentDay += 1;
        if (currentDay > 7){
            gameOverWin();
        }else{
            setDayText();
            StartCoroutine(LoadNextLevel());
        }
       
    }
    
    // public void setQueuedPowerup(Powerup p){
    //     queuedPowerup = p;
    //     if (p != null){
    //         powerupText.text = p.getDisplayText();
    //     }else{
    //         powerupText.text = "None";
    //     }
        
    // }
    
    void setDayText(){
        dayText.text = "Day " + currentDay;
    }
    
    public void usePowerup(){
        // if global thing, do here 
        
        // cleanup
        //setQueuedPowerup(null);    
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
        if (currentDay > 1){
            showDayComplete();
        }else{
            startDay(); 
        }
      
    }
    
    
    
    void startDay(){
        GameObject spawnPoint = GameObject.FindGameObjectWithTag("SpawnPoint");
        if (spawnPoint != null){
            chicken.gameObject.transform.position =spawnPoint.transform.position;
            chicken.gameObject.transform.rotation = spawnPoint.transform.rotation;
       }
       
       countdown.OnElapsed += HandleCountdownElapsed;
       countdown.startCountdown();
       // lvlController.begin();
        
    }
 
    void HandleCountdownElapsed(){
        Debug.Log("elapsed");
        lvlController.begin();
    } 
    
    public void showDayComplete(){
        dayCompleteOverlay.showDayComplete(currentDay - 1);
        Invoke("startDay", 3f);
    }
    
    public void gameOver(){
        SceneManager.LoadScene("GameOver");
    }
    
    public void gameOverWin(){
         SceneManager.LoadScene("GameOverWin");
    }
}
