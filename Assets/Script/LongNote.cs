using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LongNote : MonoBehaviour
{
    public GameObject endObj;

    private bool press = false;

    private Vector3 startPos;

    private Button targetButton;

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
    
    public void StartPress(Vector3 buttonPos, Button _button)
    {
        if (Vector3.Distance(transform.position, buttonPos) > 1)
        {
            Destroy(gameObject);
            return;
        }

        targetButton = _button;
        startPos = buttonPos;
        press = true;
        targetButton.press = press;
        
        endObj.GetComponent<LongNoteEnd>().Init(this);
    }

    public void StopPress(bool reset)
    {
        if (reset)
        {
            GameManager.Instance.ResetCombo();
        }
        else if (!reset)
        {
            GameManager.Instance.PlusCombo();
        }
        
        press = false;
        targetButton.press = press;
        targetButton.pressEffect.gameObject.SetActive(false);
        
        Destroy(gameObject);
    }

    private void Update()
    {
        if (press)
        {
            line.SetPosition(0, startPos);
        }
        else
        {
            line.SetPosition(0, transform.position);
        }
        
        line.SetPosition(1, endObj.transform.position);
    }
}