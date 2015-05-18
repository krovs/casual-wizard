using UnityEngine;
using System.Collections;

public class FinalDoor : MonoBehaviour 
{
	//controls the logic of a final door
    
    //gameobjects
	GameObject player;
	//ScreenFader fader;
	Controller controller;
	AudioSource audioDoor;
	Animator anim;
	ParticleSystem EvilSmoke;
   
	
	void Start()
	{
		player = GameObject.FindGameObjectWithTag("Player");
		controller = GameObject.Find("Controller").GetComponent<Controller>();
		anim = GetComponent<Animator>();
        audioDoor = GetComponent<AudioSource>();
		EvilSmoke = transform.GetChild(2).GetComponent<ParticleSystem>();        
	}	
	
    //open the door, start the animation, start smoke particles, play the sound and change the collider
	public void OpenDoor()
	{
		anim.SetBool("Open", true);
		EvilSmoke.Play();
        audioDoor.Play();
		GetComponent<BoxCollider>().isTrigger = true;
	}

	//when the player enters the door, a next level is loaded
	void OnTriggerEnter(Collider co)
	{
        if (co.gameObject == player)
        {
            controller.NextLevel();

            

        }
	}	
	
	
}
