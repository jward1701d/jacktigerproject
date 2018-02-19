using UnityEngine;
using System.Collections;

public class s_ProjectileLaser : MonoBehaviour 
{
	public static int laserCount; 
	public GameObject lazzer;
	public float projectileDamage;
	
	public float projectileSpeed;
	public static int count = 0; 
	public static Vector3 position;
	
	
	// Use this for initialization
	void Start () 
	{
		position = new Vector3(transform.position.x, transform.position.y,  transform.position.z);
		StartCoroutine(Fire ()); 
	
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
		count ++;
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
	
	IEnumerator Fire()
	{
		for (int x = 1; x<= 12; x++)
		{
			Instantiate (lazzer, position, Quaternion.identity);
		    yield return new UnityEngine.WaitForSeconds(0.005f);
		}
	}
	
}
