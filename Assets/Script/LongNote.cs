using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LongNote : MonoBehaviour
{
    public GameObject endObj;

    private bool press = false;

    private Vector3 startPos;

    private LineRenderer line;

    private void Start()
    {
        line = GetComponent<LineRenderer>();
    }

    public void Init(Vector3 start, Vector3 end)
    {
        transform.position = start;
        endObj.transform.position = end;

        line = GetComponent<LineRenderer>();
    }
    
    public void StartPress(Vector3 buttonPos)
    {
        if (Vector3.Distance(transform.position, buttonPos) > 1)
        {
            Destroy(gameObject);
            return;
        }

        startPos = buttonPos;
        press = true;
    }

    private void Update()
    {
        line.SetPosition(0, press ? startPos : transform.position);
        line.SetPosition(1, endObj.transform.position);
    }
}