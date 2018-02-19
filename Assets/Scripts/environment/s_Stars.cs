using UnityEngine;
using System.Collections;

public class s_Stars : MonoBehaviour 

{
	public float speed;

	// Use this for initialization
	
	// Update is called once per frame
	void Update () 
	{
		if (s_level.enemiesSpawning == true)
		{
		float amtToMove = speed * Time.deltaTime;
		transform.Translate (Vector3.down * amtToMove, Space.World);
		if (transform.position.y < -10.73)
		{
			transform.position = new Vector3 (transform.position.x, 14.4f, transform.position.z);
			
		}
		}
		
	
	}
}
