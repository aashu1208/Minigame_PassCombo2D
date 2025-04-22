using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighlightManager : MonoBehaviour
{
    public List<GameObject> teammates; // Assign teammates in Inspector
    public float highlightDuration = 1.0f;

    public static GameObject currentHighlighted;

    private void Start()
    {
        StartCoroutine(HighlightLoop());
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
}
