using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTruck : MonoBehaviour
{
    public string playerTag = "Player";
    public Animator truckAnimator;
    public Collider playerCollider;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdatePlayerPosition();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(playerTag))
        {
            truckAnimator.SetBool("Move", true);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag(playerTag))
        {
            truckAnimator.SetBool("Move", false);
        }
    }

    private void UpdatePlayerPosition()
    {
        if (playerCollider != null && truckAnimator.GetBool("Move"))
        {
            Debug.Log("move player");
            Vector3 newPosition = playerCollider.transform.position;
            newPosition.z = transform.position.z;
            playerCollider.transform.position = newPosition;
        }
    }
}
