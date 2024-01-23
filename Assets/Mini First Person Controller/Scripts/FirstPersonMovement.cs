﻿using System.Collections.Generic;
using UnityEngine;

public class FirstPersonMovement : MonoBehaviour
{
    public float speed = 5;

    [Header("Running")]
    public bool canRun = true;
    public bool IsRunning { get; private set; }
    public float runSpeed = 9;
    public KeyCode runningKey = KeyCode.LeftShift;

    Rigidbody rigidbody;

    public GroundCheck groundCheck;
<<<<<<< HEAD
    /// <summary> Functions to override movement speed. Will use the last added override. </summary>
=======
>>>>>>> tanee
    public List<System.Func<float>> speedOverrides = new List<System.Func<float>>();



    void Awake()
    {
<<<<<<< HEAD
        // Get the rigidbody on this.
        rigidbody = GetComponent<Rigidbody>();
        groundCheck = GetComponentInChildren<GroundCheck>();
=======
        rigidbody = GetComponent<Rigidbody>();
>>>>>>> tanee
    }

    void FixedUpdate()
    {
<<<<<<< HEAD
        // Dont move if in dialogue with NPC
        if (!NPCSystem.inDialogue)
        {
            rigidbody.constraints = RigidbodyConstraints.None;
            Move();
        }
        else if (groundCheck.isGrounded && NPCSystem.inDialogue)
        {
            rigidbody.constraints = RigidbodyConstraints.FreezeAll;
        }
    }
    void Move()
    {
        // Update IsRunning from input.
        IsRunning = canRun && Input.GetKey(runningKey);

        // Get targetMovingSpeed.
=======
        IsRunning = canRun && Input.GetKey(runningKey);

>>>>>>> tanee
        float targetMovingSpeed = IsRunning ? runSpeed : speed;
        if (speedOverrides.Count > 0)
        {
            targetMovingSpeed = speedOverrides[speedOverrides.Count - 1]();
        }

<<<<<<< HEAD
        // Get targetVelocity from input.
        Vector2 targetVelocity =new Vector2( Input.GetAxis("Horizontal") * targetMovingSpeed, Input.GetAxis("Vertical") * targetMovingSpeed);

        // Apply movement.
=======
        Vector2 targetVelocity =new Vector2( Input.GetAxis("Horizontal") * targetMovingSpeed, Input.GetAxis("Vertical") * targetMovingSpeed);

>>>>>>> tanee
        rigidbody.velocity = transform.rotation * new Vector3(targetVelocity.x, rigidbody.velocity.y, targetVelocity.y);
    }
}