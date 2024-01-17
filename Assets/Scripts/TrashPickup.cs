using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TrashPickup : MonoBehaviour
{
    public CurrentTrashCount trashCountController;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            trashCountController.AddToTrashCount();
            Destroy(gameObject);
        }
    }
}
