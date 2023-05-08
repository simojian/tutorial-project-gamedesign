using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    private float currentVelocity;
    public float maxVelocity;
    public float speed;
    
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
            movementDir = keyDirCheck();
            
        }
        
        handlerSpeed();
        moveCharacter(movementDir);
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("boop");
        if (col.gameObject.tag == "Wall")
        {
            isMoving = false;
        }
    }

    void moveCharacter(Vector3 dir)
    {
        transform.position += dir * currentVelocity * Time.deltaTime;
    }

    void handlerSpeed()
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

    Vector3 keyDirCheck()
    {
        
        
        if (Input.GetKey(upButton))
        {
            isMoving = true;
            return Vector3.up;
        }
        if (Input.GetKey(rightButton))
        {
            isMoving = true;
            return Vector3.right;
        }
        if (Input.GetKey(leftButton))
        {
            isMoving = true;
            return Vector3.left;
        }
        if (Input.GetKey(downButton))
        {
            isMoving = true;
            return Vector3.down;
        }

        return Vector3.zero;
    }
}
