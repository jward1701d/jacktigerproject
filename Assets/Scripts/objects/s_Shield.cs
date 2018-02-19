using UnityEngine;
using System.Collections;

public class s_Shield : MonoBehaviour {

	// Use this for initialization
	void Start () {
		gameObject.GetComponent<Renderer>().enabled=false;
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3 (GameObject.Find ("p_Player(Clone)").transform.position.x, GameObject.Find ("p_Player(Clone)").transform.position.y, 0.0f);
		if (s_Player.myHealth > 10)
		{
			gameObject.GetComponent<Renderer>().enabled = true;
		}
		if (s_Player.myHealth <= 10)
		{
			gameObject.GetComponent<Renderer>().enabled= false;
		}
	
	}
}
