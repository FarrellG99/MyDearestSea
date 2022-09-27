using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastWeapon : MonoBehaviour
{
    public bool isFiring = false;
    public ParticleSystem[] muzzleFlash;
    public void StartFiring()
    {
        isFiring = true;
        foreach(var particle in muzzleFlash)
        {
            particle.Emit(1);
        }
        
    }
    public void StopFiring()
    {
        isFiring = false;
    }
}
