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
        dialogues.Add("1");
        dialogues.Add("2");
        dialogues.Add("3");
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
