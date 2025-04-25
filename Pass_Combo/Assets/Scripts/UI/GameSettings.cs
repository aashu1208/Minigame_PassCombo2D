using UnityEngine;

public class GameSettings : MonoBehaviour
{
    public static GameSettings Instance;
    public Difficulty selectedDifficulty = Difficulty.Medium;
    

    void Awake()
    {

        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
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


public enum Difficulty
{
    Easy,
    Medium,
    Hard
}
