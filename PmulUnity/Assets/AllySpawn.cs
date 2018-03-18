﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class AllySpawn : MonoBehaviour
{
    [SerializeField]
    private GameObject testAllyPrefab;
    [SerializeField]
    private GameObject spawnPoint;
    [SerializeField]
    private float coldDown;

    private float originalCD;
    private Interface goldSystem;
    private int cost;
    private Button button;

    public Text statsText;

    private void Start()
    {
        goldSystem = GameObject.Find("GameManager").GetComponent<Interface>();
        cost = testAllyPrefab.GetComponent<Stats>().Cost;
        originalCD = coldDown;

        statsText.text = "Daño: " + testAllyPrefab.GetComponent<Stats>().Damage.ToString() +
            "\nVida: " + testAllyPrefab.GetComponent<Stats>().Health.ToString() +
            "\nVelocidad: " + testAllyPrefab.GetComponent<Stats>().Speed.ToString() +
            "\nCoste: " + testAllyPrefab.GetComponent<Stats>().Cost.ToString();
    }
    public void Generate(Button bt)
    {
        button = bt;
        if (cost < goldSystem.Gold)
        {
            goldSystem.Gold -= cost;
            Instantiate(testAllyPrefab).transform.position = spawnPoint.transform.position;
            button.interactable = false;
        }
    }
    private void Update()
    {
        if (button != null)
        {
            if (!button.interactable)
            {
                coldDown -= Time.deltaTime;
                if (coldDown < 0)
                {
                    button.interactable = true;
                    coldDown = originalCD;
                }
            }
        }
    }
}
