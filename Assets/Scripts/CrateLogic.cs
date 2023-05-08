using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrateLogic : MonoBehaviour
{
    private MovementScript playerScript;
    private Collider2D colPhysics;
    private CinemachineShake cam;

    public float onBreakShakeDuration;
    public float onBreakShakeAmplitude;

    private float breakVelocity;
    
    // Start is called before the first frame update
    void Start()
    {
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<MovementScript>();
        colPhysics = gameObject.GetComponent<BoxCollider2D>();
        cam = GameObject.FindGameObjectWithTag("CMCam").GetComponent<CinemachineShake>();

        breakVelocity = playerScript.breakVelocity;
    }

    // Update is called once per frame
    // ReSharper disable Unity.PerformanceAnalysis
    void Update()
    {
        if (playerScript.currentVelocity >= breakVelocity)
        {
            colPhysics.enabled = false;
        }
        else
        {
            colPhysics.enabled = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        
        if (playerScript.currentVelocity >= breakVelocity && col.gameObject.CompareTag("Player"))
        {
            
            DestroySequence();
        }
    }

    void DestroySequence()
    {
        
        
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        cam.ShakeScreen(onBreakShakeAmplitude, onBreakShakeDuration);
        
        playerScript.RemoveSpeed();
    }
}
