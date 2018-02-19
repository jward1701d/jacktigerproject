using UnityEngine;
using System.Collections;

public class s_Item : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (0.0f, 5.0f, 0.0f);
		float amtToMove = 2 * Time.deltaTime;
		transform.Translate (Vector3.down * amtToMove);
		
		if(transform.position.y < -6.4)
		{
			Destroy (gameObject);	
		}
		
		
	
	}
	
	void OnTriggerEnter (Collider otherObject)
	{
		if (otherObject.tag == "Player")
		{
			Destroy (gameObject);
		}
	}
	
	
}
