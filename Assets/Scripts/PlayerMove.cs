﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    private CharacterController characterController;
    private PlayerInput playerInput;
    private Vector3 vector3Move;
    private Vector2 moveValue = new Vector2(0, 0);
    private bool isSprinting = false;
    private float speed = 5f;
    private float maxSpeed = 10f;
    private float minSpeed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        playerInput = GetComponent<PlayerInput>();
    }

    // Update is called once per frame
    void Update()
    {
        vector3Move = transform.right * moveValue.x + transform.forward * moveValue.y;
        characterController.Move(vector3Move * Time.deltaTime * speed);
        if(isSprinting && moveValue.y > 0)
        {
            speed += 0.05f;
            if(speed >= maxSpeed)
            {
                speed = maxSpeed;
            }
            
        }
        if(!(isSprinting) || moveValue.y <= 0)
        {
            speed -= 0.05f;
            if(speed <= minSpeed)
            {
                speed = minSpeed;
            }
        }
        print(speed);
    }

    public void move(InputAction.CallbackContext context)
    {
        
        if (context.performed)
        {
            
            moveValue = context.ReadValue<Vector2>();
           // print(moveValue);
        }
        if(context.canceled)
        {
            moveValue = context.ReadValue<Vector2>();
            //print(moveValue);
        }
        
        
    }
    public void sprint(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            isSprinting = true;
        }
        if(context.canceled)
        {
            isSprinting = false;
        }
    }
}