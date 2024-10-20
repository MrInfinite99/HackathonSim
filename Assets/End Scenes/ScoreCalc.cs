using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreCalc : MonoBehaviour
{
    private float energy, fatigue, totalEnergy;
    private int assistLeft, Score1, Score2, moneyLeft, moneyMax, moneyWeight, assistWeight;

    private float TotalScore;
    private int rank;

    public TextMeshProUGUI rankText;

    private void Awake()
    {
        energy =DataManager.Instance.energyScore;
        fatigue = DataManager.Instance.fatigueScore;
        assistLeft = DataManager.Instance.assistScore ;
        moneyLeft = DataManager.Instance.moneyScore ;
        moneyWeight = 1;
        assistWeight = 1;
        totalEnergy = 100;
        moneyMax = 100;

        Score1= (int)DataManager.Instance.brickGameScore;
        Score2 =(int) DataManager.Instance.virusGameScore;
    }

    // Start is called before the first frame update
    void Start()
    {
        // Calculate total score
        TotalScore = (energy - fatigue) / totalEnergy + assistWeight * assistLeft + Score1 + Score2 + (moneyLeft * moneyWeight / moneyMax);

        // Assign rank based on TotalScore
        AssignRank((int)TotalScore);
    }

    // Function to assign rank based on TotalScore
    void AssignRank(float score)
    {
        if (score >= 570) // Top score range
        {
            rank = 1; // Highest rank
        }
        else if (score >= 513 && score < 570)
        {
            rank = 2;
        }
        else if (score >= 456 && score < 513)
        {
            rank = 3;
        }
        else if (score >= 399 && score < 456)
        {
            rank = 4;
        }
        else if (score >= 342 && score < 399)
        {
            rank = 5;
        }
        else if (score >= 285 && score < 342)
        {
            rank = 6;
        }
        else if (score >= 228 && score < 285)
        {
            rank = 7;
        }
        else if (score >= 171 && score < 228)
        {
            rank = 8;
        }
        else if (score >= 114 && score < 171)
        {
            rank = 9;
        }
        else
        {
            rank = 10; // Lowest rank
        }


        rankText.text = rank.ToString();
        Debug.Log("Rank Assigned: " + rank);
    }
}
