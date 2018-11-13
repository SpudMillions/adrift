using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenePersist : MonoBehaviour
{
	private int startingSceneIndex;
	
	private void Awake()
	{
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

	// Use this for initialization
	void Start ()
	{
		startingSceneIndex = SceneManager.GetActiveScene().buildIndex;
	}
	
	// Update is called once per frame
	void Update ()
	{
		var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
		if (currentSceneIndex != startingSceneIndex)
		{
			Destroy(gameObject);
		}
	}
}
