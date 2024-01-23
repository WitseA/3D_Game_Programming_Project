using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CurrentTrashCount : MonoBehaviour
{
    public MaxTrashCountInitialization countInitialization;
    public SceneController sceneController;
    public TextMeshPro trashCountText;
    public int nextScene = 0;
    private int trashCount;

    void Start()
    {
        trashCount = countInitialization.GetMaxTrashCount();
    }

    void Update()
    {
        trashCountText.text = trashCount.ToString();

<<<<<<< HEAD
        if (trashCount == 0)
=======
        if (trashCount <= 0)
>>>>>>> arno
        {
            if (nextScene == 0)
            {
                SceneController.HasWon = true;
            }
            else
            {
                sceneController.ChangeScene(nextScene);
            }
        }
    }

    public void SubstractFromMaxTrashCount()
    {
        trashCount--;
    }

}
