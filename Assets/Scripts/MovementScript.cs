using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    [System.NonSerialized] public float currentVelocity;
    public float maxVelocity;
    public float speed;

    public float breakVelocity;
    public float speedRemove;
    
    private Vector3 movementDir = Vector3.zero;

    private bool isMoving;
    
    public KeyCode upButton;
    public KeyCode downButton;
    public KeyCode leftButton;
    public KeyCode rightButton;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        

        if (Input.anyKey && !isMoving)
        {
            movementDir = KeyDirCheck();
            
        }
        
        HandlerSpeed();
        MoveCharacter(movementDir);
        
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Wall"))
        {
            isMoving = false;
        }
    }

    void MoveCharacter(Vector3 dir)
    {
        transform.position += dir * currentVelocity * Time.deltaTime;
    }

    void HandlerSpeed()
    {
        if (isMoving && currentVelocity < maxVelocity)
        {
            currentVelocity += speed * Time.deltaTime;
        }
        else if (!isMoving)
        {
            currentVelocity = 0;
        }
    }

    Vector3 KeyDirCheck()
    {
        
        
        if (Input.GetKeyDown(upButton))
        {
            isMoving = true;
            return Vector3.up;
        }
        if (Input.GetKeyDown(rightButton))
        {
            isMoving = true;
            return Vector3.right;
        }
        if (Input.GetKeyDown(leftButton))
        {
            isMoving = true;
            return Vector3.left;
        }
        if (Input.GetKeyDown(downButton))
        {
            isMoving = true;
            return Vector3.down;
        }

        return Vector3.zero;
    }

    public void RemoveSpeed()
    {
        currentVelocity -= speedRemove;

        if (currentVelocity < 0)
        {
            currentVelocity = 0;
        }
    }
}
