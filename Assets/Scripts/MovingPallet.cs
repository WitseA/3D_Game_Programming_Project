using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPallet : MonoBehaviour
{
    public List<Vector3> targetPositions;
    public float speed = 5f;
    private int i = 1;

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPositions[i], speed * Time.deltaTime);

        if (transform.position == targetPositions[i] && i + 1 < targetPositions.Count)
        {
            i++;
        }

        if (i == targetPositions.Count)
        {
            i = 1;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.SetParent(transform);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.SetParent(null);
        }
    }
}
