using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManagerScript : MonoBehaviour {

/*	public void ObjectiveMenu()
	{
		SceneManager.LoadScene ("objective_menu");
	}

	public void HowToPlayMenu()
	{
		SceneManager.LoadScene ("howtoplay_menu");
	}

	public void aboutMenu()
	{
		SceneManager.LoadScene ("about_menu");
	}

	public void backtoHelp()
	{
		SceneManager.LoadScene ("help_menu");
	}
*/
	public void ChangeToScene(string sceneToChangeTo)
	{
		Application.LoadLevel(sceneToChangeTo);
	}

}
