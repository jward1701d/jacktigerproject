using UnityEngine;
using System.Collections;

public class s_AnimePlayer : MonoBehaviour {

	public Texture2D[] scenes;
	public float timerDelay;
	public string loadNextLevel;
	
	
	
	// Update is called once per frame
	void Start () {
		StartCoroutine(Play ());
		
	}
	
	void Update()
	{
		if(Input.GetKeyUp(KeyCode.Escape))
			{
				Application.LoadLevel(loadNextLevel);
			}
	}
	IEnumerator Play()
	{
		//timeMultiplier = timerDelay * Time.smoothDeltaTime;
		//if(audio.name != "null")
			//audio.Play();
		for(int i = 0; i < scenes.Length; i++)
		{
			GetComponent<GUITexture>().texture = scenes[i];
			yield return new WaitForSeconds (timerDelay);//(timerDelay);
		}
		Application.LoadLevel(loadNextLevel);
	}
}
