using Game;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace EndScene
{
    public class EndScreen : MonoBehaviour
    {
        #region Variables

        [SerializeField] private TextMeshProUGUI _winLabel;
        [SerializeField] private TextMeshProUGUI _gameResultLabel;

        [SerializeField] private Button _playAgainButton;
        [SerializeField] private Button _exitButton;

        #endregion


        #region Unity lifecycle

        private void Awake()
        {
            SetWinText("Победа!");
            SetGameResultText($"Ваше число: {GameResult.Instance.WinNumber}\n" +
                $"Количество попыток: {GameResult.Instance.Attempts}");

            _playAgainButton.onClick.AddListener(PlayAgainButtonClicked);
            _exitButton.onClick.AddListener(ExitButtonClicked);
        }

        #endregion


        #region Private methods

        private void ExitButtonClicked()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }

        private void PlayAgainButtonClicked()
        {
            SceneLoader.Instance.LoadScene("StartScene");
        }

        private void SetWinText(string text)
        {
            _winLabel.text = text;
        }

        private void SetGameResultText(string text)
        {
            _gameResultLabel.text = text;
        }

        #endregion
    }
}