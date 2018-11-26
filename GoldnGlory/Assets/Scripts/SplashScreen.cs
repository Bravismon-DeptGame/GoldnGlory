using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashScreen : MonoBehaviour
{
	
	void Start ()
	{
		StartCoroutine(start());
	}

	IEnumerator start()
	{
		yield return new WaitForSeconds(5);
		SceneManager.LoadScene("Game");
	}
}
