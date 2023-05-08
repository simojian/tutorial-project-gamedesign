using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrateLogic : MonoBehaviour
{
    public MovementScript playerScript;

    public float breakVelocity;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("whattheheeel");
        if (playerScript.currentVelocity > breakVelocity && col.gameObject.CompareTag("Player"))
        {
            DestroySequence();
        }
    }

    void DestroySequence()
    {
        Destroy(gameObject);
    }
}
