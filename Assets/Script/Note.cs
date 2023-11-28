using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    public GameObject hitEffect;

    private void Start()
    {
        transform.localScale = new Vector3(1, 1 / GameManager.Instance.songSpeed, 1);
    }

    public void HitNote(Vector3 buttonPos)
    {
        if (Vector3.Distance(transform.position, buttonPos) <= 1)
        {
            GameManager.Instance.PlusCombo();
            Instantiate(hitEffect, transform.position, Quaternion.identity);
        }
        else if (Vector3.Distance(transform.position, buttonPos) > 1)
        {
            GameManager.Instance.ResetCombo();
        }
        
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("End Line") && !GameManager.Instance.editMode)
        {
            GameManager.Instance.ResetCombo();
        
            Destroy(gameObject);
        }
    }
}
