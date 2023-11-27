using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    public void HitNote(Vector3 buttonPos)
    {
        if (Vector3.Distance(transform.position, buttonPos) <= 2)
        {
            GameManager.Instance.PlusCombo();
        }
        else
        {
            GameManager.Instance.ResetCombo();
        }
        
        Destroy(gameObject);
    }
}
