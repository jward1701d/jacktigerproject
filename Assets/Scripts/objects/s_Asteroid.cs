using UnityEngine;
using System.Collections;
using System;

public class s_Asteroid : MonoBehaviour
{
	#region Fields
	public float MinSpeed;
	public float MaxSpeed;
	public GameObject explosion1Prefab;
	
	private float currentSpeed;
	private float x, y, z;
	private float asteroidXRotation = UnityEngine.Random.Range (-1, 1);
	private	float asteroidYRotation = UnityEngine.Random.Range (-2, 3);
	
	
	#endregion
	
	#region Properties
	#endregion 
	
	#region Functions
	void Start ()
	{
		SetPositionAndSpeed();
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		float amtToMove = currentSpeed * Time.deltaTime;
		transform.Translate (Vector3.down * amtToMove, Space.World);
		transform.Rotate (asteroidXRotation, asteroidYRotation, 0.0f, UnityEngine.Space.World);
		float astX = transform.position.x;
		float astY = transform.position.y;
		transform.position = new Vector3(astX, astY, 0.0f);
		
		if (transform.position.y <= -5)
		{
			Destroy (gameObject);
			//s_Player.population -= 20 ;
		}
		if (System.Math.Abs (transform.position.x) >= 8)
		{
			Destroy (gameObject);
		}
	}
	
	public void SetPositionAndSpeed()
	{
		currentSpeed = UnityEngine.Random.Range (MinSpeed, MaxSpeed);
		y = 8.0f;
		z = 0.0f;
		x = UnityEngine.Random.Range (-6, 6);
		
		transform.position = new Vector3(x,y,z);
		//transform.Rotate(90.0f, 0.0f, 0.0f); 
	}
	void OnTriggerEnter(Collider otherObject)
	{
	
	}
	
	#endregion 
}

