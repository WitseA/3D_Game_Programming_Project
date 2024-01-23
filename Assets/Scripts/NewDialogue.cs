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
                // tanee 1-4
                // tutorial 5
                // witse 6-9
                // wout  10-13
                // arno  14-17
                
                case 1:
                    item.Value.Add("Approximately one-third of all food produced worldwide for human consumption is wasted");
                    item.Value.Add("leading to significant environmental impacts");
                    break;
                case 2:
                    item.Value.Add("The fashion industry is responsible for 10% of global CO2 emissions");
                    item.Value.Add("It is one of the largest polluters of freshwater");
                    break;
                case 3:
                    item.Value.Add("Solar panels have a short 'energy payback time' of 1-2 years");
                    item.Value.Add("and subsequently generate more energy than the production process consumes");
                    break;
                case 4:
                    item.Value.Add("Burning wood in stoves can contribute to air pollution");
                    item.Value.Add("Efficient technologies and sustainable fuels are necessary to mitigate environmental impacts");
                    break;
                case 5:
                    item.Value.Add("I need your help...");
                    item.Value.Add("Our planet has been massively polluted for the last 100000 years,");
                    item.Value.Add("we desperately need help cleaning it up.");
                    item.Value.Add("Are you up for it?");
                    item.Value.Add("Some stuff may be, let's say, a struggle to get to...");
                    item.Value.Add("How to play!");
                    item.Value.Add("Move with arrow keys or wasd. Jump with space. Crouch with ctrl. Sprint with shift.");
                    item.Value.Add("Good luck!");
                    break;
                case 6:
                    item.Value.Add("I heard this jumppad sends you up way high! I'm too scared to try myself though...");
                    item.Value.Add("Maybe you should give it a try?");
                    break;
                case 7:
                    item.Value.Add("Last piece of trash!!");
                    break;
                case 14:
                    item.Value.Add("Cities aim for sustainable transportation systems such as electric public transportation");
                    item.Value.Add("And the development of walkable neighborhoods to reduce dependence on cars.");
                    break;
                case 15:
                    item.Value.Add("Cities encourage sustainable business practices,");
                    item.Value.Add("They also support green enterprises to foster a sustainable local economy.");
                    break;
                case 16:
                    item.Value.Add("Promoting local and sustainable food production, such as urban farming and community gardens.");
                    item.Value.Add("Contributes to food security and reduces the ecological impact of food transportation.");
                    item.Value.Add("By reducing reliance on long-distance transportation,");
                    item.Value.Add("Local food production minimizes the carbon footprint associated with the transportation of goods.");
                    break;
                case 17:
                    item.Value.Add("Burning wood can be considered a relatively sustainable and eco-friendly source of energy when managed responsibly.");
                    item.Value.Add("Wood is a renewable resource");
                    item.Value.Add("As long as the rate of tree cutting is balanced with replanting and sustainable forestry practices.");
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
