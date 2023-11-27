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
        if(Vector3.Distance(transform.position, buttonPos) <= 1f)
        {
            GameManager.Instance.PlusCombo();
        }
        else if (Vector3.Distance(transform.position, buttonPos) > 1f)
        {
            GameManager.Instance.ResetCombo();
        }
        
        longNote.StopPress(false);
        Destroy(gameObject);
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("End Line"))
        {
            longNote.StopPress(true);
            
            Destroy(longNote);
        }
    }
}