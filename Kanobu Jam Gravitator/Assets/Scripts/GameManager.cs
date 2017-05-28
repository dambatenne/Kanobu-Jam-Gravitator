using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public static GameManager instance = null;

	private int score = 0;

	public int Score {

		get { return score;}

	}

	private bool isTutorialMode = false;

	public bool IsTutorialMode {

		get { return isTutorialMode; }
		set { isTutorialMode = value; }

	}

	private int sceneIndex;

	public int SceneIndex {

		get { return sceneIndex; }

	}

	private int prevSceneIndex;


	//Awake is always called before any Start functions
    void Awake () {
        //Check if instance already exists
        if (instance == null)
            
            //if not, set instance to this
            instance = this;
        
        //If instance already exists and it's not this:
        else if (instance != this)
            
            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
            Destroy(gameObject);    
        
        //Sets this to not be destroyed when reloading scene
        DontDestroyOnLoad(gameObject);

		SceneManager.sceneLoaded += SetCurrentSceneIndex;
    }

	private void SetCurrentSceneIndex (Scene scene, LoadSceneMode mode) {

		prevSceneIndex = sceneIndex;
		sceneIndex = SceneManager.GetActiveScene ().buildIndex;
		Debug.Log ("Prev: " + prevSceneIndex);
		Debug.Log ("Current: " + sceneIndex);

    }

	public void LoadLevel(string name) {

		SceneManager.LoadScene(name);

	}

	public void FinishLevel() {

		if (!isTutorialMode) {
			Debug.Log ("Next levelLoad");
			SceneManager.LoadScene ("Next level menu");
		} else {
			SceneManager.LoadScene ("Tutorial menu");
		}

	}

	public void GameOver () {

		StartCoroutine (GameOverWitDelay(1f));

	}

	public IEnumerator GameOverWitDelay (float dealy) {

		Debug.Log ("GameOver Coroutine entered 1");

		yield return new WaitForSeconds(dealy);

		Debug.Log ("GameOver Coroutine entered 2");

		if (!isTutorialMode) {
			SceneManager.LoadScene ("Game over menu");
		} else {
			SceneManager.LoadScene ("Tutorial menu");
		}

    }

	public void LoadNextScene () {

		Debug.Log("Next scene: " + (prevSceneIndex + 1).ToString());
		SceneManager.LoadScene (prevSceneIndex + 1);

	}

	public void ReloadLastScene () {

		SceneManager.LoadScene (prevSceneIndex);

	}

	public void AddScore (int addition) {

		score += addition;
		DisplayScore ();
		Debug.Log("Score: " + score);

	}

	public void ResetScore () {

		score = 0;

	}

	public void DisplayScore () {

		GameObject ScoreDisplay = GameObject.FindGameObjectWithTag ("ScoreDisplay");
		ScoreDisplay.GetComponent <Text> ().text = "Score: " + score; 

	}
}
