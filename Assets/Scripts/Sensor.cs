using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sensor : MonoBehaviour
{
    public Transform sightStart;
    public Transform sightEnd;
    public string layerName = "Solid";
    public bool needsCollision = true;

    void Update()
    {
        bool collidedWithSolid = Physics2D.Linecast
        (
            start: sightStart.position,
            end: sightEnd.position,
            layerMask: 1 << LayerMask.NameToLayer(layerName)
        );

        if (collidedWithSolid == needsCollision)
        {
            transform.localScale = Vector3.Scale(transform.localScale, new Vector3(-1, 1, 1));
        }

        //Debug.DrawLine(sightStart.position, sightEnd.position, Color.red);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(sightStart.position, sightEnd.position);
    }
}
