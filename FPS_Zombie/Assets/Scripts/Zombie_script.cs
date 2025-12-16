using UnityEngine;

public class Zombie_script : MonoBehaviour
{
    private PlayerController _playerController;
    private PaP _PaP;
    private float count= 0f;

    public float life = 100;
    
    public float damage = 1;

    public GameObject target;
    
    private AudioSource audioSourceNoot;
   [SerializeField] private AudioClip clipNoot;

    public  UnityEngine.AI.NavMeshAgent agent;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        count = 0;
        _playerController = GameObject.FindFirstObjectByType(typeof(PlayerController)) as PlayerController;
        if(_playerController == null) Debug.LogError("PlayerController not found");
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        target = GameObject.FindGameObjectWithTag("Player");
        audioSourceNoot = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        agent.destination = target.transform.position;
        count += Time.deltaTime;
        // Debug.Log(life);
        if (life <= 0f)
        {
            _playerController.zombiesKilled++;
            _PaP._moneyAmount +=90;
            AudioSource.PlayClipAtPoint(clipNoot, transform.position);
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player" && count >= 1.5f)
        {
            count = 0;
            _playerController.TakeHit(damage);
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Player" && count >= 1.5f)
        {
            count = 0;
            _playerController.TakeHit(damage);
        }
    }
}
