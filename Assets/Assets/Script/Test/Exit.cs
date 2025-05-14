using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerScriptRunner : MonoBehaviour
{
    public SceneSwitcher scene;
    private void OnTriggerEnter(Collider other)
    {
        scene.sceneIndex = 0;
        scene.SwitchScene();
    }
}
