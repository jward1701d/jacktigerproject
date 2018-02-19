using UnityEngine;
using System.Collections;

public class s_level : MonoBehaviour {
	
	public GameObject playerObject;
	public GameObject spewObject;
	public static float gameTime;//public float gameTime;
	public static bool enemiesSpawning = true;
	public AudioClip gameBGM;
	
	
	// Use this for initialization
	void Start () 
	{
		Instantiate (playerObject);	
		StartCoroutine (gameTimer ());
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	IEnumerator gameTimer()
	{
		
		AudioSource.PlayClipAtPoint (gameBGM, Camera.main.transform.position, 0.1f);
		yield return new UnityEngine.WaitForSeconds(gameTime);
		enemiesSpawning = false; 
		yield return new UnityEngine.WaitForSeconds(5);
	
		
		Instantiate (spewObject);
			
		
	}
	
}
