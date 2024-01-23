using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class NewDialogue : MonoBehaviour
{
    private int index = 0;
    private List<string> dialogues = new List<string>();
    private List<NPCSystem> nPCSystems = new List<NPCSystem>();
    private Dictionary<NPCSystem, List<string>> dictionary = new Dictionary<NPCSystem, List<string>>();
    public static bool InDialog = false;

    void Start()
    {
        // Find the NPCSystem instance in the scene
        nPCSystems = FindObjectsOfType<NPCSystem>().ToList();
        foreach (var npcSystem in nPCSystems)
        {
            dictionary.Add(npcSystem, new List<string>());
        }

        foreach (var item in dictionary)
        {
            switch (item.Key.WhatNPC)
            {
                case 1: //tanee
                    item.Value.Add("Approximately one-third of all food produced worldwide for human consumption is wasted");
                    item.Value.Add("leading to significant environmental impacts");
                    break;
                case 2: //tanee
                    item.Value.Add("The fashion industry is responsible for 10% of global CO2 emissions");
                    item.Value.Add("It is one of the largest polluters of freshwater");
                    break;
                case 3: //tanee
                    item.Value.Add("Solar panels have a short 'energy payback time' of 1-2 years");
                    item.Value.Add("and subsequently generate more energy than the production process consumes");
                    break;
                case 4: //tanee
                    item.Value.Add("Burning wood in stoves can contribute to air pollution");
                    item.Value.Add("Efficient technologies and sustainable fuels are necessary to mitigate environmental impacts");
                    break;
                case 5: //witse
                    item.Value.Add("I need your help...");
                    item.Value.Add("Our planet has been massively polluted for the last 100000 years,");
                    item.Value.Add("we desperately need help cleaning it up.");
                    item.Value.Add("Are you up for it?");
                    item.Value.Add("Some stuff may be, let's say, a struggle to get to...");
                    break;
                case 6: //witse
                    item.Value.Add("I heard this jumppad sends you up way high! I'm too scared to try myself though...");
                    item.Value.Add("Maybe you should give it a try?");
                    break;
                default:
                    break;
            }
        }
    }

    void Update()
    {
            foreach (var item in dictionary)
            {
                var npcSystem = item.Key;
                dialogues = item.Value;
                if (npcSystem != null && npcSystem.inDialogue && dialogues.Count > 0)
                {
                    InDialog = true;
                    TextMeshProUGUI textMeshPro = npcSystem.beeld.GetComponentInChildren<TextMeshProUGUI>();
                    textMeshPro.text = dialogues[index];
                    npcSystem.beeld.SetActive(true);

                    if (index < dialogues.Count && Input.GetMouseButtonDown(0))
                    {
                        index++;

                        // Update the dialogue text on the canvas
                        if (textMeshPro != null && index < dialogues.Count && dialogues.Count > 0)
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
                            npcSystem.inDialogue = false;
                        InDialog = false;
                            index = 0;
                            npcSystem.beeld.SetActive(false);
                        }
                    }
                }
        }
    }
}
