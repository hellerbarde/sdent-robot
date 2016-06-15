using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Title screen script
/// </summary>
public class VictoryScreen: MonoBehaviour
{
//	void OnGUI()
//	{
//		const int buttonWidth = 84;
//		const int buttonHeight = 60;
//
//		// Determine the button's place on screen
//		// Center in X, 2/3 of the height in Y
//		Rect buttonRect = new Rect(
//			Screen.width / 2 - (buttonWidth / 2),
//			(2 * Screen.height / 3) - (buttonHeight / 2),
//			buttonWidth,
//			buttonHeight
//		);
//
//		// Draw a button to start the game
//		if(GUI.Button(buttonRect,"Press Start to Begin saving the world"))
//		{
//			// On Click, load the first level.
//			// "Stage1" is the name of the first scene we created.
//			SceneManager.LoadScene("Level");
//		}
//	}

	void Update()
	{
		if (Input.GetButtonDown ("Jump")
	    || Input.GetButtonDown ("Fire1")
	    || Input.GetButtonDown ("Cancel")) {

			SceneManager.LoadScene("Menu");
		}
	}
}
