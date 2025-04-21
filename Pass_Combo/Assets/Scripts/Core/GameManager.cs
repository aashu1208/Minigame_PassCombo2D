using System.Collections.Generic;
using UnityEngine;
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

    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
