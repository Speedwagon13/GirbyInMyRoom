using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour {

	public float transitionOut = 0.5f;
	public float transitionIn = 0.5f;
	Image img;
	// Use this for initialization
	void Start () {
		img = GetComponent<Image>();
		StartCoroutine(TransitionIn());
	}

	
	public IEnumerator LoadAsyncScene(int sceneIndex) {
		

		float alpha = 0.0f;
		float timeElapsed = 0.0f;

		while (timeElapsed < transitionOut) {
			timeElapsed += Time.deltaTime;
			alpha = Mathf.Clamp01(timeElapsed/transitionOut);
			Debug.Log(timeElapsed);
			Color clr = img.color;
			clr.a = alpha;
			img.color = clr;
			yield return null;
		}
		AsyncOperation ao = SceneManager.LoadSceneAsync(sceneIndex);
		while (!ao.isDone) {
			float progress = Mathf.Clamp01(ao.progress/0.9f);
			Debug.Log(progress);
			yield return null;
		}
	}

	IEnumerator TransitionIn() {
		float alpha = 1.0f;
		float timeRemaining = transitionIn;

		while (timeRemaining > 0 ) {
			timeRemaining -= Time.deltaTime;
			alpha = Mathf.Clamp01(timeRemaining/transitionIn);
			Color clr = img.color;
			clr.a = alpha;
			img.color = clr;
			yield return null;
		}
	}

	public void LoadScene(int i) {
		
		StartCoroutine(LoadAsyncScene(i));
	}

	public void Exit() {
		#if UNITY_EDITOR
         // Application.Quit() does not work in the editor so
         // UnityEditor.EditorApplication.isPlaying need to be set to false to end the game
         UnityEditor.EditorApplication.isPlaying = false;
     	#else
         Application.Quit();
     	#endif
	}
}
