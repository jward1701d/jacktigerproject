using UnityEngine;
using System.Collections;
using System;

public class s_Player : MonoBehaviour {

	public static int playerSpeed = 5;	
	public GameObject projectilePrefab;
	public GameObject laserPrefab;
	public GameObject spreadPrefab;
	public float laserDamage;
	public float bulletDamage;
	public GameObject enemy1Prefab;
	public GameObject enemy2Prefab;
	public GameObject enemy3Prefab;
	public GameObject asteroidPrefab;
	public GameObject shieldPrefab;
	public GUISkin gameGUI; 
	public GameObject explosion1;
	
	
	enum State
	{
		Playing,
		Explosion,
		Invincible
	}
	
	private Quaternion tempRot;
	private State state = State.Playing;
	private float shipInvisibleTime = 1.5f;
	private float spawnSpeed = 3;
	private float blinkRate = .2f;
	private int numOfBlinks = 5;
	private int blinkCount;

	//public Texture imgLives;
	//public Texture imgDed;
	public static int population = 100;
	public static int Score = 0;
	public static int Lives = 3;
	public static string weaponType = "mainCannon";
	public static float myDamage;
	public static float myHealth = 10;
	
	
	
	// Update is called once per frame
 void Start ()
	{
		tempRot = this.transform.rotation;
		transform.position = new Vector3(0f, -5.5f, 0.0f);
		while (transform.position.y < -3.2)
			{
				float amtToMove = spawnSpeed * Time.deltaTime;	
				transform.position = new Vector3(0f, transform.position.y + amtToMove, transform.position.z);
			}
		Instantiate (shieldPrefab, transform.position, Quaternion.identity);
		
	}
	void Update () 
	{
		if (state != State.Explosion)
		{
		if (s_Player.population <= 0)
		{
			StartCoroutine (DestroyShip());
			population = 100;
		}
		
		if (s_level.enemiesSpawning == true)
				
			{
		
		int rnd = UnityEngine.Random.Range (0, 400);
		if (rnd == 10)
		{
			Instantiate (enemy1Prefab);
		}
		
		int rind = UnityEngine.Random.Range (0, 500);
			
		if (rind == 20)
		{
			Instantiate (enemy2Prefab);
		}
		
		int rond = UnityEngine.Random.Range (0, 700);
			
		if (rind == 20)
		{
			Instantiate (asteroidPrefab);
		}
		
		int rund = UnityEngine.Random.Range (0, 600);
			
		if (rund == 20)
		{
			Instantiate (enemy3Prefab);
		}
			}
		//amount to move
		float amtToMovelr = Input.GetAxis("Horizontal") * playerSpeed * Time.deltaTime; 
		float amtToMoveud = Input.GetAxis ("Vertical") * playerSpeed * Time.deltaTime;
		if (Input.GetKeyDown ("left"))
		{
			transform.Rotate(0.0f, 30.0f, 0.0f);
			
		}
		if (Input.GetKeyUp ("left"))
		{
			this.transform.rotation = tempRot;
		}
		if (Input.GetKeyDown ("right"))
		{
			transform.Rotate(0.0f, -30.0f, 0.0f);
		}
		if (Input.GetKeyUp ("right"))
		{
			this.transform.rotation = tempRot;
		}
		if (Input.GetKeyDown ("a"))
		{
			transform.Rotate(0.0f, 30.0f, 0.0f);
		}
		if (Input.GetKeyUp ("a"))
		{
			this.transform.rotation = tempRot;
		}
		if (Input.GetKeyDown ("d"))
		{
			transform.Rotate(0.0f, -30.0f, 0.0f);
		}
		if (Input.GetKeyUp ("d"))
		{
			this.transform.rotation = tempRot;
		}
		//move the player
		if (amtToMovelr <= 0)
		{
			if (transform.position.x >= -7.6)
			{
				transform.Translate (Vector3.right * amtToMovelr);
			}
		}
		if (amtToMovelr >= 0)
		{
			if (transform.position.x <= 7.6)
			{
				transform.Translate (Vector3.right * amtToMovelr);
			}
		}
		if (amtToMoveud <= 0)
		{
			if (transform.position.y >= -3.8)
			{
				transform.Translate (Vector3.up * amtToMoveud);
			}
		}
		if (amtToMoveud >= 0)
		{
			if (transform.position.y <= 0.2)
			{
				transform.Translate (Vector3.up * amtToMoveud);
			}
		}
		float shipX = transform.position.x;
		float shipY = transform.position.y;
		transform.position = new Vector3(shipX, shipY, 0.0f);
	 	shieldPrefab.transform.position = new Vector3(shipX, shipY, 0.0f);
		if (Input.GetKeyDown ("space"))
		{
			StartCoroutine(Fire());
		}
		}
		
		if (myHealth <= 0)
		{
			StartCoroutine (DestroyShip ());
		}
		if(Input.GetKeyUp(KeyCode.Escape))
			{
				Application.LoadLevel(1);
			}
		
		
		
		//fire
		
			
		
		
		
	}
	
