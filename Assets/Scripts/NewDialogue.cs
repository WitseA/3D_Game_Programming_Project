using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewDialogue : MonoBehaviour
{
    int index = 1;
    void Update()
    {
        if (Input.GetMouseButton(0) && transform.childCount > 1)
        {
            if (FirstPersonMovement.inDialogue)
            {
                transform.GetChild(index).gameObject.SetActive(true);
                index += 1;
                if (transform.childCount == index)
                {
                    index = 2;
                    FirstPersonMovement.inDialogue = false;
                }
            }
            else
            {
                gameObject.SetActive(false);
            }
        }        
    }
}
