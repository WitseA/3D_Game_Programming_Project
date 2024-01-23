using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NewDialogue : MonoBehaviour
{
    private NPCSystem npcSystem;

    void Start()
    {
        // Find the NPCSystem instance in the scene
        npcSystem = FindObjectOfType<NPCSystem>();
    }

    void Update()
    {
        if (npcSystem != null && NPCSystem.inDialogue)
        {
            int i = 0;
            while (i < npcSystem.dialogues.Count)
            {
                print("Nu dialoog: " + i);
                // Update the dialogue text on the canvas
                TextMeshProUGUI textMeshPro = npcSystem.beeld.GetComponentInChildren<TextMeshProUGUI>();
                if (textMeshPro != null)
                {
                    textMeshPro.text = npcSystem.dialogues[i];
                }
                else
                {
                    Debug.LogError("TextMeshProUGUI component not found on the dialogue object.");
                }
                if (Input.GetMouseButtonDown(0))
                {
                    i++;
                }
            }
            // All dialogues displayed, end dialogue
            NPCSystem.inDialogue = false;
            npcSystem.beeld.SetActive(false);
        }
    }
}
