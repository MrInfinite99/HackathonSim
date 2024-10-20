using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
//using UnityEditor.iOS.Xcode; // Import the SceneManagement namespace

public class progressBarManager : MonoBehaviour
{
    public static progressBarManager Instance { get; private set; }

    private Slider progressBar;
    private RawImage progressBarImage;
    public Texture newTexture;
    private Texture defaultTexture;

    // Store the original rotation of the Background
    private Quaternion originalBackgroundRotation;
    private Transform backgroundTransform;

    public Vector3 rotator;
    void Awake()
    {
        // Ensure that only one instance of the ProgressBarManager exists
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Keep this object alive between scenes
        }
        else
        {
            Destroy(gameObject); // Destroy duplicate instances
        }
    }

    void Start()
    {
        progressBar = GameObject.Find("ProgressBar").GetComponent<Slider>();
        progressBarImage = progressBar.GetComponentInChildren<RawImage>();

        if (defaultTexture == null)
        {
          //  defaultTexture = progressBarImage.texture; // Get the current texture as the default texture
        }

        // backgroundTransform = FindChildByTag(progressBar.transform, "Brick");
        //if (backgroundTransform != null)
        //{
          //  originalBackgroundRotation = backgroundTransform.GetComponent<RectTransform>().rotation;
        //}
    }

    private void Update()
    {
         
        ChangeRawImageTexture();
        ChangeProperties();


    }

    private bool IsInSpecificScene(string sceneName)
    {
        // Get the active scene
        Scene currentScene = SceneManager.GetActiveScene();
        // Check if the name matches the specified scene
        return currentScene.name.Equals(sceneName, System.StringComparison.OrdinalIgnoreCase);
    }

    private void ChangeRawImageTexture()
    {
        
        if (IsInSpecificScene("BugScene"))
        {
            
            
        }
        else if (IsInSpecificScene("CodeScene"))
        {
             
        }
    }

    private void ChangeProperties()
    {
        if (IsInSpecificScene("BugScene"))
        {
            //progressBar.transform.rotation.Equals(rotator);
        }
        else if (IsInSpecificScene("CodeScene"))
        {
           // backgroundTransform.rotation = originalBackgroundRotation;
        }
    }

    private Transform FindChildByTag(Transform parent, string tag)
    {
        foreach (Transform child in parent)
        {
            if (child.CompareTag(tag))
                return child; // Return the child with the matching tag
        }
        return null; // Return null if no child with the tag is found
    }
}
