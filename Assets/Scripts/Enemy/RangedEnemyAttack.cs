using UnityEngine;
using System.Collections;

public class RangedEnemyAttack : MonoBehaviour 
{
	//attacks the player in the distance
	
	//gameobjects
	public Rigidbody prefab;
	public Transform spawnPoint;
	GameObject player;
	
	AudioSource shotSound;
	
	//components
	EnemyHealth enemyHealth;
	PlayerHealth playerHealth;
	
	//vars
	float timer;
	public float speed;
	public float coolDown;
	public float lifeTime;
	public int damage;
	bool playerInRange;	
	float turnSmoothing = 8f;	
	
	
	
	void Start()
	{		
		player = GameObject.FindGameObjectWithTag("Player");
		playerHealth = player.GetComponent<PlayerHealth>();
		enemyHealth = gameObject.GetComponent<EnemyHealth>();
		shotSound = gameObject.GetComponent<AudioSource>();		
	}
	
	
	void FixedUpdate()
	{		
		timer += Time.deltaTime;
		
		if(timer >= coolDown && playerInRange && !enemyHealth.isDead)
			Cast ();		
	}
	
	
	void OnTriggerStay(Collider co)       
	{		
		if(co.gameObject == player && !enemyHealth.isDead)
		{
			playerInRange = true;
			PointPlayer();
		}		
	}
	
	void OnTriggerExit(Collider co)
	{	
		if(co.gameObject == player)
			playerInRange = false;
	}
	
	//creates a prefab and cast it to the player
	public void Cast()
	{		
		timer = 0f;	
		if(!playerHealth.isDead)
		{	
			Rigidbody newSpell = Instantiate(prefab.GetComponent<Rigidbody>(),spawnPoint.position,spawnPoint.rotation) as Rigidbody;	
			newSpell.GetComponent<EnemySpellLife>().damage = this.damage;
			newSpell.GetComponent<EnemySpellLife>().lifeTime = this.lifeTime;
			newSpell.AddForce(spawnPoint.forward*speed);
			shotSound.Play();
		}	
	}
	
    //the enemy points to the player with a delay, tank style
	void PointPlayer()
	{
		Quaternion targetRotation = Quaternion.LookRotation(player.transform.position-transform.position);
		transform.rotation = Quaternion.Slerp(transform.rotation,targetRotation,Time.deltaTime*turnSmoothing);	
	}
}