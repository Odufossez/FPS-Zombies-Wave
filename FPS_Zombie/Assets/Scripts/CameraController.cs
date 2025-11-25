using UnityEngine;

public class CameraController : MonoBehaviour
{
    private float rotationSpeed = 5f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(-rotationSpeed * Input.GetAxis("Mouse Y"),0 , 0);

        if(transform.rotation.eulerAngles.x > 81)
        {
            transform.rotation = Quaternion.Euler(new Vector3(80,transform.rotation.eulerAngles.y,0));
        }
        if(transform.rotation.eulerAngles.x < -20)
        {
            transform.rotation = Quaternion.Euler(new Vector3(-20,transform.rotation.eulerAngles.y,0));
        }
    }
}
