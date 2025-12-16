using UnityEngine;

public class NukeBooster : MonoBehaviour
{
    private PlayerController _playerController;
    private GameObject _zombie;
    private bool _isCollected = false;
    [SerializeField] private AudioClip _clip;
    private AudioSource _audioSource;
    

    public int nbZombie;
    public void OnCollected()
    {
        _playerController = gameObject.GetComponent<PlayerController>();
        _audioSource = gameObject.GetComponent<AudioSource>();
        _isCollected = true;
        nbZombie = 0;
        _audioSource.clip = _clip;
        _audioSource.Play();
    }

    public void Update()
    {
        if (_isCollected)
        {
            _zombie = GameObject.FindGameObjectWithTag("Zombie");
            if (_zombie != null)
            {
                //Debug.Log("Nuke Booster Activated: Destroying Zombie");
                Destroy(_zombie);
                nbZombie++;
            } else
            {
                //Debug.Log("No Zombie Found to Destroy");
                _playerController.zombiesKilled += nbZombie;
                _isCollected = false;
            }
        }
    
    }
}
