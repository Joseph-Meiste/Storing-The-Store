using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public int sceneIndex; 

    public void SwitchScene()
    {
        SceneManager.LoadScene(sceneIndex);
    }
}
