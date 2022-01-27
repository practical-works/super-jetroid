using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    public Door[] doors;
    public bool sticky;

    void OnTriggerEnter2D(Collider2D collider)
    {
        foreach (Door door in doors)
        {
            if (door != null)
            {
                door.Open();
            }
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if (sticky)
        {
            return;
        }

        foreach (Door door in doors)
        {
            if (door != null)
            {
                door.Close();
            }
        }
    }

    void OnDrawGizmos()
    {
        if (doors == null || doors.Length == 0)
        {
            return;
        }

        Gizmos.color = sticky ? Color.red : Color.green;

        foreach (Door door in doors)
        {
            if (door != null)
            {
                Gizmos.DrawLine(transform.position, door.transform.position);
                Gizmos.DrawWireCube(door.transform.position, door.GetComponent<SpriteRenderer>().size);
            }
        }
    }
}
