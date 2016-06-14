using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LightswitchController: MonoBehaviour
{
	
	private GameObject toWin;

	public SpriteRenderer bg;
	public Sprite oldbg;
	public Sprite newbg;

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
			GetComponent<Animator>().Play("LightOn");
			//col.gameObject.GetComponent<Animator>().Play("Win");
			//col.gameObject.PlayAnimation ("Death");
			//animation.Play(animDie.name);
			// ... destroy the player.
			this.toWin = col.gameObject;
			StartCoroutine("Win");

			bg.sprite = newbg;

			// ... reload the level.
			StartCoroutine("LoadNextLevel");
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
	IEnumerator Win()
	{
		toWin.GetComponent<PlatformerMotor2D>().frozen = true;
		//toWin.GetComponent<PlatformerMotor2D> ().Win ();
		// ... pause briefly
		yield return new WaitForSeconds(2);
		//Destroy (toRemove);
		// ... and then reload the level.
		//Application.LoadLevel(Application.loadedLevel);
	}
	IEnumerator LoadNextLevel()
	{			
		// ... pause briefly
		yield return new WaitForSeconds(2);

		// ... and then load the next level.
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
		//Application.LoadLevel(Application.loadedLevel+1);
	}
}
