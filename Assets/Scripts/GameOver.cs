using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    private Controller _controller;
    private LevelStart _levelStart;
    private Texture2D _restartText;

    void Start()
    {
        _controller = gameObject.AddComponent<Controller>();
        _levelStart = gameObject.AddComponent<LevelStart>();
        _levelStart.sceneName = SceneManager.GetActiveScene().name;
        _restartText = Resources.Load<Texture2D>("restart-text");
    }

    void OnGUI()
    {
        float x = (Screen.width - _restartText.width) / 2f;
        float y = Screen.height - 50;
        if (Time.time % 2 > 1)
        {
            GUI.DrawTexture(new Rect(x, y, _restartText.width, _restartText.height), _restartText);
        }
    }
}
