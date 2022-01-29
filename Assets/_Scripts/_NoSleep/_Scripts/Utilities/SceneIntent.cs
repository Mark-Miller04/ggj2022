using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace NoSleep.Utilities
{
	/// <summary>
	/// An intent which loads a scene.
	/// </summary>
	[Serializable]
	[CreateAssetMenu(menuName = "Intents/Scene Intent", fileName = "New Scene Intent")]
	public class SceneIntent : Intent
	{
		public string SceneName;

		public override void Do()
		{
			SceneManager.LoadScene(SceneName);
		}
	}
}
