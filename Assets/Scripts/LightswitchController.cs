using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using PC2D;

public class LightswitchController: MonoBehaviour
{
	
	private GameObject toWin;
	public string NextLevel;
	public SpriteRenderer Background;
	public Sprite OldBackground;
	public Sprite NewBackground;

	void OnTriggerEnter2D(Collider2D col)
	{
		// If the player hits the trigger...
		if(col.gameObject.tag == "Player")
		{

			GetComponent<Animator>().Play("LightOn");

			this.toWin = col.gameObject;
			StartCoroutine("Win");

			Background.sprite = NewBackground;

			col.gameObject.GetComponent<AudioController>().FireAudioVictory();

			// ... Go to next level
			StartCoroutine("LoadNextLevel");
		}

	}
	IEnumerator Win()
	{
		//toWin.GetComponent<PlatformerMotor2D>().frozen = true;
		toWin.GetComponent<PlatformerMotor2D>().enabled = false;
		toWin.GetComponent<PlatformerAnimation2D>().enabled = false;

		toWin.GetComponent<Animator>().Play("Idle");
		yield return new WaitForSeconds(2);
	}
	IEnumerator LoadNextLevel()
	{			
		// ... pause briefly
		yield return new WaitForSeconds(2);

		// ... and then load the next level.
		//SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
		SceneManager.LoadScene(NextLevel);
	}
}
