using UnityEngine;
using System.Collections;



public class AudioController : MonoBehaviour {


	public AudioClip _death;
	public AudioClip _jump;
	public AudioClip _land;
	public AudioClip _fall;
	public AudioClip _cling;
//	public AudioClip _oncorner;
//	public AudioClip _slip;
	public AudioClip _dash;
	public AudioClip _walk;

	AudioSource _audio;

	// Use this for initialization
	void Start () {
		_audio = GetComponent<AudioSource>();	
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void FireAudioJump() {
		_audio.PlayOneShot (_jump);
	}

	public void FireAudioDash() {
		_audio.PlayOneShot (_dash);
	}

	public void FireAudioDeath() {
		_audio.PlayOneShot (_death, 0.7f);
	}

	public void FireAudioLanding() {
		_audio.PlayOneShot (_land);
	}

}
