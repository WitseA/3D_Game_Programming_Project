using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MaxTrashCountInitialization : MonoBehaviour
{
    public string targetTag = "Trash";
    public int maxTrashCount;
    //public TextMeshPro maxTrashCountText;
    
    // Start is called before the first frame update
    void Start()
    {
        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag(targetTag);

        maxTrashCount = objectsWithTag.Length;

        //maxTrashCountText.text = "  /  " + maxTrashCount;
    }


    public int GetMaxTrashCount()
    {
        return maxTrashCount;
    }
}
