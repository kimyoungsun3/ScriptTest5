using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTest01 : MonoBehaviour {

	void Start () {
		Debug.Log (this);	
	}

	void Update () {
		if (Input.GetKeyDown (KeyCode.Alpha2)) {
			StartCoroutine (LoadScene02 ());
		} else if (Input.GetKeyDown (KeyCode.Alpha3)) {
			StartCoroutine (LoadScene03 ());
		} else if (Input.GetKeyDown (KeyCode.Alpha4)) {
			StartCoroutine (UnLoadScene2 ());
		} else if (Input.GetKeyDown (KeyCode.Alpha5)) {
			StartCoroutine (UnLoadScene3 ());
		}
		
	}

	IEnumerator LoadScene02(){
		if (SceneTest02.ins != null) {
			Debug.Log (" 이미 로딩됨...");
			yield break;
		}

		Debug.Log ("sc1:" + SceneManager.sceneCount);
		yield return SceneManager.LoadSceneAsync ("SceneTest02", LoadSceneMode.Additive);

		Debug.Log ("sc2:" + SceneManager.sceneCount);
		Scene _s = SceneManager.GetSceneAt (SceneManager.sceneCount - 1);

		SceneManager.SetActiveScene (_s);
	}


	IEnumerator LoadScene03(){
		if (SceneTest03.ins != null) {
			Debug.Log (" 이미 로딩됨...");
			yield break;
		}

		Debug.Log ("sc1:" + SceneManager.sceneCount);
		yield return SceneManager.LoadSceneAsync ("SceneTest03", LoadSceneMode.Additive);

		Debug.Log ("sc2:" + SceneManager.sceneCount);
		Scene _s = SceneManager.GetSceneAt (SceneManager.sceneCount - 1);

		SceneManager.SetActiveScene (_s);
	}

	IEnumerator UnLoadScene2(){
		Debug.Log (" SceneTest02.ins:" + SceneTest02.ins);
		if (SceneTest02.ins != null) {
			Debug.Log (" 씬unload2...");
			SceneManager.UnloadSceneAsync ("SceneTest02");
		}
		yield return null;
	}

	IEnumerator UnLoadScene3(){
		Debug.Log (" SceneTest03.ins:" + SceneTest03.ins);
		if (SceneTest03.ins != null) {
			Debug.Log (" 씬unload3...");
			SceneManager.UnloadSceneAsync ("SceneTest03");
		}
		yield return null;
	}
}
