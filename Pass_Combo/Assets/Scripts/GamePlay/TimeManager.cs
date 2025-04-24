using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public float gameDuration = 30f; // Total game duration in seconds
    private float currentTime;
    private bool isRunning = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentTime = gameDuration;
        isRunning = true;
        GameManager.Instance.StartGame(); // Notify game start
    }

    // Update is called once per frame
    void Update()
    {
        if(!isRunning) return;

        currentTime -= Time.deltaTime;

        // Update timer UI
        GameManager.Instance.Notify("TIMER_UPDATED", Mathf.CeilToInt(currentTime));

        if(currentTime <= 0)
        {
            currentTime = 0;
            isRunning = false;

            // game over
            GameManager.Instance.EndGame(); // Trigger Game Over
            Debug.Log("<color=red> Game Over! Time's up! </color>");
        }
    }


    public void StopTimer()
    {
        isRunning = false;
    }

    public void ResetTimer()
    {
        currentTime = gameDuration;
        isRunning = true;
    }
}
