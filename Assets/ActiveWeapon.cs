using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor.Animations;
#endif



public class ActiveWeapon : MonoBehaviour
{
    public Transform crossHitTarget;
    RaycastWeapon weapon;
    
    public Transform weaponParent;
    public Transform weaponLeftGrip;
    public Transform WeaponRightGrip;
    public UnityEngine.Animations.Rigging.Rig hankIK;

    public Animator rigController;
   
    void Start()
    {
      
        
        RaycastWeapon existingWeapon = GetComponentInChildren<RaycastWeapon>();
        
        if (existingWeapon)
        {
           
            Equip(existingWeapon);
        }
       
    }

    // Update is called once per frame
    void Update()
    {
        if(weapon)
        {
            hankIK.weight = 1.0f;
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
            if (weapon.tag == "FilterAir" )
            {
                hankIK.weight = 0.0f;
            }
        }
       
        
     
    }

    public void Equip(RaycastWeapon newWepaon)
    {
        if(weapon)
        {
            Destroy(weapon.gameObject);
        }
        weapon = newWepaon;
        weapon.raycastDestination = crossHitTarget;
        weapon.transform.parent = weaponParent;
        weapon.transform.localPosition = Vector3.zero;
        weapon.transform.localRotation = Quaternion.identity;
        rigController.Play("equip_" + weapon.weaponName);
       
    }

   
   


}
