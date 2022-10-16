using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor.Animations;
#endif



public class ActiveWeapon : MonoBehaviour
{
    public enum WeaponSlot
    {
        Gun = 0,
        Sapu = 1,
        Filter = 2
    }
    public Transform crossHitTarget;
    RaycastWeapon[] Equipweapon = new RaycastWeapon[3];
    int activeWeaponIndex;
    
    public Transform[] weaponSlot;
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



    RaycastWeapon GetWeapon(int index)
    {
        if(index < 0 || index >= Equipweapon.Length)
        {
            return null;
        }
        return Equipweapon[index];
    }

    // Update is called once per frame
    void Update()
    {
        var weapon = GetWeapon(activeWeaponIndex);
        
        if(weapon)
        {
            weapon.UpdateWeapon(Time.deltaTime);

            //if ( Input.GetButtonDown("Fire1"))
            //{
            //    weapon.StartFiring();
            //}

            //if ( weapon.isFiring)
            //{
            //    weapon.UpdateFiring(Time.deltaTime);
            //}
            //weapon.UpdateBullet(Time.deltaTime);
            //if ( Input.GetButtonUp("Fire1"))
            //{
            //    weapon.StopFiring();
            //}
            if (Input.GetKeyDown(KeyCode.X))
            {
                ToggleActiveWeapon();
                
            }

            //if (weapon.tag == "Sapu" && Input.GetButtonDown("Fire1"))
            //{
            //    Debug.Log("Kali 2");
            //}
            //if (weapon.tag == "FilterAir" )
            //{

            //}
        }

        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            SetActiveWeapon(WeaponSlot.Gun);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SetActiveWeapon(WeaponSlot.Sapu);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SetActiveWeapon(WeaponSlot.Filter);
        }
       



    }
   
    void ToggleActiveWeapon()
    {
        bool isHoster = rigController.GetBool("hoster_pistol");
        if(isHoster)
        {
            StartCoroutine(ActiveWeapon1(activeWeaponIndex));
        }
        else
        {
            
            StartCoroutine(HosterWeapon(activeWeaponIndex));
        }
    }
  
    public void Equip(RaycastWeapon newWepaon)
    {
        int weaponSlotIndex = (int)newWepaon.weaponSlot;
        var weapon = GetWeapon(weaponSlotIndex);
        if(weapon)
        {
            Destroy(weapon.gameObject);
        }
        weapon = newWepaon;
        weapon.raycastDestination = crossHitTarget;
        weapon.transform.SetParent  (weaponSlot[weaponSlotIndex],false);
        Equipweapon[weaponSlotIndex] = weapon;
        SetActiveWeapon(newWepaon.weaponSlot);
    }
    void SetActiveWeapon(WeaponSlot weaponSlot)
    {
        int hosterIndex = activeWeaponIndex;
        int activeIndex = (int)weaponSlot;

        if(hosterIndex == activeIndex)
        {
            hosterIndex = -1;
        }
        StartCoroutine(SwitchWeapon(hosterIndex, activeIndex));
    }

    IEnumerator SwitchWeapon(int hosterIndex, int activeIndex)
    {
        yield return StartCoroutine(HosterWeapon(hosterIndex));
        yield return StartCoroutine(ActiveWeapon1(activeIndex));
        activeWeaponIndex = activeIndex;

    }
    IEnumerator HosterWeapon(int index)
    {
        var weapon = GetWeapon(index);
        if(weapon)
        {
            rigController.SetBool("hoster_pistol", true);
            do
            {
                yield return new WaitForEndOfFrame();
            } while (rigController.GetCurrentAnimatorStateInfo(0).normalizedTime < 1.0f);
        }
    }
    IEnumerator ActiveWeapon1(int index)
    { 
        var weapon = GetWeapon(index);
        if (weapon)
        {
            rigController.SetBool("hoster_pistol", false);
            rigController.Play("equip_" + weapon.weaponName);
            do
            {
                yield return new WaitForEndOfFrame();
            } while (rigController.GetCurrentAnimatorStateInfo(0).normalizedTime < 1.0f);
        }
    }





}
