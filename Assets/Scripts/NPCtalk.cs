using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class NPCtalk : MonoBehaviour 
{
	//vars
	string npc_name = "Default old man";
	string npc_dialog = "...";	
	
	public bool isStatic;	//character or sign
	
	//gameobjects
	GameObject player;
	PlayerHealth playerHealth;
    GAchievs achiev; 
    ChatBox chatBox;	
	
	//components
	Animator talkAnim;
	AudioSource talkSound;	
	
	//controller
	ControlDialogs controlDialogs;
	List<ControlDialogs.Dialog> dialogs;
	
	
	
	void Awake()
	{
		player = GameObject.FindGameObjectWithTag("Player");
		playerHealth = player.GetComponent<PlayerHealth>();			
		
		
		chatBox = GameObject.Find("ChatBox").GetComponent<ChatBox>();
		
		//if the npc is not a person
        if(!isStatic)
		{
			talkAnim = gameObject.GetComponent<Animator>();
			talkSound = gameObject.GetComponent<AudioSource>();
		}
		
		controlDialogs = GameObject.Find("Controller").GetComponent<ControlDialogs>();
		dialogs = controlDialogs.dialogs;

        achiev = GameObject.Find("Controller").GetComponent<GAchievs>();
	}	
	
	
	void OnTriggerEnter(Collider co)       
	{
		if(co.gameObject == player && !playerHealth.isDead)
        { 
            foreach (ControlDialogs.Dialog d in dialogs) //search on dialogs for the correct npc dialog
            {
                if (d.id == gameObject.name)
                {
                    npc_name = d.name;
                    npc_dialog = d.dialog;
                    break;
                }
            }	
			chatBox.ShowChat(npc_name, npc_dialog, isStatic); //show the chatbox with this npc dialog
			if(!isStatic)
			{
				talkAnim.SetBool("isTalking", true);
				talkSound.Play();
			}
            achiev.CountOld(); //adds one to the achiev counter
        }
	}
	
	//hide the chat and end the animation
	void OnTriggerExit(Collider co)       
	{
        if (co.gameObject == player)
        {
            chatBox.HideChat();
            if (!isStatic)
                talkAnim.SetBool("isTalking", false);
        }
	}	
	
	
}
