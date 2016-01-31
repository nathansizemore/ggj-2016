using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DayCompleteOverlay : MonoBehaviour {

    public Text dayCompleteText;
    
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    
    public void showDayComplete(int day){
        dayCompleteText.text = "Day " + day + " complete";
        this.gameObject.SetActive(true);
        Invoke("hideDayComplete", 3f);
    }
    
    public void hideDayComplete(){
        this.gameObject.SetActive(false);
    }
}
