using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NPCSystem : MonoBehaviour
{
<<<<<<< HEAD
    public GameObject beeld;
    public bool inDialogue { get; set; } = false;
    public int WhatNPC;
    public bool playerDetection = false;
void Start()
=======
    public bool playerDetection = false;
    public GameObject beeld;
    public static bool inDialogue { get; set; } = false;
    private int index = 0;

    void Start()
>>>>>>> parent of e5a045a (Added start of parkour and made jumppad script + npc.)
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
