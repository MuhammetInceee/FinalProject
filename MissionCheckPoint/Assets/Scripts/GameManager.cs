using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
                Debug.LogError("Game Manager is NULL");
            return _instance;
        }
    }

    public static int _aliveEnemy = 5;
    public static bool _isPaused { get; private set; } //ENCAPSULATION
    public static bool _isEnd { get; private set; } //ENCAPSULATION

    private void Awake()
    {
        _instance = this;
    }
    void Start()
    {
        _aliveEnemy = 5;
        _isEnd = false;
        _isPaused = false;
    }

    void Update()
    {
        Win();
        Lose();
    }
    void Win()
    {
        if(_aliveEnemy == 0)
        {
            _isEnd = true;
            UIManager.Instance._gameEndedWin.SetActive(true);
        }
    }
    void Lose()
    {
        if((UIManager._second == 0 && _aliveEnemy != 0) || (Weapon._bulletCount == 0 && _aliveEnemy != 0))
        {
            _isEnd = true;
            UIManager.Instance._gameEndedLose.SetActive(true);
        }
    }
}
