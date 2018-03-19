using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interface : MonoBehaviour
{
    [SerializeField]
    private Text goldText;
    private int gold;

    [SerializeField]
    private Text waveText;
    private int wave;

    public int waveLenght;

    public int Gold
    {
        get
        {
            return gold;
        }

        set
        {

            gold = value;
            if (goldText != null)
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
            if (waveText != null)
                waveText.text = "Oleada: " + wave + "/"+ waveLenght;
        }
    }

    void Start()
    {
        Gold = 100;
    }

}
