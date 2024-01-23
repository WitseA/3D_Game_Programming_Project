using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NPCSystem : MonoBehaviour
{
    public bool playerDetection = false;
    public GameObject beeld;
    public static bool inDialogue { get; set; } = false;
    private int index = 0;

    void Start()
    {
        // Set up first line
        beeld.GetComponentInChildren<TextMeshProUGUI>().text = "Ni tonen den deze";
    }

    void Update()
    {
        if (playerDetection && Input.GetKeyDown(KeyCode.F) && !inDialogue)
        {
            inDialogue = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            playerDetection = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            playerDetection = false;
        }
    }
}
