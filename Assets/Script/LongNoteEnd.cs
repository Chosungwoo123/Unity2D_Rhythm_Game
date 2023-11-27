using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LongNoteEnd : MonoBehaviour
{
    public LongNote longNote;

    public void Init(LongNote _longNote)
    {
        longNote = _longNote;
    }
    
    public void End(Vector3  buttonPos)
    {
        if(Vector3.Distance(transform.position, buttonPos) <= 0.5f)
        {
            GameManager.Instance.PlusCombo();
        }
        else if (Vector3.Distance(transform.position, buttonPos) > 0.5f)
        {
            GameManager.Instance.ResetCombo();
        }
        
        longNote.StopPress(false);
        Destroy(gameObject);
    }
}