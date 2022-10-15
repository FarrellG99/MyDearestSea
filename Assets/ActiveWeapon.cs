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
        rigController.updateMode = AnimatorUpdateMode.AnimatePhysics;

        rigController.cullingMode = AnimatorCullingMode.CullUpdateTransforms;

        rigController.cullingMode = AnimatorCullingMode.AlwaysAnimate;

        rigController.updateMode = AnimatorUpdateMode.Normal;

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
            if( Input.GetKeyDown(KeyCode.X))
                {
                bool isHoster = rigController.GetBool("hoster_pistol");
                rigController.SetBool("hoster_pistol", !isHoster); 
            }

            if (weapon.tag == "Sapu" && Input.GetButtonDown("Fire1"))
            {
                Debug.Log("Kali 2");
            }
            if (weapon.tag == "FilterAir" )
            {
                
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
