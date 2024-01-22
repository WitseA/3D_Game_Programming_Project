using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NPCSystem : MonoBehaviour
{
    public bool playerDetection = false;
    public GameObject dialogueTemplate;
    public GameObject beeld;
    void Update()
    {
        if(playerDetection && Input.GetKeyDown(KeyCode.F) && !FirstPersonMovement.inDialogue)
        {
            beeld.SetActive(true);
            FirstPersonMovement.inDialogue = true;
            NewDialogue("werkt");
            NewDialogue("zeker");
            NewDialogue("werkt");
            NewDialogue("VAMOOOOOOOOOOOS");
            beeld.transform.GetChild(1).gameObject.SetActive(true);
        }
    }
    private void NewDialogue(string txt)
    {
        GameObject templateClone = Instantiate(dialogueTemplate, dialogueTemplate.transform);
        templateClone.transform.parent = beeld.transform;
        templateClone.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = txt;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
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
