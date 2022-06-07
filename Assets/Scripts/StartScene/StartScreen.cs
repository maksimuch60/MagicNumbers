using Game;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace StartScene
{
    public class StartScreen : MonoBehaviour
    {
        #region Variables

        [SerializeField] private TextMeshProUGUI _lastGameResultLabel;

        [SerializeField] private Button _startButton;
        [SerializeField] private string _sceneName;

        [SerializeField] private Button _exitButton;

        #endregion


        #region Unity lifecycle

        private void Awake()
        {
            _startButton.onClick.AddListener(StartButtonClicked);
            _exitButton.onClick.AddListener(ExitButtonClicked);

            SetLastGameResultText();
        }

        #endregion


        #region Private Methods

        private void ExitButtonClicked()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }

        private void StartButtonClicked()
        {
            SceneLoader.Instance.LoadScene(_sceneName);
        }

        private void SetLastGameResultText()
        {
            if (GameResult.Instance == null)
            {
                return;
            }
            
            _lastGameResultLabel.text +=
                $"Диапозон: от {GameResult.Instance.MinGuess} до {GameResult.Instance.MaxGuess}\n" +
                $"Ваше число: {GameResult.Instance.WinNumber}\n" +
                $"Количесвто попыток: {GameResult.Instance.Attempts}";
        }

        #endregion
    }
}