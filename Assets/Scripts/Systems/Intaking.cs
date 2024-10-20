using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Intaking : MonoBehaviour
{
    private int totalMoney = 50;
    private float energy;
    private float fatigue;

    public TextMeshProUGUI moneytxt;
    public GameObject moneyError;

    public GameManager gameManager;

    private void Start()
    {
        moneytxt.text = "Money : " + totalMoney.ToString();
       // gameManager.haltProgress = true;
    }

    private bool Buy(int amount)
    {
        if (totalMoney - amount >= 0) // Check if there's enough money before purchasing
        {
            totalMoney -= amount;
            moneytxt.text = "Money : " + totalMoney.ToString();
            DataManager.Instance.moneyScore = totalMoney;
            return true;
        }
        else
        {
            moneyError.SetActive(true);
            StartCoroutine(nameof(closeErrorWindow)); // Show error if not enough money
            return false;
        }
    }

    private void EnergyInc(float amount)
    {
        gameManager.energyBar.value += amount;
    }

    private void FatigueDec(float amount)
    {
        gameManager.fatigueBar.value -= amount;
    }

    public void BuyApple()
    {
        if (Buy(5))  // Only call EnergyInc if Buy is successful
        {
            EnergyInc(10);
        }
    }

    public void BuyMessFood()
    {
        if (Buy(20))  // Only call EnergyInc and FatigueDec if Buy is successful
        {
            EnergyInc(30);
            FatigueDec(5);
        }
    }

    public void BuySedatives()
    {
        if (Buy(10))  // Only call FatigueDec if Buy is successful
        {
            FatigueDec(25);
        }
    }

    IEnumerator closeErrorWindow()
    {
        yield return new WaitForSeconds(1f);
        moneyError.SetActive(false);
    }

    public void BoolChanger1()
    {
        gameManager.haltProgress = false;
    }

    public void BoolChanger2()
    {
        gameManager.haltProgress = true;
    }
}