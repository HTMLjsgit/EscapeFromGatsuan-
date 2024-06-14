using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControllerSingle : MonoBehaviour
{
	public static GameControllerSingle Instance
	{
		get; private set;
	}

	void Awake()
	{
		if (Instance != null)
		{
			Destroy(gameObject);
			return;
		}
		Instance = this;
		DontDestroyOnLoad(gameObject);
	}

}
