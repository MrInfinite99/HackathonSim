using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SabotageManager : MonoBehaviour
{
     
    public Button acceptButton;
    private float trustCost =10f;
    void Start()
    {
        acceptButton.onClick.AddListener(OnButtonClick);
    }

    
    void OnButtonClick()
    {
        GameManager.Instance.fatigueBar.value += trustCost;
    }
}
