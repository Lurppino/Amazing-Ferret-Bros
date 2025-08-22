using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Call this on button click
    public void PlayGame()
    {
        SceneManager.LoadScene("Level1"); // must match your scene name exactly
    }

    public void QuitGame()
    {
        Debug.Log("Quit Game!");
        Application.Quit(); // works in build, not in editor
    }
}