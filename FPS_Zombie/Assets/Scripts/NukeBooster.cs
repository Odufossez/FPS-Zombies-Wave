using UnityEngine;

public class NukeBooster : MonoBehaviour
{

    private GameObject _zombie;
    private bool _isCollected = false;
    public void OnCollected()
    {
        _isCollected = true;
    }

    public void Update()
    {
        if (_isCollected)
        {
            _zombie = GameObject.FindGameObjectWithTag("Zombie");
            if (_zombie != null)
            {
                Debug.Log("Nuke Booster Activated: Destroying Zombie");
                Destroy(_zombie);
            } else
            {
                Debug.Log("No Zombie Found to Destroy");
                _isCollected = false;
            }
        }
    
    }
}
