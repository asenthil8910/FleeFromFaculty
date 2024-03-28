using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    // Load your main game scene here
    public void StartGame()
    {
        SceneManager.LoadScene("ClassScene0");
    }

    // Load your credits scene here
    public void Credits()
    {
        SceneManager.LoadScene("CreditsScene");
    }

    public void StartMenu()
    {
        SceneManager.LoadScene("StartScene");
    }

    public void TutorialScene()
    {
        SceneManager.LoadScene("TutorialScene");
    }
    // Quit the application
    public void QuitGame()
    {
        // Note: This will only work in a build, not in the Unity Editor
        Application.Quit();

        // If you want to be able to quit from the editor, uncomment the line below
        // UnityEditor.EditorApplication.isPlaying = false;
    }
}
