using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Thingys : MonoBehaviour 
{

    //class that controls the thingy UI and returns the current thingys collected

	int thingys;
	Text uithingys;


	void Start () 
	{
		uithingys = GameObject.Find("Items").GetComponent<Text>();
	}
	
    //changes the UI
	public void Add()
	{
		thingys += 1;
        uithingys.text = thingys.ToString() + "/3 thingys";
	}

    //returns the number of thingys collected
	public int Count()
	{
		return thingys;
	}
}
