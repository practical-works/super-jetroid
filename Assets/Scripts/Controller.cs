using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    /*
     * ============================================================
     * ♦ Default Controls:
     * • Direction: Up (y), Down (-y), Right (x), Left (-x)
     * • Action: Space (x), Control (x), Shift (y), Return (-y)
     * ============================================================
    */

    public Vector2 direction;
    public Vector2 action;

    void Update()
    {
        direction = Vector2.zero;
        action = Vector2.zero;

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

        if (Input.GetKeyDown(KeyCode.Space))
        {
            action.x = 1;
        }

        if (Input.GetKeyDown(KeyCode.LeftControl) || Input.GetKeyDown(KeyCode.RightControl))
        {
            action.x = -1;
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift))
        {
            action.y = 1;
        }
        else if (Input.GetKeyDown(KeyCode.Return))
        {
            action.y = -1;
        }
    }
}
