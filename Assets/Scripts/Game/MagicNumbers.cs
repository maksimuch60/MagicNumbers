using TMPro;
using UnityEngine;
using Button = UnityEngine.UI.Button;

namespace Game
{
    public class MagicNumbers : MonoBehaviour
    {
        #region Variables

        [SerializeField] private int _minValue;
        [SerializeField] private int _maxValue;
        [SerializeField] private TextMeshProUGUI _infoLabel;
        [SerializeField] private TextMeshProUGUI _guessLabel;
        [SerializeField] private Button _moreButton;
        [SerializeField] private Button _lessButton;
        [SerializeField] private Button _finishButton;
        private int _countAttempts;
        private int _guess;
        private int _min;
        private int _max;

        #endregion


        #region Unity lifecycle

        private void Start()
        {
            GameResult.Instance.MinGuess = _minValue;
            GameResult.Instance.MaxGuess = _maxValue;

            _min = _minValue;
            _max = _maxValue;

            _moreButton.onClick.AddListener(MoreButtonClicked);
            _lessButton.onClick.AddListener(LessButtonClicked);
            _finishButton.onClick.AddListener(FinishButtonClicked);

            SetInfoText($"Задагай число от {_min} до {_max}");

            GuessNumber();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Reset();
                GuessNumber();
            }
        }

        #endregion


        #region Private methods

        private void Reset()
        {
            _min = _minValue;
            _max = _maxValue;
            _countAttempts = 0;
        }

        private void GuessNumber()
        {
            _guess = (_max + _min) / 2;
            SetGuessText($"Твое число {_guess}?");
            _countAttempts += 1;
        }

        private void MoreButtonClicked()
        {
            _min = _guess;
            GuessNumber();
        }

        private void FinishButtonClicked()
        {
            GameResult.Instance.Attempts = _countAttempts;
            GameResult.Instance.WinNumber = _guess;
            SceneLoader.Instance.LoadScene("EndScene");
        }

        private void LessButtonClicked()
        {
            _max = _guess;
            GuessNumber();
        }

        private void SetInfoText(string text)
        {
            _infoLabel.text = text;
        }

        private void SetGuessText(string text)
        {
            _guessLabel.text = text;
        }

        #endregion
    }
}