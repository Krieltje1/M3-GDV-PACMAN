using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class UiManager : MonoBehaviour
{
    public Button[] MenuButtons;
    public GameObject Settings;
    public GameObject Pause;

    bool isPaused = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Settings.SetActive(false);
        Pause.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && isPaused == false)
        {
            OpenPause();
        }
        else if(Input.GetKeyDown(KeyCode.Escape) && isPaused == true)
        {
            ClosePause();
        }
        
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

    //Pause Menu
    public void OpenPause()
    {
            Pause.SetActive(true);
            Debug.Log("Paused");
            isPaused = true;
            Time.timeScale = 0;
    }
    
    public void ClosePause()
    {
            Pause.SetActive(false);
            Debug.Log("Unpaused");
            isPaused = false;
            Time.timeScale = 1;

    }

    public void OnQuitToMenuButtonClicked()
    {
        SceneManager.LoadScene("Menu");
    }

}
