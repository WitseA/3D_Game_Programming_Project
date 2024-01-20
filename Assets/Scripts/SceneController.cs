using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public static bool HasWon = false;
    public void ChangeScene(int sceneCount)
    {
        SceneManager.LoadScene(sceneCount);
    }

    private void Update()
    {
        if (HasWon)
        {
            SceneManager.LoadScene("EndScene");
        }
    }
}
