using UnityEngine;
using System.Collections;

public class sc_Lose : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnGUI()
	{
		GUI.Label (new Rect(50, 50, 200, 30), "GAME OVER");
	}
	
}
