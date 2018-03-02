using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemys : MonoBehaviour {
    [SerializeField]
    private GameObject testEnemyPrefab;

    void Start () {
        Instantiate(testEnemyPrefab).transform.position = transform.position;
	}
	

	void Update () {
		
	}
}
