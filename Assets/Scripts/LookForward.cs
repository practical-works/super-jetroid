using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookForward : MonoBehaviour
{
    public Transform sightStart;
    public Transform sightEnd;
    public bool needsCollision;

    private bool collidedWithSolid;

    void Update()
    {
        int layerMask = 1 << LayerMask.NameToLayer("Solid");
        collidedWithSolid = Physics2D.Linecast(sightStart.position, sightEnd.position, layerMask);

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
