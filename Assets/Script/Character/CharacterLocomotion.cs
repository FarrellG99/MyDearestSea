using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterLocomotion : MonoBehaviour
{
    public GameObject footStepS;
    Animator anim;
    Vector2 input;
    bool isMoving = false; 
    void Start()
    {
        footStepS.SetActive(false);
        anim = GetComponent<Animator>(); 
    }

    // Update is called once per frame
    void Update()
    {
        input.x = Input.GetAxis("Horizontal");
        input.y = Input.GetAxis("Vertical");

        anim.SetFloat("Input.X", input.x);
        anim.SetFloat("Input.Y", input.y);

        if (Input.GetKeyDown("w"))
        {
            footStep();
        }
        if (Input.GetKeyDown("s"))
        {       
            footStep();
        }
        if (Input.GetKeyDown("a"))
        {
            footStep();
        }
        if (Input.GetKeyDown("d"))
        {
            footStep();
        }

        if (Input.GetKeyUp("w"))
        {
            StopFootStep();
        }
        if (Input.GetKeyUp("s"))
        {
            StopFootStep();
        }
        if (Input.GetKeyUp("a"))
        {
            StopFootStep();
        }
        if (Input.GetKeyUp("d"))
        {
            StopFootStep();
        }

    }

    void footStep()
    {
        footStepS.SetActive(true);
    }
    void StopFootStep()
    {
        footStepS.SetActive(false);
    }
}
