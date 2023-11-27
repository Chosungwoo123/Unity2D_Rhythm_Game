using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private static GameManager instance = null;

    public static GameManager Instance
    {
        get
        {
            if (null == instance)
            {
                return null;
            }

            return instance;
        }
    }

    public Transform noteParent;

    public Text comboText;

    public bool editMode;

    public int combo = 0;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
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
