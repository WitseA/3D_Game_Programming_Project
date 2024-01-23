using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SwitchingCameras : MonoBehaviour
{
    public Camera firstPersonCam;
    public Camera thirdPersonCam;
    public Canvas hudCanvas;

    public Canvas dialogueCanvas;

    public string cameraSwitchKey = "g";
    public TextMeshPro switchCameraText;

    // Start is called before the first frame update
    void Start()
    {
        firstPersonCam.enabled = true;
        thirdPersonCam.enabled = false;

        hudCanvas.worldCamera = firstPersonCam;

        dialogueCanvas.worldCamera = firstPersonCam;


        switchCameraText.text = cameraSwitchKey + ": switch camera\nf: talk to npc's";
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(GetKeyCodeFromString())) {
            ToggleCameras();
        }
    }

    void ToggleCameras()
    {
        // Swap camera states
        firstPersonCam.enabled = !firstPersonCam.enabled;
        thirdPersonCam.enabled = !thirdPersonCam.enabled;

        UpdateCanvasCamera();
    }

    void UpdateCanvasCamera()
    {
        // Set the canvas to use the currently active camera
        hudCanvas.worldCamera = firstPersonCam.enabled ? firstPersonCam : thirdPersonCam;

        dialogueCanvas.worldCamera = firstPersonCam.enabled ? firstPersonCam : thirdPersonCam;

    }

    KeyCode GetKeyCodeFromString()
    {
        // Convert string to KeyCode
        return (KeyCode)System.Enum.Parse(typeof(KeyCode), cameraSwitchKey.ToUpper());    
    }

    public string GetSwitchCamKey()
    {
        return cameraSwitchKey;
    }
}
