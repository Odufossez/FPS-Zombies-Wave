using TMPro;
using UnityEngine;

public class PaP : MonoBehaviour
{
    public int _moneyAmount;
    public int _GunLevel;
    public Gun _Gun;
    public DamageGun _DamageGun;
    public TMP_Text _moneyTxt;
    public TMP_Text _GunLevelTxt;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _moneyAmount = 0;
        _GunLevel=1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {
            Upgrade();
        }
        _moneyTxt.text = _moneyAmount+" $";
        _GunLevelTxt.text = _GunLevel+"";
    }

    private void Upgrade()
    {
        if (_moneyAmount > 1500)
        {
            _DamageGun.Damage *= 2;
            _Gun._magazineSize*=2;
            _Gun.CurrentCooldown *=0.75f;
            _moneyAmount-=1500;
            _GunLevel+=1;
        }
    }
}
