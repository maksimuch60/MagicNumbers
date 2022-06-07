using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    #region Variables

    private static SceneLoader _sceneLoader;
    public static SceneLoader Instance => _sceneLoader;

    #endregion


    #region Unity lifecycle

    private void Awake()
    {
        if (_sceneLoader != null)
        {
            Destroy(gameObject);
            return;
        }

        _sceneLoader = this;
        DontDestroyOnLoad(gameObject);
    }

    #endregion


    #region Public methods

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    #endregion
}