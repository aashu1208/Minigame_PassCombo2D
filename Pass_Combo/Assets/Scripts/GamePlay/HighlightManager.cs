using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighlightManager : MonoBehaviour, ISubscriber
{
    public List<GameObject> teammates; // Assign teammates in Inspector
    public float highlightDuration = 1.0f;

    public static GameObject currentHighlighted;

    private void Start()
    {
        GameManager.Instance.Subscribe(this);

        SetDifficultyTiming(); // ✅ Apply timing based on selected difficulty

        StartCoroutine(HighlightLoop());
    }

    private void OnDestroy()
    {
        if (GameManager.Instance != null)
            GameManager.Instance.Unsubscribe(this);
    }

    private IEnumerator HighlightLoop()
    {
        while (true)
        {
            Debug.Log("Highlight loop running");

            GameManager.Instance.ResetHighlights();

            int index = Random.Range(0, teammates.Count);
            currentHighlighted = teammates[index];

            GameManager.Instance.HighlightTeammate(currentHighlighted);

            yield return new WaitForSeconds(highlightDuration);

            GameManager.Instance.ResetHighlights();
        }
    }

    public void OnNotify(string eventType, object data = null)
    {
        if (eventType == "GAME_OVER")
        {
            Debug.Log("🛑 Stopping highlight loop on GAME_OVER");
            StopAllCoroutines();
            GameManager.Instance.ResetHighlights();
        }
    }

    private void SetDifficultyTiming()
    {
        switch (GameManager.Instance.currentDifficulty)
        {
            case Difficulty.Easy:
                highlightDuration = 1.5f;
                break;
            case Difficulty.Medium:
                highlightDuration = 1.0f;
                break;
            case Difficulty.Hard:
                highlightDuration = 0.6f;
                break;
        }

        Debug.Log("⏱️ Highlight duration set to: " + highlightDuration);
    }
}
