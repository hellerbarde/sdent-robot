using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class DoublejumpPowerupController: MonoBehaviour
{

	void OnTriggerEnter2D(Collider2D col)
	{
		// If the player hits the trigger...
		if(col.gameObject.tag == "Player")
		{
			// empower the player.
			col.gameObject.GetComponent<PlatformerMotor2D>().numOfAirJumps = 1;
			col.gameObject.GetComponent<ParticleSystem> ().Play ();
			gameObject.GetComponent<SpriteRenderer> ().sprite = null;

			StartCoroutine("PickUp");
		}

	}

	IEnumerator PickUp()
	{
		// ... pause briefly
		yield return new WaitForSeconds(0.6f);
		Destroy (gameObject);
	}
}
