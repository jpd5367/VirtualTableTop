//----------------------------------------------
//            NGUI: Next-Gen UI kit
// Copyright © 2011-2014 Tasharen Entertainment
//----------------------------------------------

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
[AddComponentMenu("NGUI/Examples/Drag and Drop Item (Example)")]
public class DragDropTile : UIDragDropItem
{
	/// <summary>
	/// Prefab object that will be instantiated on the DragDropSurface if it receives the OnDrop event.
	/// </summary>

	public GameObject prefab;
	public GameObject newSpot;


	/// <summary>
	/// Drop a 3D game object onto the surface.
	/// </summary>
	

	protected override void OnDragDropRelease (GameObject surface)
	{
		if (surface != null)
		{
			ExampleDragDropSurface dds = surface.GetComponent<ExampleDragDropSurface>();
			surface.GetComponent<MeshRenderer>().enabled = false;
			if (dds != null)
			{
				GameObject temp;
				GameObject child = NGUITools.AddChild(dds.gameObject, prefab);
				//child.transform.localScale = dds.transform.localScale;

				Transform trans = child.transform;
				trans.position = dds.transform.position;//UICamera.lastHit.point;

				if (dds.rotatePlacedObject)
				{
					trans.rotation = Quaternion.LookRotation(UICamera.lastHit.normal) * Quaternion.Euler(90f, 0f, 0f);
				}
				if(prefab.name == "Center"){
					//Tile to left
					if(!MapBuilder.tiles.ContainsKey((trans.position.x-5).ToString()+","+trans.position.y.ToString()+","+trans.position.z.ToString())){
						temp = Instantiate(newSpot,new Vector3(trans.position.x -5, trans.position.y, trans.position.z), prefab.transform.rotation)as GameObject; 
						temp.name = (trans.position.x-5).ToString()+","+trans.position.y.ToString()+","+trans.position.z.ToString();
						temp.transform.parent = GameObject.Find("MapGrid").transform;
						MapBuilder.tiles.Add((trans.position.x-5).ToString()+","+trans.position.y.ToString()+","+trans.position.z.ToString(), temp);
				
					}
					// tile to bottom
					if(!MapBuilder.tiles.ContainsKey((trans.position.x).ToString()+","+(trans.position.y).ToString()+","+(trans.position.z-5).ToString())){
						temp = Instantiate(newSpot,new Vector3(trans.position.x, trans.position.y, trans.position.z-5), prefab.transform.rotation)as GameObject; 
						temp.name = (trans.position.x).ToString()+","+(trans.position.y).ToString()+","+(trans.position.z-5).ToString();
						temp.transform.parent = GameObject.Find("MapGrid").transform;
						MapBuilder.tiles.Add((trans.position.x).ToString()+","+(trans.position.y).ToString()+","+(trans.position.z-5).ToString(), temp);
					
					}
					//tile to right
					if(!MapBuilder.tiles.ContainsKey((trans.position.x+5).ToString()+","+(trans.position.y).ToString()+","+(trans.position.z).ToString())){
						temp = Instantiate(newSpot,new Vector3(trans.position.x +5, trans.position.y, trans.position.z), prefab.transform.rotation)as GameObject; 
						temp.name = (trans.position.x+5).ToString()+","+(trans.position.y).ToString()+","+(trans.position.z).ToString();
						temp.transform.parent = GameObject.Find("MapGrid").transform;
						MapBuilder.tiles.Add((trans.position.x+5).ToString()+","+(trans.position.y).ToString()+","+(trans.position.z).ToString(), temp);
					
					}
					//tile to top
					if(!MapBuilder.tiles.ContainsKey((trans.position.x).ToString()+","+(trans.position.y).ToString()+","+(trans.position.z+5).ToString())){
						temp = Instantiate(newSpot,new Vector3(trans.position.x, trans.position.y, trans.position.z+5), prefab.transform.rotation)as GameObject; 
						temp.name = (trans.position.x).ToString()+","+(trans.position.y).ToString()+","+(trans.position.z+5).ToString();
						temp.transform.parent = GameObject.Find("MapGrid").transform;
						MapBuilder.tiles.Add((trans.position.x).ToString()+","+(trans.position.y).ToString()+","+(trans.position.z+5).ToString(), temp);

					}
				}
				else if(prefab.name == "Bottom Right Tile"){
					if(!MapBuilder.tiles.ContainsKey((trans.position.x).ToString()+","+(trans.position.y).ToString()+","+(trans.position.z+5).ToString())){
						temp = Instantiate(newSpot,new Vector3(trans.position.x, trans.position.y, trans.position.z+5), prefab.transform.rotation)as GameObject; 
						temp.name = (trans.position.x).ToString()+","+(trans.position.y).ToString()+","+(trans.position.z+5).ToString();
						temp.transform.parent = GameObject.Find("MapGrid").transform;
						MapBuilder.tiles.Add((trans.position.x).ToString()+","+(trans.position.y).ToString()+","+(trans.position.z+5).ToString(), temp);
						
					}

					if(!MapBuilder.tiles.ContainsKey((trans.position.x-5).ToString()+","+trans.position.y.ToString()+","+trans.position.z.ToString())){
						temp = Instantiate(newSpot,new Vector3(trans.position.x -5, trans.position.y, trans.position.z), prefab.transform.rotation)as GameObject; 
						temp.name = (trans.position.x-5).ToString()+","+trans.position.y.ToString()+","+trans.position.z.ToString();
						temp.transform.parent = GameObject.Find("MapGrid").transform;
						MapBuilder.tiles.Add((trans.position.x-5).ToString()+","+trans.position.y.ToString()+","+trans.position.z.ToString(), temp);
						
					}
				}
				else if(prefab.name == "Bottom Left Tile"){
					if(!MapBuilder.tiles.ContainsKey((trans.position.x).ToString()+","+(trans.position.y).ToString()+","+(trans.position.z+5).ToString())){
						temp = Instantiate(newSpot,new Vector3(trans.position.x, trans.position.y, trans.position.z+5), prefab.transform.rotation)as GameObject; 
						temp.name = (trans.position.x).ToString()+","+(trans.position.y).ToString()+","+(trans.position.z+5).ToString();
						temp.transform.parent = GameObject.Find("MapGrid").transform;
						MapBuilder.tiles.Add((trans.position.x).ToString()+","+(trans.position.y).ToString()+","+(trans.position.z+5).ToString(), temp);
						
					}
					if(!MapBuilder.tiles.ContainsKey((trans.position.x+5).ToString()+","+(trans.position.y).ToString()+","+(trans.position.z).ToString())){
						temp = Instantiate(newSpot,new Vector3(trans.position.x +5, trans.position.y, trans.position.z), prefab.transform.rotation)as GameObject; 
						temp.name = (trans.position.x+5).ToString()+","+(trans.position.y).ToString()+","+(trans.position.z).ToString();
						temp.transform.parent = GameObject.Find("MapGrid").transform;
						MapBuilder.tiles.Add((trans.position.x+5).ToString()+","+(trans.position.y).ToString()+","+(trans.position.z).ToString(), temp);
						
					}
				}
				else if(prefab.name == "Top Left Tile"){

					if(!MapBuilder.tiles.ContainsKey((trans.position.x+5).ToString()+","+(trans.position.y).ToString()+","+(trans.position.z).ToString())){
						temp = Instantiate(newSpot,new Vector3(trans.position.x +5, trans.position.y, trans.position.z), prefab.transform.rotation)as GameObject; 
						temp.name = (trans.position.x+5).ToString()+","+(trans.position.y).ToString()+","+(trans.position.z).ToString();
						temp.transform.parent = GameObject.Find("MapGrid").transform;
						MapBuilder.tiles.Add((trans.position.x+5).ToString()+","+(trans.position.y).ToString()+","+(trans.position.z).ToString(), temp);
						
					}
					if(!MapBuilder.tiles.ContainsKey((trans.position.x).ToString()+","+(trans.position.y).ToString()+","+(trans.position.z-5).ToString())){
						temp = Instantiate(newSpot,new Vector3(trans.position.x, trans.position.y, trans.position.z-5), prefab.transform.rotation)as GameObject; 
						temp.name = (trans.position.x).ToString()+","+(trans.position.y).ToString()+","+(trans.position.z-5).ToString();
						temp.transform.parent = GameObject.Find("MapGrid").transform;
						MapBuilder.tiles.Add((trans.position.x).ToString()+","+(trans.position.y).ToString()+","+(trans.position.z-5).ToString(), temp);
						
					}
				}
				else if(prefab.name == "Top Right Tile"){
					
					if(!MapBuilder.tiles.ContainsKey((trans.position.x-5).ToString()+","+trans.position.y.ToString()+","+trans.position.z.ToString())){
						temp = Instantiate(newSpot,new Vector3(trans.position.x -5, trans.position.y, trans.position.z), prefab.transform.rotation)as GameObject; 
						temp.name = (trans.position.x-5).ToString()+","+trans.position.y.ToString()+","+trans.position.z.ToString();
						temp.transform.parent = GameObject.Find("MapGrid").transform;
						MapBuilder.tiles.Add((trans.position.x-5).ToString()+","+trans.position.y.ToString()+","+trans.position.z.ToString(), temp);
						
					}
					if(!MapBuilder.tiles.ContainsKey((trans.position.x).ToString()+","+(trans.position.y).ToString()+","+(trans.position.z-5).ToString())){
						temp = Instantiate(newSpot,new Vector3(trans.position.x, trans.position.y, trans.position.z-5), prefab.transform.rotation)as GameObject; 
						temp.name = (trans.position.x).ToString()+","+(trans.position.y).ToString()+","+(trans.position.z-5).ToString();
						temp.transform.parent = GameObject.Find("MapGrid").transform;
						MapBuilder.tiles.Add((trans.position.x).ToString()+","+(trans.position.y).ToString()+","+(trans.position.z-5).ToString(), temp);
						
					}
				}
				else if(prefab.name == "Top Tile"){
					
					if(!MapBuilder.tiles.ContainsKey((trans.position.x-5).ToString()+","+trans.position.y.ToString()+","+trans.position.z.ToString())){
						temp = Instantiate(newSpot,new Vector3(trans.position.x -5, trans.position.y, trans.position.z), prefab.transform.rotation)as GameObject; 
						temp.name = (trans.position.x-5).ToString()+","+trans.position.y.ToString()+","+trans.position.z.ToString();
						temp.transform.parent = GameObject.Find("MapGrid").transform;
						MapBuilder.tiles.Add((trans.position.x-5).ToString()+","+trans.position.y.ToString()+","+trans.position.z.ToString(), temp);
						
					}
					
					if(!MapBuilder.tiles.ContainsKey((trans.position.x).ToString()+","+(trans.position.y).ToString()+","+(trans.position.z-5).ToString())){
						temp = Instantiate(newSpot,new Vector3(trans.position.x, trans.position.y, trans.position.z-5), prefab.transform.rotation)as GameObject; 
						temp.name = (trans.position.x).ToString()+","+(trans.position.y).ToString()+","+(trans.position.z-5).ToString();
						temp.transform.parent = GameObject.Find("MapGrid").transform;
						MapBuilder.tiles.Add((trans.position.x).ToString()+","+(trans.position.y).ToString()+","+(trans.position.z-5).ToString(), temp);
						
					}
					if(!MapBuilder.tiles.ContainsKey((trans.position.x+5).ToString()+","+(trans.position.y).ToString()+","+(trans.position.z).ToString())){
						temp = Instantiate(newSpot,new Vector3(trans.position.x +5, trans.position.y, trans.position.z), prefab.transform.rotation)as GameObject; 
						temp.name = (trans.position.x+5).ToString()+","+(trans.position.y).ToString()+","+(trans.position.z).ToString();
						temp.transform.parent = GameObject.Find("MapGrid").transform;
						MapBuilder.tiles.Add((trans.position.x+5).ToString()+","+(trans.position.y).ToString()+","+(trans.position.z).ToString(), temp);
						
					}
				}
				else if(prefab.name == "Right Tile"){
					
					if(!MapBuilder.tiles.ContainsKey((trans.position.x-5).ToString()+","+trans.position.y.ToString()+","+trans.position.z.ToString())){
						temp = Instantiate(newSpot,new Vector3(trans.position.x -5, trans.position.y, trans.position.z), prefab.transform.rotation)as GameObject; 
						temp.name = (trans.position.x-5).ToString()+","+trans.position.y.ToString()+","+trans.position.z.ToString();
						temp.transform.parent = GameObject.Find("MapGrid").transform;
						MapBuilder.tiles.Add((trans.position.x-5).ToString()+","+trans.position.y.ToString()+","+trans.position.z.ToString(), temp);
						
					}
					
					if(!MapBuilder.tiles.ContainsKey((trans.position.x).ToString()+","+(trans.position.y).ToString()+","+(trans.position.z-5).ToString())){
						temp = Instantiate(newSpot,new Vector3(trans.position.x, trans.position.y, trans.position.z-5), prefab.transform.rotation)as GameObject; 
						temp.name = (trans.position.x).ToString()+","+(trans.position.y).ToString()+","+(trans.position.z-5).ToString();
						temp.transform.parent = GameObject.Find("MapGrid").transform;
						MapBuilder.tiles.Add((trans.position.x).ToString()+","+(trans.position.y).ToString()+","+(trans.position.z-5).ToString(), temp);
						
					}
					if(!MapBuilder.tiles.ContainsKey((trans.position.x).ToString()+","+(trans.position.y).ToString()+","+(trans.position.z+5).ToString())){
						temp = Instantiate(newSpot,new Vector3(trans.position.x, trans.position.y, trans.position.z+5), prefab.transform.rotation)as GameObject; 
						temp.name = (trans.position.x).ToString()+","+(trans.position.y).ToString()+","+(trans.position.z+5).ToString();
						temp.transform.parent = GameObject.Find("MapGrid").transform;
						MapBuilder.tiles.Add((trans.position.x).ToString()+","+(trans.position.y).ToString()+","+(trans.position.z+5).ToString(), temp);
						
					}
				}
				else if(prefab.name == "Bottom Tile"){
					
					if(!MapBuilder.tiles.ContainsKey((trans.position.x-5).ToString()+","+trans.position.y.ToString()+","+trans.position.z.ToString())){
						temp = Instantiate(newSpot,new Vector3(trans.position.x -5, trans.position.y, trans.position.z), prefab.transform.rotation)as GameObject; 
						temp.name = (trans.position.x-5).ToString()+","+trans.position.y.ToString()+","+trans.position.z.ToString();
						temp.transform.parent = GameObject.Find("MapGrid").transform;
						MapBuilder.tiles.Add((trans.position.x-5).ToString()+","+trans.position.y.ToString()+","+trans.position.z.ToString(), temp);
						
					}
					if(!MapBuilder.tiles.ContainsKey((trans.position.x+5).ToString()+","+(trans.position.y).ToString()+","+(trans.position.z).ToString())){
						temp = Instantiate(newSpot,new Vector3(trans.position.x +5, trans.position.y, trans.position.z), prefab.transform.rotation)as GameObject; 
						temp.name = (trans.position.x+5).ToString()+","+(trans.position.y).ToString()+","+(trans.position.z).ToString();
						temp.transform.parent = GameObject.Find("MapGrid").transform;
						MapBuilder.tiles.Add((trans.position.x+5).ToString()+","+(trans.position.y).ToString()+","+(trans.position.z).ToString(), temp);
						
					}
					if(!MapBuilder.tiles.ContainsKey((trans.position.x).ToString()+","+(trans.position.y).ToString()+","+(trans.position.z+5).ToString())){
						temp = Instantiate(newSpot,new Vector3(trans.position.x, trans.position.y, trans.position.z+5), prefab.transform.rotation)as GameObject; 
						temp.name = (trans.position.x).ToString()+","+(trans.position.y).ToString()+","+(trans.position.z+5).ToString();
						temp.transform.parent = GameObject.Find("MapGrid").transform;
						MapBuilder.tiles.Add((trans.position.x).ToString()+","+(trans.position.y).ToString()+","+(trans.position.z+5).ToString(), temp);
						
					}
				}
				else if(prefab.name == "Left Tile"){

					if(!MapBuilder.tiles.ContainsKey((trans.position.x).ToString()+","+(trans.position.y).ToString()+","+(trans.position.z-5).ToString())){
						temp = Instantiate(newSpot,new Vector3(trans.position.x, trans.position.y, trans.position.z-5), prefab.transform.rotation)as GameObject; 
						temp.name = (trans.position.x).ToString()+","+(trans.position.y).ToString()+","+(trans.position.z-5).ToString();
						temp.transform.parent = GameObject.Find("MapGrid").transform;
						MapBuilder.tiles.Add((trans.position.x).ToString()+","+(trans.position.y).ToString()+","+(trans.position.z-5).ToString(), temp);
						
					}
					if(!MapBuilder.tiles.ContainsKey((trans.position.x+5).ToString()+","+(trans.position.y).ToString()+","+(trans.position.z).ToString())){
						temp = Instantiate(newSpot,new Vector3(trans.position.x +5, trans.position.y, trans.position.z), prefab.transform.rotation)as GameObject; 
						temp.name = (trans.position.x+5).ToString()+","+(trans.position.y).ToString()+","+(trans.position.z).ToString();
						temp.transform.parent = GameObject.Find("MapGrid").transform;
						MapBuilder.tiles.Add((trans.position.x+5).ToString()+","+(trans.position.y).ToString()+","+(trans.position.z).ToString(), temp);
						
					}
					if(!MapBuilder.tiles.ContainsKey((trans.position.x).ToString()+","+(trans.position.y).ToString()+","+(trans.position.z+5).ToString())){
						temp = Instantiate(newSpot,new Vector3(trans.position.x, trans.position.y, trans.position.z+5), prefab.transform.rotation)as GameObject; 
						temp.name = (trans.position.x).ToString()+","+(trans.position.y).ToString()+","+(trans.position.z+5).ToString();
						temp.transform.parent = GameObject.Find("MapGrid").transform;
						MapBuilder.tiles.Add((trans.position.x).ToString()+","+(trans.position.y).ToString()+","+(trans.position.z+5).ToString(), temp);
						
					}
				}
				else if(prefab.name == "Bottom Hall End Tile"){

					if(!MapBuilder.tiles.ContainsKey((trans.position.x).ToString()+","+(trans.position.y).ToString()+","+(trans.position.z+5).ToString())){
						temp = Instantiate(newSpot,new Vector3(trans.position.x, trans.position.y, trans.position.z+5), prefab.transform.rotation)as GameObject; 
						temp.name = (trans.position.x).ToString()+","+(trans.position.y).ToString()+","+(trans.position.z+5).ToString();
						temp.transform.parent = GameObject.Find("MapGrid").transform;
						MapBuilder.tiles.Add((trans.position.x).ToString()+","+(trans.position.y).ToString()+","+(trans.position.z+5).ToString(), temp);
						
					}
				}
				if(prefab.name == "Bottom Right Angle Tile"){
					//Tile to left
					if(!MapBuilder.tiles.ContainsKey((trans.position.x-5).ToString()+","+trans.position.y.ToString()+","+trans.position.z.ToString())){
						temp = Instantiate(newSpot,new Vector3(trans.position.x -5, trans.position.y, trans.position.z), prefab.transform.rotation)as GameObject; 
						temp.name = (trans.position.x-5).ToString()+","+trans.position.y.ToString()+","+trans.position.z.ToString();
						temp.transform.parent = GameObject.Find("MapGrid").transform;
						MapBuilder.tiles.Add((trans.position.x-5).ToString()+","+trans.position.y.ToString()+","+trans.position.z.ToString(), temp);
						
					}

					//tile to top
					if(!MapBuilder.tiles.ContainsKey((trans.position.x).ToString()+","+(trans.position.y).ToString()+","+(trans.position.z+5).ToString())){
						temp = Instantiate(newSpot,new Vector3(trans.position.x, trans.position.y, trans.position.z+5), prefab.transform.rotation)as GameObject; 
						temp.name = (trans.position.x).ToString()+","+(trans.position.y).ToString()+","+(trans.position.z+5).ToString();
						temp.transform.parent = GameObject.Find("MapGrid").transform;
						MapBuilder.tiles.Add((trans.position.x).ToString()+","+(trans.position.y).ToString()+","+(trans.position.z+5).ToString(), temp);
						
					}
				}
				if(prefab.name == "Horizontal Hall"){
					//Tile to left
					if(!MapBuilder.tiles.ContainsKey((trans.position.x-5).ToString()+","+trans.position.y.ToString()+","+trans.position.z.ToString())){
						temp = Instantiate(newSpot,new Vector3(trans.position.x -5, trans.position.y, trans.position.z), prefab.transform.rotation)as GameObject; 
						temp.name = (trans.position.x-5).ToString()+","+trans.position.y.ToString()+","+trans.position.z.ToString();
						temp.transform.parent = GameObject.Find("MapGrid").transform;
						MapBuilder.tiles.Add((trans.position.x-5).ToString()+","+trans.position.y.ToString()+","+trans.position.z.ToString(), temp);
						
					}

					//tile to right
					if(!MapBuilder.tiles.ContainsKey((trans.position.x+5).ToString()+","+(trans.position.y).ToString()+","+(trans.position.z).ToString())){
						temp = Instantiate(newSpot,new Vector3(trans.position.x +5, trans.position.y, trans.position.z), prefab.transform.rotation)as GameObject; 
						temp.name = (trans.position.x+5).ToString()+","+(trans.position.y).ToString()+","+(trans.position.z).ToString();
						temp.transform.parent = GameObject.Find("MapGrid").transform;
						MapBuilder.tiles.Add((trans.position.x+5).ToString()+","+(trans.position.y).ToString()+","+(trans.position.z).ToString(), temp);
						
					}

				}
				if(prefab.name == "Top Hall End Tile"){

					// tile to bottom
					if(!MapBuilder.tiles.ContainsKey((trans.position.x).ToString()+","+(trans.position.y).ToString()+","+(trans.position.z-5).ToString())){
						temp = Instantiate(newSpot,new Vector3(trans.position.x, trans.position.y, trans.position.z-5), prefab.transform.rotation)as GameObject; 
						temp.name = (trans.position.x).ToString()+","+(trans.position.y).ToString()+","+(trans.position.z-5).ToString();
						temp.transform.parent = GameObject.Find("MapGrid").transform;
						MapBuilder.tiles.Add((trans.position.x).ToString()+","+(trans.position.y).ToString()+","+(trans.position.z-5).ToString(), temp);
						
					}
				}
				if(prefab.name == "Right Hall End Tile"){
					//Tile to left
					if(!MapBuilder.tiles.ContainsKey((trans.position.x-5).ToString()+","+trans.position.y.ToString()+","+trans.position.z.ToString())){
						temp = Instantiate(newSpot,new Vector3(trans.position.x -5, trans.position.y, trans.position.z), prefab.transform.rotation)as GameObject; 
						temp.name = (trans.position.x-5).ToString()+","+trans.position.y.ToString()+","+trans.position.z.ToString();
						temp.transform.parent = GameObject.Find("MapGrid").transform;
						MapBuilder.tiles.Add((trans.position.x-5).ToString()+","+trans.position.y.ToString()+","+trans.position.z.ToString(), temp);
						
					}
				}
				if(prefab.name == "Left Hall End Tile"){

					//tile to right
					if(!MapBuilder.tiles.ContainsKey((trans.position.x+5).ToString()+","+(trans.position.y).ToString()+","+(trans.position.z).ToString())){
						temp = Instantiate(newSpot,new Vector3(trans.position.x +5, trans.position.y, trans.position.z), prefab.transform.rotation)as GameObject; 
						temp.name = (trans.position.x+5).ToString()+","+(trans.position.y).ToString()+","+(trans.position.z).ToString();
						temp.transform.parent = GameObject.Find("MapGrid").transform;
						MapBuilder.tiles.Add((trans.position.x+5).ToString()+","+(trans.position.y).ToString()+","+(trans.position.z).ToString(), temp);
						
					}

				}
				if(prefab.name == "Vertical Hall"){

					// tile to bottom
					if(!MapBuilder.tiles.ContainsKey((trans.position.x).ToString()+","+(trans.position.y).ToString()+","+(trans.position.z-5).ToString())){
						temp = Instantiate(newSpot,new Vector3(trans.position.x, trans.position.y, trans.position.z-5), prefab.transform.rotation)as GameObject; 
						temp.name = (trans.position.x).ToString()+","+(trans.position.y).ToString()+","+(trans.position.z-5).ToString();
						temp.transform.parent = GameObject.Find("MapGrid").transform;
						MapBuilder.tiles.Add((trans.position.x).ToString()+","+(trans.position.y).ToString()+","+(trans.position.z-5).ToString(), temp);
						
					}

					//tile to top
					if(!MapBuilder.tiles.ContainsKey((trans.position.x).ToString()+","+(trans.position.y).ToString()+","+(trans.position.z+5).ToString())){
						temp = Instantiate(newSpot,new Vector3(trans.position.x, trans.position.y, trans.position.z+5), prefab.transform.rotation)as GameObject; 
						temp.name = (trans.position.x).ToString()+","+(trans.position.y).ToString()+","+(trans.position.z+5).ToString();
						temp.transform.parent = GameObject.Find("MapGrid").transform;
						MapBuilder.tiles.Add((trans.position.x).ToString()+","+(trans.position.y).ToString()+","+(trans.position.z+5).ToString(), temp);
						
					}
				}
				else {

				}
				NGUITools.Destroy(gameObject);
				return;
			}
		}
		base.OnDragDropRelease(surface);

	}
}
