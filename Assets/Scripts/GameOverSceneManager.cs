using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameOverSceneManager : MonoBehaviour {

	public GameObject winLoseGameObject;

	// Use this for initialization
	void Start () {
		Text text = winLoseGameObject.GetComponent<Text>();
		if (PlayerPrefs.GetString("winState") == "win") {
			text.text = "You Won!";
		}
		else if (PlayerPrefs.GetString("winState") == "lose") {
			text.text = "Game Over!";
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void restartGame () {
		Application.LoadLevel("Game");
	}

	public void endGame () {
		Application.Quit();
	}
}
