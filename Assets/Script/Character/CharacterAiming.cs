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
    
    public float aimDuration = 0.3f;

    RaycastWeapon weapon;
    

    void Start()
    {
        weapon = GetComponentInChildren<RaycastWeapon>();
        
    }

    private void LateUpdate()
    {
        if (weapon)
        {
            
            if (weapon.tag == "Gun" && Input.GetButtonDown("Fire1"))
            {
                weapon.StartFiring();
            }

            if (weapon.tag == "Gun" && weapon.isFiring)
            {
                weapon.UpdateFiring(Time.deltaTime);
            }
            weapon.UpdateBullet(Time.deltaTime);
            if (weapon.tag == "Gun" && Input.GetButtonUp("Fire1"))
            {
                weapon.StopFiring();
            }

            if (weapon.tag == "Sapu" && Input.GetButtonDown("Fire1"))
            {
                Debug.Log("Kali 2");
            }
            if (weapon.tag == "FilterAir")
            {
               
            }
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
