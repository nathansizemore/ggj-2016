using UnityEngine;
using System.Collections;

public class BackgroundMusicController : MonoBehaviour {

    public AudioSource source;
    
    public AudioClip startGame;
    public AudioClip inGame;
    
	// Use this for initialization
	void Start () {
       DontDestroyOnLoad(this.gameObject);
	  // source = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    
    public void playStartGame(){
        source.clip = startGame;
        source.Play();
    }
    
    public void playInGame(){
        source.clip = inGame;
        source.Play();
        Debug.Log("playign in game");
    }
}
