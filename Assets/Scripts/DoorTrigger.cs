using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    public Door[] doors;
    public bool sticky;

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (doors != null)
        {
            foreach (Door door in doors)
            {
                if (door != null)
                {
                    door.Open();
                }
            }
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if (!sticky && doors != null)
        {
            foreach (Door door in doors)
            {
                if (door != null)
                {
                    door.Close();
                }
            }
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = sticky ? Color.red : Color.green;
        if (doors != null)
        {
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
}
