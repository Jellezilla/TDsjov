using UnityEngine;
using System.Collections;

public class Map : MonoBehaviour {
	
	private int gridSize = 1;
	private int x;
	private int y;
	
	public GameObject go;
	// Use this for initialization
	void Start () {
		x = Mathf.FloorToInt (transform.position.x/gridSize);
		y = Mathf.FloorToInt (transform.position.y/gridSize);	

		TextMesh tm = new TextMesh();
	}
	
	// Update is called once per frame
	void Update () {
		
		if(Input.GetKey (KeyCode.W))
		{
			go.transform.position = GridPosition((int)go.transform.position.x, (int)go.transform.position.z+1);
		
		}
		if(Input.GetKey (KeyCode.A))
		{
			go.transform.position = GridPosition((int)go.transform.position.x-1, (int)go.transform.position.z);
		
		}
		if(Input.GetKey (KeyCode.S))
		{
			go.transform.position = GridPosition((int)go.transform.position.x, (int)go.transform.position.z-1);
		
		}
		if(Input.GetKey (KeyCode.D))
		{
			go.transform.position = GridPosition((int)go.transform.position.x+1, (int)go.transform.position.z);
		
		}
		if(Input.GetKeyDown(KeyCode.R)) {
			Debug.Log (go.transform.position.ToString());
		}
	}
	
	
	public Vector3 GridPosition(int x, int y) 
	{
		return new Vector3(x*gridSize,0,y*gridSize);
	}
}






// to position something:

//var vector : Vector3 = new Vector3(x * gridSize, 0, y * gridSize);