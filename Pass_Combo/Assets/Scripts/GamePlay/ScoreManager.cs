using UnityEngine;

public class ScoreManager : MonoBehaviour, ISubscriber
{
    public int score = 0;
    public int combo = 0;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        GameManager.Instance.Subscribe(this);
        
    }

    void OnDestroy()
    {
        GameManager.Instance.Unsubscribe(this);
    }

    public void OnNotify(string eventType, object data = null)
    {
        if(eventType == "PlayerPassed")
        {
            combo++;
            int points = 1+Mathf.FloorToInt(combo * 0.5f);
            score += points;
            Debug.Log("Score: " +score+ " Combo: "+combo);

            // Broadcast Score and combo to UI manager
            GameManager.Instance.Notify("SCORE_UPDATED", score);
            GameManager.Instance.Notify("COMBO_UPDATED", combo);
        }

        else if(eventType == "MISS")
        {
            combo = 0;
            GameManager.Instance.Notify("COMBO_UPDATED", combo);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
