using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.Scripting;

public class GameManager : MonoBehaviour
{
    public List<ISubscriber> _subscribers = new List<ISubscriber>();
    public static GameManager Instance;
    public GameObject askingPanel;
    public Difficulty currentDifficulty;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        currentDifficulty = GameSettings.Instance.selectedDifficulty;

    }

    public void Subscribe(ISubscriber subscriber)
    {
        if(!_subscribers.Contains(subscriber))
        {
            _subscribers.Add(subscriber);
        }
    }

    public void Unsubscribe(ISubscriber subscriber)
    {
        if(_subscribers.Contains(subscriber))
        {
            _subscribers.Remove(subscriber);
        }
    }

    public void Notify(string eventType, object data = null)
    {
        foreach(var sub in _subscribers)
        {
            sub.OnNotify(eventType, data);
        }
    }

    public void StartGame()
    {
        Notify("GAME_START");
    }


    public void EndGame()
    {

        Notify("GAME_OVER");

    }

    public void PlayerPassed(GameObject passedTo)
    {
        Notify("PlayerPassed", passedTo);
    }

    public void HighlightTeammate(GameObject teammate)
    {
        Notify("HIGHLIGHT_TEAMMATE", teammate);
    }

    public void ResetHighlights()
    {
        Notify("RESET_HIGHLIGHTS");
    }


    public void Show_Trigger_Effect()
    {

        Notify("SHOW_TRIGGER_EFFECT");
    }
    

    public void MM()
    {
        SceneManager.LoadScene("MenuScene");
    }
    public void Asking_Panel()
    {
        askingPanel.SetActive(true);
    }

    public void Close_Ask_Panel()
    {
        askingPanel.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    
}


