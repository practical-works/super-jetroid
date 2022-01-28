using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floater : MonoBehaviour
{
    public Vector3 duration = new Vector3(2f, 1f, 0f);

    private Vector3 _initialPosition;

    void Start()
    {
        _initialPosition = transform.position;
    }

    void Update()
    {
        Vector3 nextPosition = transform.position;

        if (duration.x != 0)
        {
            nextPosition.x = GetNextCoordinate(_initialPosition.x, duration.x);
        }

        if (duration.y != 0)
        {
            nextPosition.y = GetNextCoordinate(_initialPosition.y, duration.y);
        }

        if (duration.z != 0)
        {
            nextPosition.z = GetNextCoordinate(_initialPosition.z, duration.z);
        }

        transform.position = nextPosition;
    }

    float GetNextCoordinate(float initialCoordinate, float duration)
    {
        return initialCoordinate + (initialCoordinate + Mathf.Cos(Time.time / duration * 2)) / 4;
    }
}
