using System;
using UnityEngine;

namespace NoSleep.Utilities
{
	/// <summary>
	/// A serializable object used for decoupling simple, multi-use behaviours from the code that uses them.
	/// </summary>
	[Serializable]
	public abstract class Intent : ScriptableObject
	{
		/// <summary>
		/// Performs the function of the intent.
		/// </summary>
		public abstract void Do();
	}
}
