using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NewDialogue : MonoBehaviour
{
    private NPCSystem npcSystem;
    private int index = 0;
    private List<string> dialogues = new List<string>();

    void Start()
    {
        // Find the NPCSystem instance in the scene
        npcSystem = FindObjectOfType<NPCSystem>();
        switch (npcSystem.WhatNPC)
        {
            case 1:
                dialogues.Add("I need your help...");
                dialogues.Add("Our planet has been massively polluted for the last 100000 years,");
                dialogues.Add("we desperately need help cleaning it up.");
                dialogues.Add("Are you up for it?");
                dialogues.Add("Some stuff may be, let's say, a struggle to get to...");
                break;
            case 2:
                dialogues.Add("I heard this jumppad sends you up way high! I'm too scared to try myself though...");
                dialogues.Add("Maybe you should give it a try?");
                break;
            default:
                break;
        }
    }

    void Update()
    {
        if (npcSystem != null && NPCSystem.inDialogue)
        {
            TextMeshProUGUI textMeshPro = npcSystem.beeld.GetComponentInChildren<TextMeshProUGUI>();
            textMeshPro.text = dialogues[index];
            npcSystem.beeld.SetActive(true);

            if (index < dialogues.Count && Input.GetMouseButtonDown(0))
            {
                index++;

                // Update the dialogue text on the canvas
                if (textMeshPro != null && index < dialogues.Count)
                {
                    textMeshPro.text = dialogues[index];
                }
                else if (textMeshPro == null)
                {
                    Debug.LogError("TextMeshProUGUI component not found on the dialogue object.");
                }
                
                if (index >= dialogues.Count)
                {
                    // All dialogues displayed, end dialogue
                    NPCSystem.inDialogue = false;
                    index = 0;
                    npcSystem.beeld.SetActive(false);
                }
            }
        }
    }
}
