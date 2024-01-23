using System.Collections.Generic;
using UnityEngine;

public class FirstPersonMovement : MonoBehaviour
{
    public float speed = 5;

    [Header("Running")]
    public bool canRun = true;
    public bool IsRunning { get; private set; }
    public float runSpeed = 9;
    public KeyCode runningKey = KeyCode.LeftShift;

<<<<<<< HEAD

=======
>>>>>>> arno
    Rigidbody rigidbody;

    public GroundCheck groundCheck;
    /// <summary> Functions to override movement speed. Will use the last added override. </summary>
    public List<System.Func<float>> speedOverrides = new List<System.Func<float>>();



    void Awake()
    {
        // Get the rigidbody on this.
        rigidbody = GetComponent<Rigidbody>();
<<<<<<< HEAD
        groundCheck = GetComponentInChildren<GroundCheck>();
=======
>>>>>>> arno
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
=======
>>>>>>> arno
        // Update IsRunning from input.
        IsRunning = canRun && Input.GetKey(runningKey);

        // Get targetMovingSpeed.
        float targetMovingSpeed = IsRunning ? runSpeed : speed;
        if (speedOverrides.Count > 0)
        {
            targetMovingSpeed = speedOverrides[speedOverrides.Count - 1]();
        }

        // Get targetVelocity from input.
<<<<<<< HEAD
        Vector2 targetVelocity = new Vector2(Input.GetAxis("Horizontal") * targetMovingSpeed, Input.GetAxis("Vertical") * targetMovingSpeed);
=======
        Vector2 targetVelocity =new Vector2( Input.GetAxis("Horizontal") * targetMovingSpeed, Input.GetAxis("Vertical") * targetMovingSpeed);
>>>>>>> arno

        // Apply movement.
        rigidbody.velocity = transform.rotation * new Vector3(targetVelocity.x, rigidbody.velocity.y, targetVelocity.y);
    }
}