using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SoundId
{
	Land,
	Line,
	Move,
	Rotate
}

[System.Serializable]
public struct Sfx
{
	public SoundId id;
	public AudioClip clip;
}

public class AudioManager : MonoBehaviour
{
	[SerializeField]
	private AudioClip landSound;
	[SerializeField]
	private Sfx[] soundDefinitions;

	private AudioSource audioSource;

	private Dictionary<SoundId, AudioClip> sounds = new Dictionary<SoundId, AudioClip>();

	private static AudioManager instance;

	private void Awake()
	{
		if (instance == null)
		{
			instance = this;
			audioSource = GetComponent<AudioSource>();
			PrepareSounds();
		}
		else
		{
			Debug.LogWarning("There is already one AudioManager");
			Destroy(this);
		}
	}

	private void PrepareSounds()
	{
		foreach (var def in soundDefinitions)
		{
			sounds.Add(def.id, def.clip);
		}
	}

	public static void Play(SoundId soundId)
	{
		if (instance.sounds.ContainsKey(soundId))
			instance.audioSource.PlayOneShot(instance.sounds[soundId]);
	}

}
