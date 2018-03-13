﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interface : MonoBehaviour {
    [SerializeField]
    private Text goldText;
    private int gold;

    [SerializeField]
    private Text waveText;
    private int wave;

    public int Gold
    {
        get
        {
            return gold;
        }

        set
        {
            gold = value;
            goldText.text = "Oro: " + gold;
        }
    }

    public int Wave
    {
        get
        {
            return wave;
        }

        set
        {
            wave = value;
            waveText.text = "Oleada: " + wave;
        }
    }

    void Start () {
        Gold = 100;
	}
	
}