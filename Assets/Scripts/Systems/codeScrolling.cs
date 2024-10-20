using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CodeScrolling : MonoBehaviour
{
    public TextMeshProUGUI codeText;  // Assign your TextMeshPro component here
    public float scrollSpeed = 30f;

    private RectTransform textRect;

    void Start()
    {
        textRect = codeText.GetComponent<RectTransform>();
    }

    void Update()
    {
        // Modify only the y value of the anchoredPosition
        float newY = textRect.anchoredPosition.y + scrollSpeed * Time.deltaTime;
        textRect.anchoredPosition = new Vector2(textRect.anchoredPosition.x, newY);

        // Reset the position if it scrolls too far
        if (newY > 98f)
        {
            textRect.anchoredPosition = new Vector2(textRect.anchoredPosition.x, -100f);
        }
    }
}
