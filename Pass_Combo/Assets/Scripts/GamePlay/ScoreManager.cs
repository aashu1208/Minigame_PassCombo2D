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
            int pointsToAdd = 1; // Base point


            Difficulty difficulty = GameManager.Instance.currentDifficulty;

            if(difficulty == Difficulty.Medium && combo == 3)
            {
                pointsToAdd += 2; // 2 points for 3 combo
                Debug.Log("Combo bonus: 2 points for 3 combo");
            }

            else if(difficulty == Difficulty.Hard && combo == 5)
            {
                pointsToAdd += 3; // 3 points for 5 combo
                Debug.Log("Combo bonus: 3 points for 5 combo");
            }
            else if(difficulty == Difficulty.Hard && combo == 10)
            {
                pointsToAdd += 5; // 5 points for 10 combo
                Debug.Log("Combo bonus: 5 points for 10 combo");
            }

            else if(combo == 5)
            {
                GameManager.Instance.Show_Trigger_Effect();
            }

            score += pointsToAdd;
            Debug.Log("Score: " +score+ " Combo: "+combo);

            // Broadcast Score and combo to UI manager
            GameManager.Instance.Notify("SCORE_UPDATED", score);
            GameManager.Instance.Notify("COMBO_UPDATED", combo);
        }

        else if(eventType == "MISS")
        {
            combo = 0;

            // Apply penalty only in Hard mode
            if(GameManager.Instance.currentDifficulty == Difficulty.Hard)
            {
                score = Mathf.Max(0, score - 1); // Prevent negative score
                Debug.Log("Penalty applied: -1 point for missing in Hard mode. Score: " + score);
                GameManager.Instance.Notify("SCORE_UPDATED", score);
            }
            GameManager.Instance.Notify("COMBO_UPDATED", combo);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
