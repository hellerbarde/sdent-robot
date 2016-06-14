using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Remover : MonoBehaviour
{
	AudioController audioController;

	private GameObject toRemove;


	void OnTriggerEnter2D(Collider2D col)
	{
		// If the player hits the trigger...
		if(col.gameObject.tag == "Player")
		{
			
			col.gameObject.GetComponent<Animator>().Play("Death");

			// ... mark the player to be destroyed.
			this.toRemove = col.gameObject;

			AudioController _audioController = col.gameObject.GetComponent<AudioController> ();
			_audioController.FireAudioDeath();

			StartCoroutine("Die");

			// ... reload the level.
			StartCoroutine("ReloadGame");
		}
	}
	IEnumerator Die()
	{
		toRemove.GetComponent<PlatformerMotor2D>().frozen = true;
		toRemove.GetComponent<PlatformerMotor2D> ().Die ();
		//toRemove.GetComponent<Animator>().Play("Death");
		// ... pause briefly
		yield return new WaitForSeconds(2);
		Destroy (toRemove);
		// ... and then reload the level.
		//Application.LoadLevel(Application.loadedLevel);
	}
	IEnumerator ReloadGame()
	{			
		// ... pause briefly
		yield return new WaitForSeconds(2);
		// ... and then reload the level.
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		//Application.LoadLevel(Application.loadedLevel);
	}
}
