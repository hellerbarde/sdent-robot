using UnityEngine;
using System.Collections;

public class Remover : MonoBehaviour
{
	AudioController audioController;

	private GameObject toRemove;


	void OnTriggerEnter2D(Collider2D col)
	{
		Debug.Log ("ontriggerenter2d");
		// If the player hits the trigger...
		if(col.gameObject.tag == "Player")
		{
			// .. stop the camera tracking the player
			//GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraFollow>().enabled = false;

			// .. stop the Health Bar following the player
//			if(GameObject.FindGameObjectWithTag("HealthBar").activeSelf)
//			{
//				GameObject.FindGameObjectWithTag("HealthBar").SetActive(false);
//			}

			// ... instantiate the splash where the player falls in.
			//Instantiate(splash, col.transform.position, transform.rotation);
//			((SpriteRenderer) GetComponentInChildren<SpriteRenderer>).animation.Play;
			col.gameObject.GetComponent<Animator>().Play("Death");
			//col.gameObject.PlayAnimation ("Death");
			//animation.Play(animDie.name);
			// ... destroy the player.
			this.toRemove = col.gameObject;

			AudioController _audioController = col.gameObject.GetComponent<AudioController> ();
			_audioController.FireAudioDeath();

			StartCoroutine("Die");


			// ... reload the level.
			StartCoroutine("ReloadGame");
		}
//		else
//		{
//			// ... instantiate the splash where the enemy falls in.
//			Instantiate(splash, col.transform.position, transform.rotation);
//
//			// Destroy the enemy.
//			Destroy (col.gameObject);	
//		}
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
		Application.LoadLevel(Application.loadedLevel);
	}
}
