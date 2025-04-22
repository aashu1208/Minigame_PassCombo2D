using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour, ISubscriber
{

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI comboText;
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
            scoreText.text = "Score: "+newScore.ToString();
        }

        if(eventType == "COMBO_UPDATED")
        {
            int newCombo = (int)data;

            if(newCombo > 1)
                comboText.text = "Combo: "+newCombo.ToString();

            else
                comboText.text = "";
        }


    }
}
