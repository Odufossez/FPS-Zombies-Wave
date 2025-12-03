using UnityEngine;

public class Zombie_script : MonoBehaviour
{

    public float speed = 1;

    public float life = 100;
    
    public float damage = 1;

    public GameObject target;

    public  UnityEngine.AI.NavMeshAgent agent;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        target = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        agent.destination = target.transform.position;
    }

    private void OnCollisionEnter(Collision collision)
    {
        
    }
}
