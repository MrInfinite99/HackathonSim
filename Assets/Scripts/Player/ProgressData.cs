using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Progress Data", menuName = "ScriptableObjects/ProgressData")]
public class ProgressData : ScriptableObject
{
    // Reference to the Slider UI element
    public Slider progressBar;

    // Progress data variable
    [HideInInspector] // Hides this in the inspector since it's updated dynamically
    public float progressData = 0f;

    // Method to update the progress
    public void UpdateProgress(float value)
    {
       // progressData = Mathf.Clamp01(value); // Ensure progress is between 0 and 1
        if (progressBar != null)
        {
            progressBar.value = progressData; // Update the slider's value
        }
    }
}
