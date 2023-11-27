using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LongNote : MonoBehaviour
{
    public GameObject endObj;

    private LineRenderer line;

    public void Init(Vector3 start, Vector3 end)
    {
        transform.position = start;
        endObj.transform.position = end;

        line = GetComponent<LineRenderer>();
    }

    private void Update()
    {
        line.SetPosition(0, transform.position);
        line.SetPosition(1, endObj.transform.position);
    }
}