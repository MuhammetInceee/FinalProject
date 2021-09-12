using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    private static UIManager _instance;
    public static UIManager Instance
    {
        get
        {
            if (_instance == null)
                Debug.LogError("UI Manager is NULL");
            return _instance;
        }
    }
    [SerializeField] private TextMeshProUGUI _aliveEnemyText;
    [SerializeField] private TextMeshProUGUI _timeText;
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private TextMeshProUGUI _bulletCounter;
    public GameObject _gameEndedWin;
    public GameObject _gameEndedLose;
    private float _time = _second;
    public static int _score;
    public static int _second = 60;

    private void Awake()
    {
        _instance = this;
    }
    void Start()
    {
        _time = 60;
        _score = 0;
    }

    void Update()
    {
        UITexts();
    }

    void UITexts()
    {
        // Timer
        if (!GameManager._isPaused && !GameManager._isEnd)
        {
            _time -= Time.deltaTime;
        }
        _second = (int)(_time % 60f);
        _timeText.SetText("Time : " + _second);

        //AliveEnemy
        _aliveEnemyText.SetText("Alive Enemy : " + GameManager._aliveEnemy);

        //Score
        _scoreText.SetText("Score : " + _score);

        //Bullet Counter
        _bulletCounter.SetText("Remain Bullet : " + Weapon._bulletCount);
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void Restart()
    {
        SceneManager.LoadScene(1);
    }
    public void Exit()
    {
        Application.Quit();
    }
}
