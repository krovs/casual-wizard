using UnityEngine;
using System.Collections;

public class DoorPuzzle : MonoBehaviour 
{

    //controls the level1 puzzle
	
	Animator anim;
	BoxCollider coll;
	AudioSource sound;
	
	GameObject tileB;
	GameObject tileG;
	GameObject tileY;
	GameObject tileR;
	FloorTile[] tiles;
	
	public int tB = 8;
	public int tG = 8;
	public int tY = 8;
	public int tR = 8;
	
	bool reset;
	bool finished;
	
	
	
	
	void Start()
	{		
		tileB = transform.GetChild(0).gameObject;
		tileG = transform.GetChild(1).gameObject;
		tileY = transform.GetChild(2).gameObject;
		tileR = transform.GetChild(3).gameObject;	
		tiles = transform.GetComponentsInChildren<FloorTile>();			
	}
	
	void Update()
	{
		if(!finished) //if not finished, the tiles restart
		{		
			if(tileB.GetComponent<FloorTile>().activated == true && tB == 8)
				tB = Order();
			if(tileG.GetComponent<FloorTile>().activated == true && tG == 8)
				tG = Order();
			if(tileY.GetComponent<FloorTile>().activated == true && tY == 8)
				tY = Order();
			if(tileR.GetComponent<FloorTile>().activated == true && tR == 8)
				tR = Order();
			
			
			if(Solution())
			{
                finished = true;
			}
			if((!Solution()) && (tB!=8 && tG!=8 && tY!=8 && tR!=8))
			{	
				tileB.GetComponent<FloorTile>().Deactivate();
				tileG.GetComponent<FloorTile>().Deactivate();
				tileY.GetComponent<FloorTile>().Deactivate();
				tileR.GetComponent<FloorTile>().Deactivate();
				tB = tG = tY = tR = 8;
			}
		}		
	}
	
    //return the order number of each tile
	int Order()
	{		
		int counter = 0;
		foreach(FloorTile t in tiles)
		{
			if(t.activated == true)
				counter ++;
		}
		return counter-1;			
	}
	
	//check the order for solution
	bool Solution()
	{
		if( tB  == 2 && tG == 3 && tY == 0 && tR == 1)
			return true;
		
		return false;
	}
	

	public bool Finished()
	{
		return finished;
	}
	
}
