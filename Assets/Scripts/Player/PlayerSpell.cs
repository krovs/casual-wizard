using UnityEngine;
using System.Collections;

public class PlayerSpell : MonoBehaviour 
{
	//generates the player spell

	//gameobjects
	public Rigidbody prefab;
	public Transform spawnPoint;
	Rigidbody newSpell;
	
	//vars
	public enum Spell {LightningBolt, FireBall, Heal};
	public Spell spell;
	public float speed;
	float timer;
	public float coolDown;
	public bool canCast;	
	public float lifeTime;
	public int damage;	
	public int spellID;
	public float animationLength;
	bool refreshSpawnPosition;
	public bool self;
	
	//components
	Animator anim;
	
	
	
	void Start()
	{			
		anim = GetComponent<Animator>();			
	}	
	
	void Update()
	{		
		timer += Time.deltaTime;
		
		if(timer >= coolDown)
			canCast = true;		
		else
			canCast = false;			
		
		if(anim.GetCurrentAnimatorStateInfo(1).IsName(spell.ToString()))
			anim.SetInteger("Casting", 0);
			
		if(refreshSpawnPosition)
			RefreshSpawnPosition();
			
	}
	
    //creates the prefab and moves it
	public void Cast()
	{
		if(canCast)
		{	
			anim.SetInteger("Casting", spellID);
			timer = 0f;				
			
			if(!self) //if the spell is not heal
			{
				newSpell = Instantiate(prefab.GetComponent<Rigidbody>(),spawnPoint.position, spawnPoint.rotation) as Rigidbody;
				newSpell.GetComponent<SphereCollider>().enabled = false;
			}
			else
				newSpell = Instantiate(prefab.GetComponent<Rigidbody>(),spawnPoint.position, prefab.transform.rotation) as Rigidbody;	
				
			refreshSpawnPosition = true;
			newSpell.GetComponentInParent<SpellLife>().damage = this.damage;
			newSpell.GetComponentInParent<SpellLife>().lifeTime = this.lifeTime;
			if(self)
			{
				newSpell.GetComponentInParent<SpellLife>().self = this.self;
				GetComponent<PlayerMovement>().canMove = false;
			}
			StartCoroutine(WaitAndCast(animationLength, newSpell));			
			
		}		
	}

    //move the prefab while casting
	void  RefreshSpawnPosition()
	{
		newSpell.MovePosition(spawnPoint.position);
	}
	
	//the prefab waits to be casted until the animation ends
	IEnumerator WaitAndCast(float animTime, Rigidbody newSpell)
	{
		yield return new WaitForSeconds(animTime);
		refreshSpawnPosition = false;
		newSpell.gameObject.GetComponent<AudioSource>().Play();
		if(!self)
		{
			newSpell.transform.rotation = gameObject.transform.rotation;
			newSpell.AddForce(spawnPoint.forward*speed);
			newSpell.GetComponent<SphereCollider>().enabled = true;
		}
		else
			GetComponent<PlayerMovement>().canMove = true;
	}
	
}