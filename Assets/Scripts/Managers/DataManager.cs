using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance { get; private set; }
    // Start is called before the first frame update
    public float fatigueScore;
    public float energyScore;
    public int moneyScore;
    public int assistScore;
    public int brickGameScore;
    public int virusGameScore;
    private void Awake()
    {
        // Singleton Pattern
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
 
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        fatigueScore = GameManager.Instance.fatigueBar.value;
         energyScore = GameManager.Instance.energyBar.value;
    }
}
