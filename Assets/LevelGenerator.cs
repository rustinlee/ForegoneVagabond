using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelGenerator : MonoBehaviour {
	public Transform spawnTile; // preset tile to spawn in 0,0 as the player's spawn point
	public List<Transform> tileList; // list of tiles to pick from during gen
	public int levelWidth; // number of tiles the level is wide
	public int levelHeight; // number of tiles the level is high

	void Start () {
		Transform currentTile;
		int randomIndex;
		for(int x = 0; x < levelWidth; x++) {
			for(int y = 0; y < levelHeight; y++) {
				if(x == 0 && y == 0) {
					currentTile = Instantiate(spawnTile) as Transform;
				} else {
					randomIndex = Random.Range(0, tileList.Count);
					currentTile = Instantiate(tileList[randomIndex]) as Transform;
				}

				currentTile.localPosition = new Vector3(currentTile.localPosition.x * (x*2 + 1),
				                                        currentTile.localPosition.y * (y*2 + 1),
				                                        currentTile.localPosition.z);
				currentTile.parent = gameObject.transform;
			}
		}
	}

	void Update () {
	
	}
}
