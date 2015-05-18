using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Controller : MonoBehaviour 
{

    //this class is a series of helpful functions 
	
	//gameobjects
	GameObject player;
	ScreenFader fader;
	Animator menuAnim;
	public GameObject loadingImage;
	FinalDoor finalDoor;
	GameObject enemies;
	Thingys thingys;
    GAchievs achiev;

	//vars
	bool completed = false;
    static bool music = true;
	
	void Awake()
	{
		player = GameObject.FindGameObjectWithTag("Player");
		fader = GameObject.Find("Fader").GetComponent<ScreenFader>();
		menuAnim = GameObject.Find("UIMenu").transform.GetChild(0).GetComponent<Animator>();
		finalDoor = GameObject.Find("FinalDoor").GetComponent<FinalDoor>();
		enemies = GameObject.Find("Enemies");
		thingys = GetComponent<Thingys>();
        achiev = GameObject.Find("Controller").GetComponent<GAchievs>();

        if (!music)
            GetComponent<AudioSource>().Stop();
            
	}


	void Update()
	{
        //check if the level has been completed
        if (Application.loadedLevel > 1)
			LevelComplete();        
	}
	
	




	//shows or hides the game menu
	public void Menu()
	{
		if(menuAnim.GetBool("showMenu") == false)
			menuAnim.SetBool("showMenu", true);
		else 
			menuAnim.SetBool("showMenu", false);
				
	}
	
	//ends thet current level and goes back to main screen
	public void EndLevel()
	{
		Menu();
		StartCoroutine(FadeAndExit(0));
	}
	
	//goes to the next level
	public void NextLevel()
	{
        if (Application.loadedLevel + 1 < 5)
        {
            switch (Application.loadedLevel)
            { 
                case 1:
                    achiev.level0();
                    break;
                case 2:
                    achiev.level1();
                    break;
                case 3:
                    achiev.level2();
                    break;
                case 4:
                    achiev.level3();
                    break;
            }
            StartCoroutine(FadeAndExit(Application.loadedLevel + 1));
            PlayerPrefs.SetInt("level", Application.loadedLevel + 1);
        }
        else
            StartCoroutine(FadeAndExit(0));
	}
	//fade the screen and load the given level
	IEnumerator FadeAndExit(int i)
	{
		fader.FadeToBlack();
		yield return new WaitForSeconds(2f);
		Application.LoadLevel(i);
	}
	
	//toggles between controller types
	public void ToggleController(Button b)
	{
		if(player.GetComponent<PlayerMovement>().controlMode == PlayerMovement.ControlMode.Mouse)
		{
			player.GetComponent<PlayerMovement>().controlMode = PlayerMovement.ControlMode.Joystick;
			b.transform.GetChild(0).GetComponent<Text>().text = "Joystick";
		}
		else
		{
			player.GetComponent<PlayerMovement>().controlMode = PlayerMovement.ControlMode.Mouse;
			b.transform.GetChild(0).GetComponent<Text>().text = "Mouse";
		}
	}
	

	//load a level
	public void Load(int level)
	{		
		StartCoroutine(FaderAndLoad(level));		
	}
	//load saved level
	public void LoadContinue()
	{		
		StartCoroutine(FaderAndLoad(PlayerPrefs.GetInt("level")));		
	}
	
	IEnumerator FaderAndLoad(int level)
	{		
		fader.FadeToBlack();
		yield return new WaitForSeconds(2f);
		loadingImage.SetActive(true);
		yield return new WaitForSeconds(1f);
		Application.LoadLevel(level);
	}
	
	
	//changes button color on click
	public void ColorOnClick(Button b)
	{
		StartCoroutine(ChangeColor(b));		
	}
	
	IEnumerator ChangeColor(Button b)
	{
		b.transform.GetChild(0).GetComponent<Text>().color = Color.cyan;
		yield return new WaitForSeconds(.2f);
		b.transform.GetChild(0).GetComponent<Text>().color = Color.white;
	}

    //restart the current level
	public void RestartLevel()
	{
		StartCoroutine(FadeAndExit(Application.loadedLevel));
	}
	
    //exit the game
	public void ExitGame()
	{
		fader.FadeToBlack();
		Application.Quit();
	}
	




    //check if the level has been completed, if so, the final door opens
	void LevelComplete()
	{

		if(GameObject.Find("Tiles"))
        {
            if(thingys.Count() == 3 && enemies.transform.childCount == 0 && completed == false && GameObject.Find("Tiles").GetComponent<DoorPuzzle>().Finished())
			{
				completed = true;
				finalDoor.OpenDoor();
			}
		}
		else
		{
			if(thingys.Count() == 3 && enemies.transform.childCount == 0 && completed == false)
			{
				completed = true;
				finalDoor.OpenDoor();
			}
		}
	}


    //mute of unmute the game music
    public void MuteMusic()
    {
        if (GetComponent<AudioSource>().isPlaying)
        {
            GetComponent<AudioSource>().Stop();
            music = false;
        }
        else
        {
            GetComponent<AudioSource>().Play();
            music = true;
        }
    }




}
