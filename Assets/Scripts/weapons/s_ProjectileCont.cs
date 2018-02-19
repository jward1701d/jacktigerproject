using UnityEngine;
using System.Collections;

public class s_ProjectileCont : MonoBehaviour 
	
	


{
	
	public float projectileSpeed;
	public float projectileDamage;
	
	
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		float amtToMove = projectileSpeed * Time.deltaTime;
		transform.Translate (Vector3.up * amtToMove);
		
		if(transform.position.y > 6.4)
		{
			Destroy (gameObject);	
		}
	}
	void OnTriggerEnter(Collider otherObject)
	{
		if (otherObject.tag == "crashable" )
			{
			Destroy (this.gameObject);
			Debug.Log ("Asteroid hit");
			
			}
		if (otherObject.tag == "enemy" )
			{
			Destroy (gameObject);
			
			}	
	}
	
}
