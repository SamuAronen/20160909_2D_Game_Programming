using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
namespace Runner
{
    public class GameManager : MonoBehaviour
    {
        #region Statics
        private static GameManager _instance;
        private static bool _isQuitting = false;
        
        public static GameManager Instance
        {
            get
            {
                if (_instance == null && !_isQuitting)
                {
                    _instance = FindObjectOfType<GameManager>();
                    if (_instance == null)
                    {
                        GameObject go = new GameObject("GameManager");
                        _instance = go.AddComponent<GameManager>();
                        _instance.Init();
                    }
                }
                return _instance;
            }
        }

        #endregion
        private Camera _mainCamera;
        private CameraFollow _cameraFollow;
        private GUIManager _guiManager;
        private int _points = 0;
        public GUIManager GUIManager
        {get
            {
                if (_guiManager == null)
                {
                    _guiManager = FindObjectOfType<GUIManager>();
                }

                if (_guiManager == null)
                {
                    Debug.Log("Gamemanager: GUIManager is not found from scene!");
                    Debug.Break();
                }
                return _guiManager;
            }
        }

        private void Awake()
        {
            if (_instance == null)
            {
                _instance = this;
                Init();
            }
            else if (_instance != this)
            {
                Destroy(this);
            }
        }

        private void OnApplicationQuit()
        {
            _isQuitting = true;
        }

        private void Init()
        {
            _mainCamera = Camera.main;
            _cameraFollow = _mainCamera.GetComponent<CameraFollow>();
            Pause(true);
        }

        public void Pause(bool pause)
        {
            if (pause)
            {
                Time.timeScale = 0;
            }
            else
            {
                Time.timeScale = 1;
            }
        }

        public void GameOver()
        {
            _cameraFollow.GameOver();
            GUIManager.GameOver();
            Pause(true);
        }



        public void AddPoints(int points)
        {
            _points += points;
           GUIManager.UpdatePoinits(points);
        }

        public void StartGame()
        {
            Pause(false);
        }


        public void OnNewGamePressed()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}