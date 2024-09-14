using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text timerText; // Reference to the UI Text to display the countdown
    public float levelTime = 120f; // The total time for the level (in seconds)

    private float timeRemaining;
    private bool timerRunning = false;

    void Start()
    {
        timeRemaining = levelTime;
        timerRunning = true;
    }

    void Update()
    {
        if (timerRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime; // Decrease the time remaining
                DisplayTime(timeRemaining); // Update the timer display
            }
            else
            {
                timeRemaining = 0;
                timerRunning = false;
                EndLevel(); // Call this when the timer reaches zero
            }
        }
    }

    // Function to format and display the time in MM:SS format
    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1; // To ensure it doesn't show negative time briefly

        int minutes = Mathf.FloorToInt(timeToDisplay / 60); // Convert seconds to minutes
        int seconds = Mathf.FloorToInt(timeToDisplay % 60); // Get the remaining seconds

        // Display formatted time as MM:SS
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    // Function to trigger when time runs out
    void EndLevel()
    {
        Debug.Log("Time is up! Level ends.");
        // Add logic here to end the level, load the next scene, or trigger any event
    }

    // Optional function to stop the countdown early
    public void StopTimer()
    {
        timerRunning = false;
    }

    // Optional function to restart the countdown
    public void RestartTimer()
    {
        timeRemaining = levelTime;
        timerRunning = true;
    }
}

