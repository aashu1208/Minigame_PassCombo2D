using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour, ISubscriber
{

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI comboText;

    public TextMeshProUGUI timerText;

    public GameObject gameOverPanel;
    public TextMeshProUGUI finalScoreText;
    public TextMeshProUGUI finalComboText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameManager.Instance.Subscribe(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnDestroy()
    {

        if(GameManager.Instance != null)

            GameManager.Instance.Unsubscribe(this);
    }

    public void OnNotify(string eventType, object data = null)
    {

        if(eventType == "SCORE_UPDATED")
        {
            int newScore = (int)data;
            scoreText.text = ""+newScore.ToString();
        }

        if(eventType == "COMBO_UPDATED")
        {
            int newCombo = (int)data;

            if(newCombo > 1)
                comboText.text = ""+newCombo.ToString();

            else
                comboText.text = ""+newCombo.ToString();
        }

        if(eventType == "TIMER_UPDATED")
        {
            int timeLeft = (int)data;
            timerText.text = "Timer: "+timeLeft+ "s";
        }

        if(eventType == "GAME_OVER")
        {

            gameOverPanel.SetActive(true);
            finalScoreText.text = "Final Score: "+scoreText.text;
            finalComboText.text = "Final Combo: "+comboText.text;
        }


    }

    public void PlayAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
