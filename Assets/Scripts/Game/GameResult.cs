using UnityEngine;

namespace Game
{
    public class GameResult : MonoBehaviour
    {
        #region Variables

        public int Attempts { get; set; }
        public int MinGuess { get; set; }
        public int MaxGuess { get; set; }
        public int WinNumber { get; set; }

        private static GameResult _gameResult;

        public static GameResult Instance => _gameResult;

        #endregion


        #region Unity lifecycle

        private void Awake()
        {
            if (_gameResult != null)
            {
                Destroy(gameObject);
                return;
            }

            _gameResult = this;
            DontDestroyOnLoad(gameObject);
        }

        #endregion
    }
}