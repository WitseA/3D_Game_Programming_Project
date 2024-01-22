using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class ButtonClick : MonoBehaviour
{

    public void OnStartButtonClicked()
    {
        SceneManager.LoadScene(1);
    }

    public void OnInfoButtonClicked()
    {
        SceneManager.LoadScene("InfoScene");
    }

    public void OnQuitButtonClicked()
    {
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }

    public void OnMenuButtonClicked()
    {
        SceneManager.LoadScene(0);
    }
}
