using UnityEngine;
using System.Collections;
using System;

public class s_Enemy3 : MonoBehaviour
{
	#region Fields
	public float MinSpeed;
	public float MaxSpeed;
	public GameObject explosion1Prefab;
	public GameObject projectilePrefab;
	//public GameObject playerObject;
	
	private float enemyHealth = 10;
	
	private float currentSpeed;
	private float x, y, z;
	private float xRot = UnityEngine.Random.Range (-3, 3);
	public float bottom;
	private int fireEnable = 1;
	//private float yRot = UnityEngine.Random.Range (-4, 4);
	
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
		transform.Translate (Vector3.down * amtToMove);
		transform.position = new Vector3(transform.position.x, transform.position.y, 0.0f);
		//Vector3 rotator = new Vector3(4.0f, 0.0f, 0.0f);
		
		transform.Rotate(2, 0, 0, UnityEngine.Space.World);
		
		if (fireEnable == 1)
		{
			if (transform.position.y <= bottom)
			{
				Vector3 position = new Vector3(transform.position.x, transform.position.y / -2 + transform.position.z);
				Instantiate (projectilePrefab, transform.position, Quaternion.Euler (transform.rotation.x,transform.position.y, findTarget ()));
				fireEnable = 0;
			}
		}
		if (transform.position.y >= 5)
		{
			fireEnable = 1;
		}
		
		
		
		
		if (transform.position.y <= -5)
		{
			Destroy (gameObject);
			s_Player.population -= 50 ;
		}
		if (enemyHealth <= 0)
			{
				StartCoroutine (DestroyMe ());
			}
	}
	
	public void SetPositionAndSpeed()
	{
		currentSpeed = UnityEngine.Random.Range (MinSpeed, MaxSpeed);
		y = 6;
		z = 0.0f;
		x = UnityEngine.Random.Range (-6, 6);
		
		transform.position = new Vector3(x,y,z);
		//transform.Rotate(90.0f, 0.0f, 0.0f); 
	}
	void OnTriggerEnter(Collider otherObject)
	{
		if (otherObject.tag == "player_weapon")
		{
		 	enemyHealth -= s_Player.myDamage;
			
	
		}
		if (otherObject.tag == "Player")
		{
				
			
			enemyHealth = 0;
	
		}
		
		if (otherObject.tag == "crashable")
		{
				
			
			enemyHealth = 0;
	
		}
			if (otherObject.tag == "enemy")
		{
			enemyHealth = 0;
		}
		
		
	}
	
	float findTarget()
	{
		double height =  gameObject.transform.position.y - GameObject.Find("p_Player(Clone)").transform.position.y;
		height = height * height;
		double width = gameObject.transform.position.x - GameObject.Find("p_Player(Clone)").transform.position.x;
		double swidth = width * width;
		double hypot = height + swidth;
		hypot = System.Math.Sqrt (hypot);
		double angle = width / hypot;
		angle = System.Math.Asin (angle) * 180 / 3.14;
		float myAngle = (float)angle;
		myAngle = myAngle * -1;
		return myAngle;
					
	}
	IEnumerator DestroyMe()
	{
		Vector3 position = new Vector3(transform.position.x, transform.position.y + transform.position.z);
		Destroy (gameObject.gameObject);
		s_Player.Score += 300;
		Instantiate (explosion1Prefab, transform.position, Quaternion.identity);
		yield return new UnityEngine.WaitForSeconds(0.0005f);
		
	}
	
	#endregion 
}

