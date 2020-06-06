using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Persistence : MonoBehaviour
{
	public static int GetInt(string key)
	{
		return PlayerPrefs.GetInt(key, 0);
	}

	public static void SetInt(string key, int value)
	{
		PlayerPrefs.SetInt(key, value);
	}
}
