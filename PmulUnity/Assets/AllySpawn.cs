using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllySpawn : MonoBehaviour {
    [SerializeField]
    private GameObject testAllyPrefab;
    [SerializeField]
    private GameObject spawnPoint;
	
	public void Generate()
    {
        Instantiate(testAllyPrefab).transform.position = spawnPoint.transform.position;
    }
}
