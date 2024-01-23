using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NPCSystem : MonoBehaviour
{
<<<<<<< HEAD
<<<<<<< HEAD
    public GameObject beeld;
    public bool inDialogue { get; set; } = false;
    public int WhatNPC;
    public bool playerDetection = false;
void Start()
=======
    public bool playerDetection = false;
=======
>>>>>>> 608aced572cadfbbd09a608d8813204bb14a0437
    public GameObject beeld;
    public int WhatNPC;

    public bool playerDetection = false;
    public bool inDialogue = false;
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
<<<<<<< HEAD
=======

>>>>>>> 608aced572cadfbbd09a608d8813204bb14a0437
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
