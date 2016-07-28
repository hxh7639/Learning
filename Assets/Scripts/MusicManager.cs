using UnityEngine;
using System.Collections;


public class MusicManager : MonoBehaviour {

	public AudioClip[] levelMusicChangeArray;
	private AudioSource audioSource;


	void Awake () {
		DontDestroyOnLoad(gameObject);
		Debug.Log ("Don't destory on load: " + name);
		
	}

	void Start () {
		audioSource = GetComponent<AudioSource>();
	}
		
	void OnLevelWasLoaded(int level) {
		AudioClip thisLevelMusic = levelMusicChangeArray[level];
		Debug.Log ("Playing Clip: " + thisLevelMusic);
		float volume = PlayerPrefsManager.GetMasterVolume();
		ChangeVolume(volume);
		if (thisLevelMusic){// if there's some music attached
			audioSource.clip = thisLevelMusic;
			audioSource.loop = true;
			audioSource.Play();
		}
	}
	
	public void ChangeVolume (float volume){
		audioSource.volume = volume;
	}
}
