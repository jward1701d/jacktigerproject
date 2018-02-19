using UnityEngine;
using System.Collections;

public class s_Enemy1 : MonoBehaviour
{
	#region Fields
	public float MinSpeed;
	public float MaxSpeed;
	public GameObject explosion1Prefab;
	
	
	private float enemyHealth = 10;
	private float currentSpeed;
	private float x, y, z;
	
	public GameObject item1;
	public GameObject item2;
	public GameObject item3;
	public GameObject item4;
	
	
	
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
		transform.Rotate (0.0f, 5.0f, 0.0f);
		
		if (transform.position.y <= -5)
		{
			Destroy (gameObject);
			s_Player.population -= 20 ;
		}
		if (enemyHealth <= 0)
			{
				StartCoroutine (DestroyMe ());
			}
	}
	
	public void SetPositionAndSpeed()
	{
		currentSpeed = Random.Range (MinSpeed, MaxSpeed);
		y = 7.0f;
		z = 0.0f;
		x = Random.Range (-6, 6);
		
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
		
		if (otherObject.tag == "enemy_weapon")
		{
			enemyHealth -= 10;
		}
		
	}
	IEnumerator DestroyMe()
	{
		int itemDrop = Random.Range (0, 12);
		Vector3 position = new Vector3(transform.position.x, transform.position.y + transform.position.z);
		Destroy (gameObject.gameObject);
		s_Player.Score += 100;		
		Instantiate (explosion1Prefab, transform.position, Quaternion.identity);
		if (itemDrop == 5)
		{
			Instantiate (item1, transform.position, Quaternion.identity);
		}
		if (itemDrop == 10)
		{
			Instantiate (item2, transform.position, Quaternion.identity);
		}
		if (itemDrop == 11)
		{
			Instantiate (item3, transform.position, Quaternion.identity);
		}
		if (itemDrop == 9)
		{
			Instantiate (item4, transform.position, Quaternion.identity);
		}
		
		yield return new UnityEngine.WaitForSeconds(0.0005f);
		
	}
	
	#endregion 
}

