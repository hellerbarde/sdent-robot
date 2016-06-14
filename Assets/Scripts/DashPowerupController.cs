using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class DashPowerupController: MonoBehaviour
{

	void OnTriggerEnter2D(Collider2D col)
	{
		// If the player hits the trigger...
		if(col.gameObject.tag == "Player")
		{
			// empower the player.
			col.gameObject.GetComponent<PlatformerMotor2D>().enableDashes = true;
			col.gameObject.GetComponent<ParticleSystem> ().Play ();
			gameObject.GetComponent<SpriteRenderer> ().sprite = null;
			StartCoroutine("PickUp");
		}

	}

	IEnumerator PickUp()
	{
		// ... pause briefly
		yield return new WaitForSeconds(0.5f);
		Destroy (gameObject);
	}
}
