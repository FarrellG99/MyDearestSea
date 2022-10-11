using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class CharacterAiming : MonoBehaviour
{
    public float turnSpeed = 15;
    public float yawCamera;
    public bool lockCamera;
    public Camera mainCamera;

    public Rig aimLayer;
    public float aimDuration = 0.3f;

    

    void Start()
    {
        
        
    }

    private void LateUpdate()
    {
        if(aimLayer)
        {
            //if (Input.GetButton("Fire2"))
            //{
            //    aimLayer.weight += Time.deltaTime / aimDuration;
            //}
            //else
            //{
            //    aimLayer.weight -= Time.deltaTime / aimDuration;
            //}
            aimLayer.weight = 1.0f;
        }

       
        
    }

    void FixedUpdate()
    {
        
        yawCamera = mainCamera.transform.rotation.eulerAngles.y;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, yawCamera, 0), turnSpeed * Time.fixedDeltaTime);
        //if (lockCamera == true)
        //{
        //    Cursor.visible = false;
        //    Cursor.lockState = CursorLockMode.Locked;
        //}else
        //{
        //    Cursor.visible = true;
           
        //}
       
    }
}
