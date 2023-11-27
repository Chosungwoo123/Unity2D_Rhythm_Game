using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public Transform noteParent;

    public Text comboText;

    public bool editMode;

    public int combo = 0;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        comboText.text = "COMBO : " + combo;
    }

    public void PlusCombo()
    {
        combo++;
        
        comboText.text = "COMBO : " + combo;
    }
    
    public void ResetCombo()
    {
        combo = 0;
        
        comboText.text = "COMBO : " + combo;
    }
}
