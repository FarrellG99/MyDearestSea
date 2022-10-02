using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveWeapon : MonoBehaviour
{
    public Transform crossHitTarget;
    RaycastWeapon weapon;
    public UnityEngine.Animations.Rigging.Rig hankIK;
    void Start()
    {
        RaycastWeapon existingWeapon = GetComponentInChildren<RaycastWeapon>();
        if(existingWeapon)
        {
            Equip(existingWeapon);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(weapon)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                weapon.StartFiring();
            }

            if (weapon.isFiring)
            {
                weapon.UpdateFiring(Time.deltaTime);
            }
            weapon.UpdateBullet(Time.deltaTime);
            if (Input.GetButtonUp("Fire1"))
            {
                weapon.StopFiring();
            }
        }else
        {
            hankIK.weight = 0.0f;
        }
     
    }

    public void Equip(RaycastWeapon newWepaon)
    {
        weapon = newWepaon;
        weapon.raycastDestination = crossHitTarget;
        hankIK.weight = 1.0f;
    }
}
