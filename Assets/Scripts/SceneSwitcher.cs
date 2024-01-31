using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public string scene_name;

    public void SwitchScene()
    {
        SceneManager.LoadScene(scene_name);
    }
}
