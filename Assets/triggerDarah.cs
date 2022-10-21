using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerDarah : MonoBehaviour
{
    public CharacterHealth chara;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            
        }
    }
}
