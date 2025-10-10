using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Button continueButton;

    void Start()
    {
        // continueButton.interactable = SaveSystem.SaveExists();
    }

    public void NewGame()
    {
        // SaveSystem.DeleteSave();
        SceneManager.LoadScene("SampleScene"); // your overworld scene
    }

    public void ContinueGame()
    {
        // Player player = SaveSystem.LoadPlayer();
        PlayerHolder.LoadedPlayerData = SaveSystem.LoadPlayerData();
        SceneManager.LoadScene("SampleScene"); // load same scene
        // The Player script will call LoadPlayer() in Start or Awake
    }

    public void QuitGame()
    {
        Application.Quit();
        // for testing
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}