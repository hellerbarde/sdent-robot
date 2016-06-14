using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class DoublejumpPowerupController: MonoBehaviour
{

	void OnTriggerEnter2D(Collider2D col)
	{
		Debug.Log ("PowerupController ontriggerenter2d");
		// If the player hits the trigger...
		if(col.gameObject.tag == "Player")
		{
			Debug.Log ("PowerupController ontriggerenter2d in if");
			// ... instantiate the splash where the player falls in.
			//Instantiate(splash, col.transform.position, transform.rotation);
			//			((SpriteRenderer) GetComponentInChildren<SpriteRenderer>).animation.Play;
			//GetComponent<Animator>().Play("LightOn");
			//col.gameObject.GetComponent<Animator>().Play("Win");
			//col.gameObject.PlayAnimation ("Death");
			//animation.Play(animDie.name);


			// empower the player.
			col.gameObject.GetComponent<PlatformerMotor2D>().numOfAirJumps = 1;
			StartCoroutine("PickUp");

			// Destroy the Pickup
			StartCoroutine("AnimateDestroy");
		}

	}

	IEnumerator PickUp()
	{
		// ... pause briefly
		yield return new WaitForSeconds(2);
		Destroy (gameObject);
	}

	IEnumerator AnimateDestroy()
	{			
		// ... pause briefly
		yield return new WaitForSeconds(2);

	}
}
