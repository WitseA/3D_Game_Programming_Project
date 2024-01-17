using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CurrentTrashCount : MonoBehaviour
{
    public MaxTrashCountInitialization countInitialization;
    public SceneController sceneController;
    public int nextScene = 0;
    private int trashCount = 0;
    //public TextMeshPro trashCountText;

    // Update is called once per frame
    void Update()
    {
        //trashCountText.text = trashCount.ToString();

        if (trashCount == countInitialization.GetMaxTrashCount())
        {
            sceneController.ChangeScene(nextScene);
        }
    }

    public void AddToTrashCount()
    {
        trashCount++;
    }

}
