using UnityEngine;
using UnityEngine.UI;
using System.Collections;


namespace Runner
{

    public class GUIManager : MonoBehaviour
    {
        [SerializeField] private Text _message;
        [SerializeField] private Text _points;
        [SerializeField] private Button _startGameButton;
        [SerializeField] private Button _newGameButton;
        private void Awake()
        {

            if (_message == null)
            {
                Debug.LogError("GUIManager: _message is null!");
                Debug.Break();
            }
            if (_points == null)
            {
                Debug.LogError("GUIManager: _points is null!");
                Debug.Break();
            }
            if (_startGameButton == null)
            {
                Debug.LogError("GUIManager: _startGameButton is null!");
                Debug.Break();
            }
            if (_newGameButton == null)
            {
                Debug.LogError("GUIManager: _newGameButton is null!");
                Debug.Break();
            }

            _newGameButton.gameObject.SetActive(false);
            HideMessage();
        }

        public void ShowMessage(string message)
        {
            _message.text = message;
            _message.gameObject.SetActive(true);
        }

        public void HideMessage()
        {
            _message.gameObject.SetActive(false);
        }

        public void UpdatePoinits(int points)
        {
            _points.text = string.Format("Points {0}", points);
        }

        public void StartGame()
        {
            _startGameButton.gameObject.SetActive(false);
        }


        public void GameOver()
        {
            ShowMessage("Game Over!");
            _newGameButton.gameObject.SetActive(true);
        }
    }
}