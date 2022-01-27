using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cameraman : MonoBehaviour
{
    public GameObject target;
    public bool adjustRatio;

    void Awake()
    {
        if (adjustRatio)
        {
            GetComponent<Camera>().orthographicSize = (Screen.height / 2.0f) / 100f;
        }
    }

    void Update()
    {
        if (target == null)
        {
            return;
        }

        Vector3 targetPosition = target.transform.position;
        Vector3 cameraPostion = transform.position;
        transform.position = new Vector3(targetPosition.x, targetPosition.y, cameraPostion.z);
    }

}
