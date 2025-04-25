using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DifficultyDropdownHandler : MonoBehaviour
{

    public TMP_Dropdown difficultyDropdown;

    public void OnStartButtonPressed()
    {

        int index = difficultyDropdown.value;

        GameSettings.Instance.selectedDifficulty = (Difficulty)index;
        Debug.Log("Selected difficulty: " + GameSettings.Instance.selectedDifficulty);

        SceneManager.LoadScene("GameScene");
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
