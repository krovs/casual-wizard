using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StorySec : MonoBehaviour 
{
    //controls the lvl0 story secuence

	Animator anim;
	string story = "Our so called hero was procrastinating hard in his so called mage tower, suddenly, a cooler version of himself from the future appeared";
	Text storyText;
	GameObject storyBox;
	AudioSource xploAudio;
	
	GameObject playerEvil;
	bool storyOff = false;
	bool entrance = false;
	bool gone = false;
	AudioSource playerEvilEntrance;
	PlayerMovement playerMovement;
	GameObject tips;

	ChatBox chatBox;
	FinalDoor finalDoor;
	
	void Start()
	{
		playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
		playerMovement.canMove = false;
		storyBox = GameObject.Find("StoryBox");
		anim = storyBox.GetComponent<Animator>();
		storyText = storyBox.transform.GetChild(0).GetComponent<Text>();
        xploAudio = storyBox.GetComponent<AudioSource>();
		playerEvil = GameObject.Find("Playerevil");
		playerEvilEntrance = playerEvil.GetComponent<AudioSource>();
		tips = GameObject.Find("Tips");
		
		//first, show introduction		
		StartCoroutine("TypeIntro");	
		
		chatBox = GameObject.Find("ChatBox").GetComponent<ChatBox>();
		finalDoor = GameObject.Find("FinalDoor").GetComponent<FinalDoor>();
	}
	
	
	void Update()
	{
		//second, show evil character
		if(storyOff)
		{
			storyOff = false;
			StartCoroutine("Entrance");			
		}
		//third, evil character speaks
		if(entrance)
		{
			entrance = false;
			StartCoroutine("EvilTalk");			
		}
		
		// last, evil character goes and door opens
		if(gone)
		{
			gone = false;			
			playerMovement.canMove = true;
			tips.GetComponent<Animator>().SetTrigger("tipIn");
		}		
	}
	
    //the evil  character is activated with an explosion
	private IEnumerator Entrance()
	{
		yield return new WaitForSeconds(1f);
		playerEvil.transform.GetChild(6).gameObject.SetActive(true);
		yield return new WaitForSeconds(.5f);
		playerEvil.transform.GetChild(0).gameObject.SetActive(true);
		playerEvil.transform.GetChild(1).gameObject.SetActive(true);
		playerEvil.transform.GetChild(2).gameObject.SetActive(true);
		playerEvilEntrance.Play();
		yield return new WaitForSeconds(1f);
		entrance = true;
	}

	//the evil  character opens a chatbox and explains himself
	private IEnumerator EvilTalk()
	{
		chatBox.ShowChat("CoolerYou", "You! with the face!, I'm running out of thingys and I need you to collect some more for me", true);
		chatBox.NoDismiss(true);
		yield return new WaitForSeconds(9f);
		chatBox.ClearChat();
		chatBox.WriteChat("I would do it myself but I don't feel like it, so this paradox and the universe depend on you.");
		yield return new WaitForSeconds(9f);
		chatBox.HideChat();
		//evil character disappears
		playerEvil.transform.GetChild(6).gameObject.SetActive(false);
		playerEvil.transform.GetChild(6).gameObject.SetActive(true);
		playerEvil.transform.GetChild(0).gameObject.SetActive(false);
		playerEvil.transform.GetChild(1).gameObject.SetActive(false);
		playerEvil.transform.GetChild(2).gameObject.SetActive(false);
		playerEvilEntrance.Play();
		finalDoor.OpenDoor();
		yield return new WaitForSeconds(4f);
		
		gone = true;
	}
	
	public void StoryDismiss()
	{
		anim.SetBool("isShowing", false);
		storyOff = true;
		StopCoroutine("TypeIntro");
	}
	
	
	private IEnumerator TypeIntro()
	{
		yield return new WaitForSeconds(1f);
		anim.SetBool("isShowing", true);
		for(int i=0; i<=story.Length-1; i++)
		{
			storyText.text+=story[i];
            xploAudio.Play();			
			yield return new WaitForSeconds(.07f);			
		}				
	}
	
	
}
