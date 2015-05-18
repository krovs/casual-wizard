using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour 
{
	//movement of the enemy

	//gameobjects
	Transform player;
	PlayerHealth playerHealth;	
	NavMeshAgent nav;
	public AudioSource stepSound;
	EnemyHealth enemyHealth;
	EnemyAttack enemyAttack;
	
	//vars
	public bool canMove = true;	
	public bool playerInRange = false;
	bool navTargetInRange;
	
	//components
	Animator anim;	
	
	
	void Awake()
	{		
		player = GameObject.FindGameObjectWithTag("Player").transform;
		playerHealth = player.gameObject.GetComponent<PlayerHealth>();	
		enemyHealth = gameObject.GetComponent<EnemyHealth>();
		enemyAttack = gameObject.GetComponent<EnemyAttack>();
		nav = GetComponent<NavMeshAgent>();
		nav.SetDestination(player.position);
		anim = gameObject.GetComponent<Animator>();		
	}
	
	
	void Update()
	{	
		if(canMove && playerInRange)
		{
			navTargetInRange = enemyAttack.playerInRange;
			nav.enabled = true;
			nav.SetDestination(player.position);  //activatets the navmesh  client if the player is in range
			if(navTargetInRange)
			{
				anim.SetBool("isWalking", false);
				if(stepSound.isPlaying)
					stepSound.Stop();
			}
			else 
			{
				anim.SetBool("isWalking", true);
				if(!stepSound.isPlaying)
					stepSound.Play();			
			}			
		}		
		else
		{	
			nav.enabled = false;			
			anim.SetBool("isWalking", false);	
			if(stepSound.isPlaying)
				stepSound.Stop();
		}		
	}
	
    //little bounce when hit
	public void BounceBack()
	{		
		StartCoroutine("BounceBackWait");
	}
	
	IEnumerator BounceBackWait()
	{
		canMove = false;
		yield return new WaitForSeconds(.3f);
		if(!playerHealth.isDead && !enemyHealth.isDead)
			canMove = true;
	}
	
	
}
