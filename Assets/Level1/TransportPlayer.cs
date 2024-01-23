using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransportPlayer : MonoBehaviour
{
    public Transform transporter1;
    public Transform transporter2;

    private bool isOnTransporter1 = false;
    private float offsetDistance = 5.0f;

    void Start()
    {
        
    }


    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform == transporter1)
        {
            if (!isOnTransporter1)
            {
                Debug.Log("Transporting to transporter2");
                TransportTo(transporter2, offsetDistance);
                isOnTransporter1 = true;
            }
        }
        else if (collision.transform == transporter2)
        {
            if (isOnTransporter1)
            {
                Debug.Log("Transporting to transporter1");
                TransportTo(transporter1, offsetDistance);
                isOnTransporter1 = false;
            }
        }
    }

    private void TransportTo(Transform destination, float offset)
    {
        // Voeg hier eventuele overgangsanimaties of geluiden toe

        // Verplaats het spelerobject naar de nieuwe locatie
        Vector3 offsetVector = (destination.position - transform.position).normalized * offset;
        transform.position = destination.position + offsetVector;
    }
}
