using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TrashPickup : MonoBehaviour
{
    public CurrentTrashCount trashCountController;
    public ScoreController scoreController;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            trashCountController.SubstractFromMaxTrashCount();
            scoreController.AddScore();
            Destroy(gameObject);
        }
    }
}
