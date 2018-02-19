using UnityEngine;
using System.Collections;
using System;

public class s_Spew : MonoBehaviour
{
	#region Fields
	public float MinSpeed;
	public float MaxSpeed;
	public GameObject explosion1Prefab;
	public GameObject projectilePrefab;
	//public GameObject playerObject;
	
	public float enemyHealth;
	
	public float currentSpeed;
	private float x, y, z;
	private int moving = 0;
	private bool isAlive = true;
	
	
	
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
		if (isAlive == true)
		{
		float amtToMove = currentSpeed * Time.deltaTime;
		transform.Translate (Vector3.right * amtToMove);
		transform.position = new Vector3(transform.position.x, transform.position.y, 0.0f);
	    int rand = UnityEngine.Random.Range (0, 25);
	
			if (rand == 10)
			{
			
				Vector3 position = new Vector3(transform.position.x, transform.position.y / -2 + transform.position.z);
				Instantiate (projectilePrefab, transform.position, Quaternion.Euler (transform.rotation.x,transform.position.y, findTarget ()));
			
			}
		
		
		if (amtToMove <= 0)
		{
			if (transform.position.x >= -7.6)
			{
				transform.Translate (Vector3.right * amtToMove);
			}
			else 
				currentSpeed *= -1;
		}
		if (amtToMove >= 0)
		{
			if (transform.position.x <= 7.6)
			{
				transform.Translate (Vector3.right * amtToMove);
			}
			else 
				currentSpeed *= -1;
			
			
			
		}
		
		
		int movement = UnityEngine.Random.Range (0, 200);
		if (movement == 10)
		{
			currentSpeed *= -1;	
		}
				
		if (enemyHealth <= 0)
			{
				StartCoroutine (DestroyMe ());
			}
		}
		
		
	}
	
	
	public void SetPositionAndSpeed()
	{
		transform.position = new Vector3(0.0f, 4.0f, 0.0f);
		
	}
	
	
	void OnTriggerEnter(Collider otherObject)
	{
		if (otherObject.tag == "player_weapon")
		{
		 	enemyHealth -= s_Player.myDamage;
			
	
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
		isAlive = false;
		Instantiate (explosion1Prefab, transform.position, Quaternion.identity);
		s_Player.Score += 10000;
		gameObject.GetComponent<Renderer>().enabled = false;
		yield return new WaitForSeconds(4.0f);
		s_HighScoreSystem.SaveToFile(s_Player.Score);
		Application.LoadLevel (4);
		
		
		
	}
	
	#endregion 
}

