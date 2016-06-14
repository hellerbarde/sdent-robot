using UnityEngine;
using System.Collections;



public class AudioController : MonoBehaviour {


	public AudioClip _death;
	public AudioClip _jump;
	public AudioClip _land;
	public AudioClip _dash;
	public AudioClip _walk;
	public AudioClip _powerUp;
	public AudioClip _victory;

	AudioSource _audio;

	// Use this for initialization
	void Start () {
		_audio = GetComponent<AudioSource>();	
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void MuteMusic() {
		AudioSource music = transform.Find ("music").GetComponent<AudioSource>();
		music.mute = true;
	}

	public void FireAudioJump() {
		_audio.PlayOneShot (_jump);
	}

	public void FireAudioDash() {
		_audio.PlayOneShot (_dash);
	}

	public void FireAudioDeath() {
		MuteMusic ();
		_audio.PlayOneShot (_death, 0.5f);
	}

	public void FireAudioLanding() {
		_audio.PlayOneShot (_land);
	}

	public void FireAudioVictory() {
		_audio.PlayOneShot (_victory);
	}

	public void FireAudioPowerUp() {
		_audio.PlayOneShot (_victory);
	}

	public void FireAudioWalk() {
		if (!_audio.isPlaying) {
			_audio.PlayOneShot (_walk, 0.5f);
		}

	}




		
}
