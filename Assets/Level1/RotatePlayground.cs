using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePlayground : MonoBehaviour
{
    public Transform playerTransform;
    public float activationDistance = 50f;

    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        if (playerTransform == null)
        {
            playerTransform = Camera.main.transform;
        }
    }

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, playerTransform.position);

        if (distanceToPlayer < activationDistance)
        {
            animator.SetBool("PlayerClose", true);
        }
        else
        {
            animator.SetBool("PlayerClose", false);
        }
    }
}
