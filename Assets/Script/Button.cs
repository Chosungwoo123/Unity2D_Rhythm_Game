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
    public LayerMask noteLayer;

    public Vector2 judgmentRange;

    public bool press = false;

    private LongNote _longNote;
    private Animator anim;
    private Transform clickPos;
    private float clickTime;

    private void Start()
    {
        if (GameManager.Instance.editMode)
        {
            clickPos = new GameObject().GetComponent<Transform>();
            clickPos.parent = GameManager.Instance.noteParent;
        }
        
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        ButtonUpdate();
        AnimationUpdate();
    }

    private void ButtonUpdate()
    {
        #region EditMode
        
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
        
        #endregion

        #region PlayMode

        else if (!GameManager.Instance.editMode)
        {
            if (Input.GetKeyDown(keyCode))
            {
                whiteBackGround.SetActive(true);
                
                Collider2D[] notes = Physics2D.OverlapBoxAll(transform.position, judgmentRange, 0, noteLayer);

                foreach (var note in notes)
                {
                    if (note.TryGetComponent(out Note temp))
                    {
                        temp.HitNote(transform.position);
                    }

                    if (note.TryGetComponent(out LongNote longNote))
                    {
                        _longNote = longNote;
                        longNote.StartPress(transform.position, this);
                    }
                }
            }
            
            if (Input.GetKeyUp(keyCode))
            {
                whiteBackGround.SetActive(false);
                
                Collider2D[] notes = Physics2D.OverlapBoxAll(transform.position, judgmentRange, 0, noteLayer);

                foreach (var note in notes)
                {
                    if (note.TryGetComponent(out LongNoteEnd longNoteEnd))
                    {
                        if (longNoteEnd.longNote == _longNote)
                        {
                            _longNote = null;
                            longNoteEnd.End(transform.position);
                        }
                    }
                }

                if (_longNote != null)
                {
                    _longNote.StopPress(true);
                    _longNote = null;
                }
            }
        }

        #endregion
    }
    
    private void AnimationUpdate()
    {
        anim.SetBool("isPress", press);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        
        Gizmos.DrawWireCube(transform.position, judgmentRange);
    }

    private void PlusCombo()
    {
        GameManager.Instance.PlusCombo();
    }
}