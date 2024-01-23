using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NPCSystem : MonoBehaviour
{
    public GameObject beeld;
    public int WhatNPC;

    public bool playerDetection = false;
    public bool inDialogue = false;
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
