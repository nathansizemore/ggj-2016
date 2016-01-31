using UnityEngine;

public class ChickenSpriteSwap : MonoBehaviour 
{
    
    public GameObject Sprite1;
    public GameObject Sprite2;
    
    private float switchInterval = 0.15f;
    private float tSinceLastSwitch = 0;
    
    private int currentSprite = 0;
    
    private Quaternion startingRotation;
    
    private void Start()
    {
        startingRotation = this.gameObject.transform.rotation;
    }
    
    private void Update()
    {
        tSinceLastSwitch += Time.deltaTime;
        if (tSinceLastSwitch > switchInterval)
        {
            SwitchSprites();
            tSinceLastSwitch = 0;
        }
        
        this.gameObject.transform.rotation = startingRotation;
    }
    
    private void SwitchSprites()
    {
        if (currentSprite == 0)
        {
            Sprite1.SetActive(false);
            Sprite2.SetActive(true);
            currentSprite = 1;
        }
        else
        {
            Sprite1.SetActive(true);
            Sprite2.SetActive(false);
            currentSprite = 0;
        }
    }
}