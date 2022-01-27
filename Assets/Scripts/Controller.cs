using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public Vector2 direction;

    void Update()
    {
        direction = Vector2.zero;

        if (Input.GetKey(KeyCode.RightArrow))
        {
            direction.x = 1;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            direction.x = -1;
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            direction.y = 1;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            direction.y = -1;
        }
    }
}
