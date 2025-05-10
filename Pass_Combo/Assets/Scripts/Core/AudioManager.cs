using UnityEngine;

public class AudioManager : MonoBehaviour, ISubscriber
{

    public static AudioManager Instance;

    public AudioClip passCorrect;
    public AudioClip passWrong;
    public AudioClip gameStart;
    public AudioClip gameOver;
    public AudioClip buttonClick;

    private AudioSource source;

    void Awake()
    {
        if(Instance == null)
        {

            Instance = this;
        }
        source = GetComponent<AudioSource>();

    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameManager.Instance.Subscribe(this);
    }

    void OnDestroy()
    {
        GameManager.Instance.Unsubscribe(this);
    }
    public void OnNotify(string eventName, object data)
    {

        switch(eventName)
        {
            case "PlayerPassed":
                Play(passCorrect);
                break;
            case "MISS":
                Play(passWrong);
                break;
            case "GAME_START":
                Play(gameStart);
                break;
            case "GAME_OVER":
                Play(gameOver);
                break;

        }
    }

    public void Play(AudioClip clip)
    {
        if(clip != null)
        {
            source.PlayOneShot(clip);
        }
    }

    public void PlayClick()
    {
        Play(buttonClick);
    }
}
