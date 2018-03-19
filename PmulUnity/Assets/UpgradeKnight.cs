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
    private Interface goldSystem;
    public StatsToUpgrade upgradeStat;
    public int costeMejora;

    [SerializeField]
    private float mejora;

    public Text textUpradeStat;


    void Start()
    {
        stats = testAllyPrefab.GetComponent<Stats>();
        goldSystem = GameObject.Find("GameManager").GetComponent<Interface>();
        textUpradeStat.text = upgradeStat.ToString() + "+" + mejora + "\n Coste: " + costeMejora;
    }

    public void Upgrade()
    {
        switch (upgradeStat.ToString())
        {
            case "Daño":
                if (costeMejora <= goldSystem.Gold)
                {
                    goldSystem.Gold -= costeMejora;
                    stats.Damage += (int)mejora;
                }
                break;
            case "Vida":
                if (costeMejora <= goldSystem.Gold)
                {
                    goldSystem.Gold -= costeMejora;
                    stats.Health += (int)mejora;

                }
                break;
            case "Velocidad":
                if (costeMejora <= goldSystem.Gold)
                {
                    goldSystem.Gold -= costeMejora;
                    stats.Speed += mejora;
                }
                break;
        }

        statsText.text = "Daño: " + stats.Damage.ToString() +
            "\nVida: " + stats.Health.ToString() +
            "\nVelocidad: " + stats.Speed.ToString() +
            "\nCoste: " + stats.Cost.ToString();
    }

    public enum StatsToUpgrade
    {
        Daño, Vida, Velocidad
    }
}
