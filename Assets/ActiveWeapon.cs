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

    Animator anim;
    AnimatorOverrideController overrides;
    void Start()
    {
        anim = GetComponent<Animator>();
        overrides = anim.runtimeAnimatorController as AnimatorOverrideController;
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
            anim.SetLayerWeight(1, 1.0f);
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
        }else
        {
            hankIK.weight = 0.0f;
            anim.SetLayerWeight(1, 0.0f);
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

        hankIK.weight = 1.0f;
        anim.SetLayerWeight(1, 1.0f);
        Invoke(nameof(SetAnimationDelayed), 0.001f);
    }

    void SetAnimationDelayed()
    {
        overrides["Weapon_Anim_Empty"] = weapon.weaponAnimation;

    }

    [ContextMenu("Save Weapon Pose")]
    void SaveWeaponPose()
    {
        GameObjectRecorder recorder = new GameObjectRecorder(gameObject);
        recorder.BindComponentsOfType<Transform>(weaponParent.gameObject, false);
        recorder.BindComponentsOfType<Transform>(weaponLeftGrip.gameObject, false);
        recorder.BindComponentsOfType<Transform>(WeaponRightGrip.gameObject, false);

        recorder.TakeSnapshot(0.0f);
        recorder.SaveToClip(weapon.weaponAnimation);
    }


}
