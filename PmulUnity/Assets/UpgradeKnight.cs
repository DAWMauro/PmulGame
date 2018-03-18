using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeKnight : MonoBehaviour
{
    [SerializeField]
    private GameObject testAllyPrefab;

    private Stats stats;
    public Text statsText;

    void Start()
    {
        stats = testAllyPrefab.GetComponent<Stats>();
    }

    public void Upgrade()
    {
        stats.Damage += 10;
        stats.Health += 10;

        statsText.text = "Daño: " + testAllyPrefab.GetComponent<Stats>().Damage.ToString() +
            "\nVida: " + testAllyPrefab.GetComponent<Stats>().Health.ToString() +
            "\nVelocidad: " + testAllyPrefab.GetComponent<Stats>().Speed.ToString() +
            "\nCoste: " + testAllyPrefab.GetComponent<Stats>().Cost.ToString();
    }
}
