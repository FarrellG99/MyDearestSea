using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAiming : MonoBehaviour
{
    public float turnSpeed = 15;
    public float yawCamera;
    public bool lockCamera;
    public Camera mainCamera;
    void Start()
    {
       
        
    }

     void FixedUpdate()
    {
        
        yawCamera = mainCamera.transform.rotation.eulerAngles.y;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, yawCamera, 0), turnSpeed * Time.fixedDeltaTime);
        if (lockCamera == true)
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }else
        {
            Cursor.visible = true;
           
        }
       
    }
}
