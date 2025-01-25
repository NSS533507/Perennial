using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneManage : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public static sceneManage instance;

    void Awake()
    {
        // Implement the Singleton pattern
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Keep the object alive between scenes
        }
        else
        {
            Destroy(gameObject); // Destroy duplicate instance
        }
    }

    void Start()
    {
        // Any logic you want to perform at the start
    }

    // Function to load the next scene based on the build index
    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    // Function to load a specific scene by name
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
