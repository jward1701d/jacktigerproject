using UnityEngine;
using System.Collections;

public class s_Enemy2 : MonoBehaviour
{
	#region Fields
	public float MinSpeed;
	public float MaxSpeed;
	public GameObject explosion1Prefab;
	public GameObject projectilePrefab;
	
	
	
	private float enemyHealth = 20;
	
	private float currentSpeed;
	private float x, y, z;
	
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
		transform.Translate (Vector3.right * amtToMove);
		int fire = Random.Range (0, 30);
		if (fire == 10)
		{
			Vector3 position = new Vector3(transform.position.x, transform.position.y / -2 + transform.position.z);
			Instantiate (projectilePrefab, transform.position, Quaternion.identity);
		}
				
		if (transform.position.x >= 8)
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
		currentSpeed = Random.Range (MinSpeed, MaxSpeed);
		x = -8.0f;
		z = 0.0f;
		y = Random.Range (3, 5);
		
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
	
	
	IEnumerator DestroyMe()
	{
		Vector3 position = new Vector3(transform.position.x, transform.position.y + transform.position.z);
		Destroy (gameObject.gameObject);
		s_Player.Score += 100;
		Instantiate (explosion1Prefab, transform.position, Quaternion.identity);
		yield return new UnityEngine.WaitForSeconds(0.0005f);
		
	}
	
	#endregion 
}

