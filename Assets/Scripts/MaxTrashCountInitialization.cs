using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MaxTrashCountInitialization : MonoBehaviour
{
    private string targetTag = "Trash";
    private int maxTrashCount;
    
    void Start()
    {
        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag(targetTag);

        maxTrashCount = objectsWithTag.Length;
    }


    public int GetMaxTrashCount()
    {
        return maxTrashCount;
    }
}
