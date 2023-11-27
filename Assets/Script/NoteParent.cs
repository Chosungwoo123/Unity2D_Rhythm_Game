using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteParent : MonoBehaviour
{
    public float songSpeed;

    private void Start()
    {
        transform.localScale = new Vector3(1, GameManager.Instance.songSpeed, 1);

        songSpeed *= GameManager.Instance.songSpeed;
    }

    private void Update()
    {
        MoveUpdate();
    }

    private void MoveUpdate()
    {
        Vector3 nextPos = Vector3.down * songSpeed * Time.deltaTime;

        transform.position += nextPos;
    }
}