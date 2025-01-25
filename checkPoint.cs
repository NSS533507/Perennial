using UnityEngine;
using UnityEngine.SceneManagement;

public class checkPoint : MonoBehaviour
{
    public GameObject checkPointObject;
    private bool reachedCheckpoint = false;

    public void Update()
    {
        if (!reachedCheckpoint)
        {
            reachedCheckpoint = true;
            StartCoroutine(ChangeScreenWithDelay());
        }
    }

    private IEnumerator ChangeScreenWithDelay()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("level 2"); // Replace "NextSceneName" with the actual scene name you want to load
    }
}
