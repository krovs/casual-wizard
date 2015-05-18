using UnityEngine;
using System.Collections;

public class ShadowDistance : MonoBehaviour
{
    //changes the shadowdistance of the main menu 
    
    public int distance;

	void Awake () 
    {
        QualitySettings.shadowDistance = distance;
	}
	
	
}
