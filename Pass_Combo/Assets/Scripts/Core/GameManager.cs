using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Scripting;

public class GameManager : MonoBehaviour
{
    private List<ISubscriber> _subscribers = new List<ISubscriber>();
    public static GameManager Instance;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }

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
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
