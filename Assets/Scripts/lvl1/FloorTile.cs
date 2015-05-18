using UnityEngine;
using System.Collections;

public class FloorTile : MonoBehaviour 
{

	//the logic of a tile, activating or deactivating itself
    
    //vars
	public bool activated;
	
	//components
	Animator anim;
	AudioSource sound;
	
	//gameobjects
	GameObject player;
	//Light colorLight;
	
	
	
	void Start()
	{
		anim = gameObject.GetComponent<Animator>();
		player = GameObject.FindGameObjectWithTag("Player");
		sound = gameObject.GetComponent<AudioSource>();
	}
	
	
	void OnTriggerEnter(Collider co)
	{
		if(!activated && co.gameObject == player){
			activated = true;
			anim.SetBool("reset", false);
			anim.SetBool("onTop", true);
			sound.Play();
		}
	}	
	
	public void Deactivate()
	{
		activated = false;		
		anim.SetBool("reset", true);
		anim.SetBool("onTop", false);
		sound.Play();
	}
}
