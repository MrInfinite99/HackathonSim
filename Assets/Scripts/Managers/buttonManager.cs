using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    // Create arrays or lists to hold buttons and their corresponding scene names
    public Button[] buttons; // Array of buttons
    public string[] scenes; // Array of scene names

    void Start()
    {     
        if (buttons.Length != scenes.Length)
        {
            Debug.LogError("The number of buttons and scenes must match.");
            return;
        }

        // Loop through all buttons and assign listeners
        for (int i = 0; i < buttons.Length; i++)
        {
            ButtonClick(buttons[i], scenes[i]);
        }
    }

    void ButtonClick(Button button, string scene)
    {
        button.onClick.AddListener(() => OnButtonClick(scene));
    }

    void OnButtonClick(string scene)
    {
        SceneManager.LoadScene(scene);
       
    }
}
