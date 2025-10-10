using UnityEngine;
using UnityEngine.SceneManagement;

public class ArenaManager : MonoBehaviour
{
    public Transform playerSpawn;

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "Arena" && Player.instance != null && playerSpawn != null)
        {
            Player.instance.transform.position = playerSpawn.position;
        }
    }
}
