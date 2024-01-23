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

            //Start the dialogue sequence
            //ShowNextDialogue();
        }
    }

    /*private void ShowNextDialogue()
    {
        if (index < dialogues.Count)
        {
            // Update the dialogue text on the canvas
            TextMeshProUGUI textMeshPro = beeld.GetComponentInChildren<TextMeshProUGUI>();
            if (textMeshPro != null)
            {
                textMeshPro.text = dialogues[index];
            }
            else
            {
                Debug.LogError("TextMeshProUGUI component not found on the dialogue object.");
            }

            index += 1;
            print(index + " en " + dialogues.Count);
            if (index > dialogues.Count)
            {
                // All dialogues displayed, end dialogue
                inDialogue = false;
                index = 0;
                beeld.SetActive(false);
            }
        }
    }*/

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
