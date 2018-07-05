using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NucleonSpawner : MonoBehaviour {
	public Nucleon[] nucleons = new Nucleon[0];
	public float timeBetwwenSpawns = 0.15f;
	public float spawnDistance = 15;
	public Text lvCount;
	bool bAllPass = false;


	void Start () {
		StartCoroutine (SpawnNucleon ());
	}


	IEnumerator SpawnNucleon(){
		WaitForSeconds _wait = new WaitForSeconds (timeBetwwenSpawns);
		Nucleon _scp, _prefab;
		int _count = 0;

		while (true) {
			if (!bAllPass) {
				_prefab = nucleons [Random.Range (0, nucleons.Length)];
				_scp = Instantiate (_prefab) as Nucleon;
				_scp.transform.SetParent (transform);
				_scp.transform.localPosition = Random.onUnitSphere * spawnDistance;
				lvCount.text = "" + ++_count;
			}
			yield return _wait;	
		}
	}

	void Update(){
		if (Input.GetMouseButtonDown (0)) {
			bAllPass = !bAllPass;
		}
	}
		
}
