using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject gameoverText;
    public Text timeText;
    public Text recordText;

    private float _surviveTime;
    private bool _isGameover;
    void Start()
    {
        _surviveTime = 0;
        _isGameover = false;
    }

    void Update()
    {
        if (!_isGameover)
        {
            _surviveTime += Time.deltaTime;
            timeText.text = "Time: " + (int)_surviveTime;
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene("MainScene");
            }
        }
    }

    public void EndGame()
    {
        _isGameover = true;
        gameoverText.SetActive(true);

        float bestTime = PlayerPrefs.GetFloat("BestTime");

        if (_surviveTime > bestTime)
        {
            bestTime = _surviveTime;
            PlayerPrefs.SetFloat("BestTime", bestTime);
        }

        recordText.text = "Best Time: " + (int)bestTime;
    }
}
