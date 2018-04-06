using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemySpawner : MonoBehaviour {

	public GameObject[] enemySpawnList;
	public float spawnInterval;
	int enemiesPerWave;
	int waveCounter;
	float timer;

	// Use this for initialization
	void Start () {
		if(spawnInterval <= 0.0f)
			spawnInterval = 3.0f;
		if (enemiesPerWave <= 0)
			enemiesPerWave = 2;
		resetWaveCounter ();
	}

	void EnemySpawnerUpdate(){
		if (waveCounter > 0 && !isPlayer.instance.isWalking) {
			Debug.Log("Spawn Something");
			int randIndex = Random.Range (0, enemySpawnList.Length);
			Vector3 randomPos = new Vector3 (
				                    transform.position.x + Random.Range (0, 4.0f), 
				                    0.0f, 
				                    transform.position.z + Random.Range (-2.0f, 2.0f)
			                    );
			if (enemySpawnList.Length > 0 && timer > spawnInterval && !GAMEMgr.instance.isEnding) {

				GameObject newEnemy;
				do {
					newEnemy = Instantiate (enemySpawnList [randIndex], randomPos, transform.rotation);
					NavMeshAgent navAgent = newEnemy.GetComponent<NavMeshAgent> ();
					if (!navAgent.isOnNavMesh) {
						Destroy (newEnemy.gameObject);
					} else {
						waveCounter--;
					}
				} while(newEnemy == null);
				timer = 0.0f;
			}
			timer += Time.deltaTime;
		} else if (isPlayer.instance.isWalking){
			resetWaveCounter ();
		}
	}

	public void resetWaveCounter(){
		waveCounter = enemiesPerWave;
	}

	public void setEnemiesPerWave(int epw){
		enemiesPerWave = epw;
	}
	
	// Update is called once per frame
	void Update () {
		EnemySpawnerUpdate ();
	}
}
