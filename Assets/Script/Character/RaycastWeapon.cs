using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastWeapon : MonoBehaviour
{
    class Bullet
    {
        public float time;
        public Vector3 initialPosition;
        public Vector3 initialVelocity;
        public TrailRenderer tracer;
    }
   
    public int fireRate = 25;
    public float bulletSpeed = 1000.0f;
    public float bulletDrop = 0.0f; 
    float accumulateTime;
    public bool isFiring = false;
    public ParticleSystem[] muzzleFlash;
    public ParticleSystem hitEffect;
    public Transform raycastOrigin;
    public Transform raycastDestination;
    public TrailRenderer tracerEffect;
    public AnimationClip weaponAnimation;
    

    Ray ray;
    RaycastHit hitInfo;
    float maxLifeTime = 3.0f;

    List<Bullet> bullets = new List<Bullet>();
    Vector3 GetPosition(Bullet bullet)
    {
       
        
            Vector3 gravity = Vector3.down * bulletDrop;
            
        
        return (bullet.initialPosition) + (bullet.initialVelocity * bullet.time) + (0.5f * gravity * bullet.time * bullet.time);

    }

    Bullet CreateBullet(Vector3 position, Vector3 velocity)
    {
        
        
            Bullet bullet = new Bullet();
            bullet.initialPosition = position;
            bullet.initialVelocity = velocity;
            bullet.time = 0.0f;
            bullet.tracer = Instantiate(tracerEffect, position, Quaternion.identity);
            bullet.tracer.AddPosition(position);
           
        
        return bullet;

    }
    public void StartFiring()
    {
        if(gameObject.tag == "Gun")
        {
            isFiring = true;
            accumulateTime = 0.0f;
            FireBullet();
        }
       

       
    }
    void DestroyBullet()
    {
        bullets.RemoveAll(bullet => bullet.time >= maxLifeTime);
    }
    public void UpdateFiring(float deltaTime)
    {

        accumulateTime += deltaTime;
        float fireInterval = 1.0f / fireRate;
        while(accumulateTime >= 0.0f)
        {
            FireBullet();
            accumulateTime -= fireInterval;
        }
    }
    public void UpdateBullet(float deltaTime)
    {
        SimulateBullets(deltaTime);
        DestroyBullet();
    }
    void SimulateBullets(float deltaTime)
    {
        bullets.ForEach(bullet =>
        {
            Vector3 p0 = GetPosition(bullet);
            bullet.time += deltaTime;
            Vector3 p1 = GetPosition(bullet);
            RaycastSegment(p0, p1, bullet);
        });
    }

    void RaycastSegment(Vector3 start, Vector3 end, Bullet bullet)
    {
        Vector3 direction = end - start;
        float distance = direction.magnitude;
        ray.origin = start;
        ray.direction = direction;
        if (Physics.Raycast(ray, out hitInfo, distance))
        {
            //Debug.DrawLine(ray.origin, hitInfo.point, Color.red, 1.0f); 

            hitEffect.transform.position = hitInfo.point;
            hitEffect.transform.forward = hitInfo.normal;
            hitEffect.Emit(1);

            bullet.tracer.transform.position = hitInfo.point;
            bullet.time = maxLifeTime;
        }
        else
        {
            bullet.tracer.transform.position = end;
        }
    }
    private void FireBullet()
    {
        foreach (var particle in muzzleFlash)
        {
            particle.Emit(1);
        }

        Vector3 velocity = (raycastDestination.position - raycastOrigin.position).normalized * bulletSpeed;
        var bullet = CreateBullet(raycastOrigin.position, velocity);
        bullets.Add(bullet);
        //ray.origin = raycastOrigin.position;
        //ray.direction = raycastDestination.position - raycastOrigin.position;
        //var tracer = Instantiate(tracerEffect, ray.origin, Quaternion.identity);
        //tracer.AddPosition(ray.origin);
    
    }

   
        

    public void StopFiring()
    {
        isFiring = false;
    }
}
