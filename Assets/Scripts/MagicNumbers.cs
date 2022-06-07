using TMPro;
using UnityEngine;
using Button = UnityEngine.UI.Button;

public class MagicNumbers : MonoBehaviour
{
    [SerializeField] private int _min;
    [SerializeField] private int _max;
    [SerializeField] private TextMeshProUGUI InfoLabel;
    [SerializeField] private TextMeshProUGUI GuessLabel;
    [SerializeField] private TextMeshProUGUI CountAttemptsLabel;
    [SerializeField] private Button MoreButton;
    [SerializeField] private Button LessButton;
    [SerializeField] private Button FinishButton;
    private int _countAttempts;
    private int _guess;
    private int _minReset;
    private int _maxReset;

    private void Start()
    {
        _minReset = _min;
        _maxReset = _max;
        
        MoreButton.onClick.AddListener(MoreButtonClicked);
        LessButton.onClick.AddListener(LessButtonClicked);
        FinishButton.onClick.AddListener(FinishButtonClicked);
        
        SetInfoText($"Задагай число от {_min} до {_max}");
        
        GuessNumber();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _min = _minReset;
            _max = _maxReset;
            _countAttempts = 0;
            
            FinishButton.interactable = true;
            LessButton.interactable = true;
            MoreButton.interactable = true;
            
            SetCountAttemptsText("");
            
            GuessNumber();
        }
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
        SetGuessText($"Победа! Твое число: {_guess}");
        SetCountAttemptsText($"Attempts: {_countAttempts}");

        FinishButton.interactable = false;
        LessButton.interactable = false;
        MoreButton.interactable = false;
    }

    private void LessButtonClicked()
    {
        _max = _guess;
        GuessNumber();
    }
    
    private void SetInfoText(string text)
    {
        InfoLabel.text = text;
    }

    private void SetGuessText(string text)
    {
        GuessLabel.text = text;
    }

    private void SetCountAttemptsText(string text)
    {
        CountAttemptsLabel.text = text;
    }
}