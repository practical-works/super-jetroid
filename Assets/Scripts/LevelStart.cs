using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelStart : MonoBehaviour
{
    public string sceneName;

    private Controller _controller;

    void Start()
    {
        _controller = GetComponent<Controller>();
    }

    void Update()
    {
        if (_controller.action.x > 0 || _controller.action.y < 0)
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}
