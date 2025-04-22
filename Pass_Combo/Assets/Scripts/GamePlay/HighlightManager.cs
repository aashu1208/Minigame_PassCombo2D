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
        StartCoroutine(HighlightLoop());
    }

    private void OnDestroy()
    {
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
        if(eventType == "GAME_OVER")
        {
            Debug.Log("Stopping highlight loop");
            StopAllCoroutines(); // Stop the highlight loop when the game starts
            GameManager.Instance.ResetHighlights(); // Reset highlights when the game starts
        }
    }
}
