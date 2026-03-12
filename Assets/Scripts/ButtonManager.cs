using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayButtonScript : MonoBehaviour
{
    public Button[] MenuButtons;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPlayButtonClicked()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void OnGymButtonClicked()
    {
        SceneManager.LoadScene("Gym");
    }

    public void OnQuitButtonClicked()
    {
        Application.Quit();
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}
