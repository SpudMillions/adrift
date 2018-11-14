using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenePersist : MonoBehaviour
{
	private int _sceneIndexofTheLastScene = 0;
	private int _sceneIndexAtStart;
    

	private void Awake()
	{
		var actualSceneIndex = SceneManager.GetActiveScene().buildIndex;

		if (_sceneIndexofTheLastScene == actualSceneIndex)
		{
			var numScenePersist = FindObjectsOfType<ScenePersist>().Length;
			if (numScenePersist > 1)
			{
				Destroy(gameObject);
				Debug.Log("ScenePersist has been destroyed due to Singleton");
			}
			else
			{
				DontDestroyOnLoad(gameObject);
			}
		}
		else
		{
			StartCoroutine(Singleton());
		}
        
	}

	IEnumerator Singleton()
	{
		yield return new WaitForSecondsRealtime(Time.deltaTime);
        
		var numScenePersist = FindObjectsOfType<ScenePersist>().Length;
		if (numScenePersist > 1)
		{
			Destroy(gameObject);
		}
		else
		{
			DontDestroyOnLoad(gameObject);
		}
	}

	private void Start() {
		_sceneIndexAtStart = SceneManager.GetActiveScene().buildIndex;
		_sceneIndexofTheLastScene = SceneManager.GetActiveScene().buildIndex;
	}

	void Update() {
		CheckIfStillInSameScene();
	}

	private void CheckIfStillInSameScene(){
		var actualSceneIndex = SceneManager.GetActiveScene().buildIndex;
		if (actualSceneIndex != _sceneIndexAtStart)
		{
			Destroy(gameObject);
		}
		else
		{
			DontDestroyOnLoad(gameObject);
		}
	}
}