	void OnGUI()
	{
		BuildUI ();
	}
	
	void BuildUI()
	{
		GUI.skin = gameGUI;
		GUI.Label (new Rect(1, 1, 200, 30), "SCORE: " + s_Player.Score.ToString ());
		GUI.Label (new Rect(1, 20, 200, 30), "POPULATION: " + s_Player.population.ToString ());
		GUI.Label (new Rect(10, 300, 200, 30), "LIVES: " + s_Player.Lives.ToString ());
	}
	
	void OnTriggerEnter(Collider otherObject)
	{
		if (otherObject.tag == "enemy" && state == State.Playing)
		{
			myHealth = 0;
		}
		
		if (otherObject.tag == "crashable" && state == State.Playing)
		{
			myHealth = 0;
		}
		
		if (otherObject.tag == "enemy_weapon" && state == State.Playing)
		{
			myHealth -= 10;
		}
		
		if (otherObject.tag == "spread" && state == State.Playing)
		{
			weaponType="spreadGun";
		}
		if (otherObject.tag == "laser" && state == State.Playing)
		{
			weaponType="laserGun";
		}
		if (otherObject.tag == "shield" && state == State.Playing)
		{
			myHealth = 30;
		}
		if (otherObject.tag == "speed" && state == State.Playing)
		{
			playerSpeed = 7;
		}
		
	}

	IEnumerator DestroyShip()
	{
		state = State.Explosion;
		s_Player.Lives --;
		myHealth = 10; 
		Instantiate (explosion1, transform.position, Quaternion.identity);
		s_Player.weaponType = "mainCannon";
		s_Player.playerSpeed = 5;
		s_Player.myDamage = 10.0f;
		gameObject.GetComponent<Renderer>().enabled = false;
		transform.position = new Vector3(0f, -5.5f, transform.position.z);
		yield return new UnityEngine.WaitForSeconds(shipInvisibleTime);
		if (s_Player.Lives > 0)
		{
				
			gameObject.GetComponent<Renderer>().enabled = true;
			while (transform.position.y < -3.2)
			{
				float amtToMove = spawnSpeed * Time.deltaTime;	
				transform.position = new Vector3(0f, transform.position.y + amtToMove, transform.position.z);
				yield return 0;
			}
			state = State.Invincible;
			
			while (blinkCount < numOfBlinks)
			{
				gameObject.GetComponent<Renderer>().enabled	= !gameObject.GetComponent<Renderer>().enabled;
				if (gameObject.GetComponent<Renderer>().enabled == true)
					blinkCount++;
				yield return new WaitForSeconds(blinkRate);
			}
			blinkCount = 0;
			state = State.Playing;
				
		}
		else
		{
			//int temp = Score;
			s_HighScoreSystem.SaveToFile(Score);
			Application.LoadLevel (5);
		}
				
	}
	
	
	IEnumerator Fire()
	{
		if (weaponType=="mainCannon")
		{
			myDamage = 10.0f;
			
			Vector3 position = new Vector3(transform.position.x, transform.position.y + (transform.localScale.y / 2));
			Instantiate (projectilePrefab, position, Quaternion.identity);
			
		}
		
		if (weaponType=="spreadGun")
		{
			myDamage = 10.0f;
			Vector3 position = new Vector3(transform.position.x, transform.position.y + (transform.localScale.y / 2));
			Instantiate (spreadPrefab, position, Quaternion.identity);
			
		}
		
		if (weaponType=="laserGun")
		{
			myDamage = 2.0f;
			Vector3 position = new Vector3(transform.position.x, transform.position.y + (transform.localScale.y / 2));
			Instantiate (laserPrefab, position, Quaternion.identity);
		}
		yield return new UnityEngine.WaitForSeconds(0.0005f);
	}
	
	IEnumerator ShieldsUp()
	{
		shieldPrefab.GetComponent<Renderer>().enabled = true;
		yield return new UnityEngine.WaitForSeconds(0.0f);
	}
	IEnumerator ShieldsDown()
	{
		shieldPrefab.GetComponent<Renderer>().enabled = false;
		yield return new UnityEngine.WaitForSeconds(0.0f);
	}
	
}
