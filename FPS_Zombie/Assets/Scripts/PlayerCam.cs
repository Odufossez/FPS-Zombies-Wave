using System;
using UnityEngine;

public class PlayerCam : MonoBehaviour
{
    public float sensX=400f;
    public float sensY=400f;
    public Transform player;
    float xRotation;
    float yRotation;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.fixedDeltaTime * sensX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.fixedDeltaTime * sensY;
        yRotation += mouseX;
        xRotation -= mouseY;
        xRotation = Math.Clamp(xRotation, -80f,80f);
        
        transform.rotation = Quaternion.Euler(xRotation,yRotation,0);
        // transform.localEulerAngles = new Vector3(xRotation,yRotation,0);
        player.rotation = Quaternion.Euler(0, yRotation,0);
    }
}
