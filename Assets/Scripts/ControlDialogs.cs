using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ControlDialogs: MonoBehaviour
{	
    //class that stores all dialogs, each dialog is a Dialog class

	[System.Serializable]
	public class Dialog
	{
		public string id;
		public string name;
		public string dialog;
		
		public Dialog(string id, string name, string dialog)
		{
			this.id = id;
			this.name = name;
			this.dialog = dialog;
		}
		
	}
	public List<Dialog> dialogs;
	
	
	
	void Awake()
	{
		dialogs.Add(new Dialog("npc1.1", "Casual old man", "Robots, why did it have to be robots!?"));
        dialogs.Add(new Dialog("npc1.2", "Peterfligo", "The thingys are well protected, try throwing rocks or something..."));
        dialogs.Add(new Dialog("npc1.3", "Veryhugerstone", "I don't even fit in my house anymore...I'll just stay here..."));
        dialogs.Add(new Dialog("npc1.4", "Passiworth", "This town is not that bad as it seems...if you ignore the crazy robots..."));
        dialogs.Add(new Dialog("npc1.5", "Crazederk", "Praise the thingy!!!"));
        dialogs.Add(new Dialog("npc1.6", "Stringerlo", "Maybe there is a final boss at the end of this road...maybe"));
        dialogs.Add(new Dialog("npc1.7", "Old man for sure", "No time to waste on the illuminati or the reflexion of the snake will devour you."));

        dialogs.Add(new Dialog("npc2.1", "Obviousert", "This town is creepy as hell, traveller, just saying"));
        dialogs.Add(new Dialog("npc2.2", "Carnotwores", "Sup? Just chilling"));
        dialogs.Add(new Dialog("npc2.3", "Freemans", "My house is on fire and my wife is there, I mean, you don't need to save her..."));
        dialogs.Add(new Dialog("npc2.4", "Dieyourseth", "Do you know how to beat this boss?, I don't know, I'm asking"));

        dialogs.Add(new Dialog("sign1.1", "Old sign", "Old people town ahead, be aware of the funny smell..."));
        dialogs.Add(new Dialog("sign1.2", "Old sign", "To another old people town, also with robots"));

        dialogs.Add(new Dialog("sign2.1", "Old sign", "Thingy over there to the left"));
        dialogs.Add(new Dialog("sign2.2", "Old sign", "Creepy house"));

        dialogs.Add(new Dialog("npc3.1", "Creepyrton", "It's no cold here, I have my pijamas on...eh eh eh"));
        dialogs.Add(new Dialog("npc3.2", "Bfforverth", "My friend just disappeared and I don't know where he is, I don't care either..."));
        dialogs.Add(new Dialog("npc3.3", "Hannioldman", "Oh hi!, come inside, I want to eat y...with you!"));

        dialogs.Add(new Dialog("Kitty", "Evilneko", "Collect three thingys on each level and be free of your sad future you..."));
        
	}
	
	
	
	
	
	
}

