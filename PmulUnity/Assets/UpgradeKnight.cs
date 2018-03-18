using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeKnight : MonoBehaviour
{
    [SerializeField]
    private GameObject testAllyPrefab;

    private Stats stats;

    void Start()
    {
        stats = testAllyPrefab.GetComponent<Stats>();
    }

    public void Upgrade()
    {
        stats.Damage += 10;
        stats.Health += 10;
    }


}
