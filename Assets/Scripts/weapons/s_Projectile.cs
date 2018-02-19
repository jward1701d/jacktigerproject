using UnityEngine;
using System.Collections;
using System;

public class s_Projectile : MonoBehaviour 
	
	


{
	
	public float bulletSpeed;
	
	
	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		float amtToMove = bulletSpeed * Time.deltaTime;
		transform.Translate (Vector3.up * amtToMove);
		
		if(transform.position.y > 6.4)
			{
				Destroy (gameObject);	
			}
		if(System.Math.Abs(transform.position.x) >= 8.0)
		{
			Destroy (gameObject);
		}
		
	}
		
		
		
	
	void OnTriggerEnter(Collider otherObject)
	{
		if (otherObject.tag == "crashable" )
			{
			Destroy (gameObject);
			
			}
		if (otherObject.tag == "enemy" )
			{
			Destroy (gameObject);
			
			}	
	}
	
}
