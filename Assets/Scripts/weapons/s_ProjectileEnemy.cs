using UnityEngine;
using System.Collections;
using System;

public class s_ProjectileEnemy : MonoBehaviour 
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
		transform.Translate (Vector3.down * amtToMove);
		float pX = transform.position.x;
		float pY = transform.position.y;
		transform.position = new Vector3(pX, pY, 0.0f);
		
		if(transform.position.y < -6.4)
			{
				Destroy (gameObject);	
			}
		if (System.Math.Abs (transform.position.x) >= 8)
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
		if (otherObject.tag == "Player" )
			{
			Destroy (gameObject);
			
			}	
	}
	
}
