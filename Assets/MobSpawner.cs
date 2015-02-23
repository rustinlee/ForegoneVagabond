using UnityEngine;
using System.Collections;

public class MobSpawner : MonoBehaviour {
	public int maxHP;
	public float spawnCooldown; // how long to wait between cooldowns
	public int maxConcurrentMobs; // max number of mobs to keep active at once
	public Transform mobPrefab; // the mob to spawn

	private float HP;
	private float timeSinceLastSpawn = 0f;
	private int concurrentMobs = 0; // number of mobs from this spawner active
	private Animator animator;

	public void SpawnMob() {
		Transform newMob = Instantiate(mobPrefab) as Transform;
		newMob.position = new Vector3(transform.position.x, transform.position.y, newMob.position.z);
		concurrentMobs++;
	}

	void Start() {
		animator = gameObject.GetComponent<Animator>();
		HP = maxHP;
	}

	void Update() {
		if (concurrentMobs < maxConcurrentMobs) {
			timeSinceLastSpawn += Time.deltaTime;
			if (timeSinceLastSpawn >= spawnCooldown) {
				animator.SetTrigger("spawn");
				timeSinceLastSpawn = 0f;
			}
		}
	}
}
