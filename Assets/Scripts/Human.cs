using UnityEngine;

public class Human : MonoBehaviour 
{
    
    private NavMeshAgent navMeshAgent;
    public float ChaseInterval = 3f;
    private float tSinceLastChickenTarget = 0f;
    private GameObject[] chickens;
    
    public bool active = false;
    
    private void Start()
    {
        navMeshAgent = this.gameObject.GetComponent<NavMeshAgent>();
        chickens = GameObject.FindGameObjectsWithTag("Chicken");
    }

    private void Update()
    {
        if (!active) return;
        
        tSinceLastChickenTarget += Time.deltaTime;
        if (tSinceLastChickenTarget > ChaseInterval)
        {
            UpdateChickenTarget();
            tSinceLastChickenTarget = 0f;
        }
    }    
    
    private void UpdateChickenTarget()
    {
        int nextChicken = Random.Range(0, chickens.Length - 1);
        navMeshAgent.SetDestination(chickens[nextChicken].transform.position);
    }	
}
