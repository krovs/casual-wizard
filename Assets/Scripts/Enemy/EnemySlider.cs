using UnityEngine;
using System.Collections;

public class EnemySlider : MonoBehaviour 
{
    //moves the slider under the enemy

	Transform target;
	

	void Start()
	{
		target = gameObject.transform.parent.parent.gameObject.transform;
	}
	
	
	void Update()
	{
		Vector3 pos = Camera.main.WorldToScreenPoint(target.position);
		pos.y-=30;
		
		transform.position = pos;
	}
}
