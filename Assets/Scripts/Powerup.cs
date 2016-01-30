using UnityEngine;
using System.Collections;

public class Powerup : MonoBehaviour {

    public enum PowerupType{ Speed, Poop }
    public PowerupType type;
    
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    
    public string getDisplayText(){
        string returnString = "";
        switch (type){
            case PowerupType.Speed:
                returnString = "Speed";
            break;
            case PowerupType.Poop:
                returnString = "Poop";
            break;
            
        }
      return returnString;
    }
}
