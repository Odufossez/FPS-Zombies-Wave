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
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {
            Upgrade();
        }
    }

    private void Upgrade()
    {
        if (_moneyAmount > 1500)
        {
            _DamageGun.Damage=_DamageGun.Damage*2;
            _Gun._magazineSize=_Gun._magazineSize*2;
            _moneyAmount-=1500;
        }
    }
}
