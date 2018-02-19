using UnityEngine;
using System.Collections;

public class s_ProjectileSpread : MonoBehaviour 


	
	


{
	public GameObject thisBullet1;
	//public GameObject thisBullet2;
	public float projectileSpeed;
	public int projectileDamage;
		
	// Use this for initialization
	void Start () 
	{
		
		Instantiate (thisBullet1, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.Euler (transform.rotation.x,transform.position.y, 3.0f));
		Instantiate (thisBullet1, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.Euler (transform.rotation.x,transform.position.y, 6.0f));
		Instantiate (thisBullet1, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.Euler (transform.rotation.x,transform.position.y, 9.0f));
		Instantiate (thisBullet1, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.Euler (transform.rotation.x,transform.position.y, -3.0f));
		Instantiate (thisBullet1, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.Euler (transform.rotation.x,transform.position.y, -6.0f));
		Instantiate (thisBullet1, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.Euler (transform.rotation.x,transform.position.y, -9.0f));
			
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
			Destroy (gameObject);
			
			}
		if (otherObject.tag == "enemy" )
			{
			Destroy (gameObject);
			
			}	
	}
	
}
