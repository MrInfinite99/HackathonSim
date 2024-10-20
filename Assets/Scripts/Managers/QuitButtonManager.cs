using UnityEngine;

public class QuitButtonManager : MonoBehaviour
{
    // This function will be called when the quit button is clicked.
    public void QuitGame()
    {
        // If running in the Unity Editor, stop play mode.
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        // If built as a standalone app, quit the application.
        Application.Quit();
#endif
        Debug.Log("Quit Game");
    }
}
