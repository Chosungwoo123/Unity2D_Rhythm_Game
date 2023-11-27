using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public GameObject whiteBackGround;
    public KeyCode keyCode;
    public GameObject notePrefab;
    public LongNote longNotePrefab;

    private Transform clickPos;
    private float clickTime;

    private void Start()
    {
        if (GameManager.Instance.editMode)
        {
            clickPos = new GameObject().GetComponent<Transform>();
            clickPos.parent = GameManager.Instance.noteParent;
        }
    }

    private void Update()
    {
        ButtonUpdate();
    }

    private void ButtonUpdate()
    {
        if (GameManager.Instance.editMode)
        {
            if (Input.GetKeyDown(keyCode))
            {
                whiteBackGround.SetActive(true);
                clickTime = Time.time;

                clickPos.position = transform.position;
                clickPos.parent = GameManager.Instance.noteParent;
            }

            if (Input.GetKeyUp(keyCode))
            {
                whiteBackGround.SetActive(false);

                if (Time.time - clickTime >= 0.5f)
                {
                    Debug.Log("롱노트");

                    var longNote = Instantiate(longNotePrefab, transform.position, Quaternion.identity);
                    
                    longNote.Init(clickPos.position, transform.position);
                    longNote.transform.parent = GameManager.Instance.noteParent;
                    
                    return;
                }

                var note = Instantiate(notePrefab, clickPos.position, Quaternion.identity);
                note.transform.parent = GameManager.Instance.noteParent;
            }
        }
    }
}