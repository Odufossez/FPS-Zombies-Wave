using UnityEngine.Events;
using UnityEngine;
using TMPro;

public class Gun : MonoBehaviour
{
    public UnityEvent OnGunShoot;
    public float FireCooldown;
    public bool Automatic;
    public int _bulletLeft;
    public int _magazineSize;
    public float _reloadCooldown;     
    public float _reloadTimer;
    private float CurrentCooldown;
    public TMP_Text bulletTXT;
    public bool _canShoot;
    // public int magazine_capacity;
    // public int magazine_;
    [SerializeField] private AudioClip shootSound; //piou
    [SerializeField] private AudioClip emptyMagSound; //clic
    
    private AudioSource _audioSourceClic;
    private AudioSource _audioSourcePiou;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        CurrentCooldown = FireCooldown;
        _magazineSize = 17;
        _bulletLeft = _magazineSize;
        _reloadCooldown = 1.5f;
        _canShoot = true;
        _audioSourcePiou = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            _canShoot=false;
            _reloadTimer = _reloadCooldown;
            
        }
        if (_canShoot == false)
        {
            if (_reloadTimer > 0f)
            {
                _reloadTimer-=Time.deltaTime;
            } else
            {
                _bulletLeft=_magazineSize;
                _canShoot=true;
            }
        }
        bulletTXT.text = _bulletLeft +" / "+_magazineSize;
        // if(Input.GetButtonDown(KeyCode("R")))
        if (Automatic)
        {
            if (Input.GetMouseButton(0) && _bulletLeft>0 && _canShoot==true)
            {
                // Debug.Log("coucou");
                if (CurrentCooldown <= 0f)
                {
                    _audioSourcePiou.clip = shootSound;
                    _audioSourcePiou.Play();
                    OnGunShoot?.Invoke();
                    _bulletLeft-=1;
                    CurrentCooldown = FireCooldown;
                }
            }
        }
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (CurrentCooldown <= 0f)
                {
                    _audioSourcePiou.clip = shootSound;
                    _audioSourcePiou.Play();
                    OnGunShoot?.Invoke();
                    _bulletLeft-=1;
                    CurrentCooldown = FireCooldown;
                }
            }
        }

        CurrentCooldown -= Time.deltaTime;
    }
    
}
