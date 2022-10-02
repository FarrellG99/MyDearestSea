using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossHairTarget : MonoBehaviour
{
    public Camera mainCamera;
    Ray ray;
    RaycastHit hitInfo;
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        ray.origin = mainCamera.transform.position;
        ray.direction = mainCamera.transform.forward;
        if (Physics.Raycast(ray, out hitInfo))
        {

            transform.position = hitInfo.point;

        }
        else
        {

            transform.position = ray.origin + ray.direction * 1000.0f;

        }
    }
}
