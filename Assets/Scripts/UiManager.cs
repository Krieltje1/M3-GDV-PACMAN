using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UiManager : MonoBehaviour
{
    public Button[] MenuButtons;
    public GameObject Settings;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Settings.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Menu Buttons
    public void OnPlayButtonClicked()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void OnGymButtonClicked()
    {
        SceneManager.LoadScene("Gym");
    }

    public void OnSettingsButtonClicked()
    {
        OpenSettings();
    }

    public void OnQuitButtonClicked()
    {
        Application.Quit();
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }

    //Settings Buttons
    public void OpenSettings()
    {
        Settings.SetActive(true);
    }

    public void CloseSettings()
    {
        Settings.SetActive(false);
    }


}
