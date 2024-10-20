using UnityEngine;
using UnityEngine.UI;

public class ClockUIManager : MonoBehaviour
{
    public Sprite[] numberSprites;  // Sprites for numbers 0-9
    public Image hourTens, hourUnits;  // UI Images for clock digits

    private int previousHour = -1;
    private void Start()
    {
        // Get the current hour from the HourCountdownClock singleton
        int currentHour = clockSystem.Instance.CurrentHour;

        // Update the UI to reflect the current time
        

        if (currentHour != previousHour)
        {
            UpdateHourDisplay(currentHour);
            previousHour = currentHour;
        }
    }
    private void Update()
    {
        int currentHour = clockSystem.Instance.CurrentHour;
        UpdateHourDisplay(currentHour);
    }
    private void UpdateHourDisplay(int hour)
    {
        int tens = hour / 10;
        int units = hour % 10;

        // Update the sprites for the tens and units place
        hourTens.sprite = numberSprites[tens];
        hourUnits.sprite = numberSprites[units];
    }
}
