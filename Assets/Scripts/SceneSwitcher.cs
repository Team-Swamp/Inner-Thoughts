using UnityEngine;
using UnityEngine.SceneManagement;

public sealed class SceneSwitcher : MonoBehaviour
{
    [SerializeField] private string gameplayScene;

    private void Start()
    {
        SceneManager.LoadScene(gameplayScene);
    }
}
