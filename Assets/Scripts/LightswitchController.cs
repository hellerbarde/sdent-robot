using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LightswitchController: MonoBehaviour
{
	
	private GameObject toWin;
	public Scene NextLevel;
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

			// ... reload the level.
			StartCoroutine("LoadNextLevel");
		}

	}
	IEnumerator Win()
	{
		toWin.GetComponent<PlatformerMotor2D>().frozen = true;
		yield return new WaitForSeconds(2);
	}
	IEnumerator LoadNextLevel()
	{			
		// ... pause briefly
		yield return new WaitForSeconds(2);

		// ... and then load the next level.
		//SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
		SceneManager.LoadScene(NextLevel.path);
	}
}
