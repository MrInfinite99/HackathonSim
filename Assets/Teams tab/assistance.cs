//using InfimaGames.LowPolyShooterPack.Interface;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class assistance : MonoBehaviour
{
    private int TotalAssists = 50;
   // public GameManager gameManager;
 

    public GameObject insufficientWindow;
    public TextMeshProUGUI assistTxt;

    private void Start()
    {
        assistTxt.text = "Assists Left : " + TotalAssists.ToString();
    }

    private bool CanAssist(int assistPts)
    {
        if (TotalAssists - assistPts >= 0)
        {
            TotalAssists -= assistPts;
            assistTxt.text = "Assists Left : " + TotalAssists.ToString();
            DataManager.Instance.assistScore = TotalAssists;
            return true;
        }
        else
        {
            Debug.Log("Not enough assists available.");
            insufficientWindow.SetActive(true);
            StartCoroutine(nameof(insufficientAssists));
            return false;
        }
    }

    private void FatigueChange(float amount)
    {
        GameManager.Instance.fatigueBar.value += amount;
    }

    private void ProgressChange(float amount)
    {
        GameManager.Instance.progressBar.value += amount;
    }

    private void EnergyChange(float amount)
    {
        GameManager.Instance.energyBar.value += amount;
    }

    public void blender()
    {
        if (CanAssist(10)) // Only apply changes if there are enough assists
        {
            ProgressChange(10);
            FatigueChange(3);
        }
    }

    public void TwoDimDesign()
    {
        if (CanAssist(3)) // Only apply changes if there are enough assists
        {
            ProgressChange(3);
            FatigueChange(1);
        }
    }

    public void UnityDev()
    {
        if (CanAssist(10)) // Only apply changes if there are enough assists
        {
            ProgressChange(15);
            FatigueChange(4);
        }
    }

    public void mixamo()
    {
        if (CanAssist(1)) // Only apply changes if there are enough assists
        {
            ProgressChange(4);
            FatigueChange(2);
        }
    }

    public void ytTutorials()
    {
        if (CanAssist(3)) // Only apply changes if there are enough assists
        {
            ProgressChange(4);
            FatigueChange(3);
        }
    }

    public void Food()
    {
        if (CanAssist(8)) // Only apply changes if there are enough assists
        {
            EnergyChange(10);
            FatigueChange(-4);
        }
    }

    private IEnumerator insufficientAssists()
    {
        yield return new WaitForSeconds(1f);
        insufficientWindow.SetActive(false);

    }
    public void Back()
    {
        SceneManager.LoadScene("CodeScene");
    }
}
