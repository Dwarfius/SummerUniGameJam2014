using UnityEngine;
using System.Collections;

public class ScrollTextureAnimation : MonoBehaviour 
{	
	//vars for the whole sheet
	public int colCount =  7;
	public int rowCount =  1;
	
	//vars for animation
	public int rowNumber;
	public int colNumber;
	public int totalCells = 7;
	public int fps = 2;
	
	[HideInInspector] public bool open;
	[HideInInspector] public bool isOpen;
	
	float timePassed = 0; 

	//public bool render;
	
	void Start()
	{
//		Vector3 pos = Camera.main.ViewportToWorldPoint(new Vector3(1, 0.51f, 1));
//		transform.position = pos;
//		renderer.material.SetTextureScale("_MainTex", Vector2.zero);
		renderer.enabled = false;

	}
	
	void Update () 
	{ 
		if(renderer.enabled == true){
		if(open)
			SetSpriteAnimation(colCount,rowCount,rowNumber,colNumber,totalCells,fps);
		}
	}
	
	void SetSpriteAnimation(int colCount, int rowCount, int rowNumber, int colNumber, int totalCells, int fps)
	{
		timePassed += Time.deltaTime;
		int index  = (int)(timePassed * fps);
		
		if(index>=totalCells)
		{
			isOpen = !isOpen;
			open = false;
			return;
		}
		
		// Size of every cell
		float sizeX = 1.0f / colCount;
		float sizeY = 1.0f / rowCount;
		Vector2 size =  new Vector2(sizeX,sizeY);
		
		// split into horizontal and vertical index
		var uIndex = index % colCount;
		var vIndex = index / colCount;
		
		// build offset
		// v coordinate is the bottom of the image in opengl so we need to invert.
		float offsetX = (uIndex+colNumber) * size.x;
		float offsetY = (1.0f - size.y) - (vIndex + rowNumber) * size.y;
		Vector2 offset = new Vector2(offsetX,offsetY);
		
		renderer.material.SetTextureOffset ("_MainTex", offset);
		renderer.material.SetTextureScale  ("_MainTex", size);
	}
	
	public void Reset()
	{
		if (open)
			return;
		
		timePassed = 0;
		open = true;
	}
}
