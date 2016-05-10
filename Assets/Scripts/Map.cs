using UnityEngine;
using System.Collections;

public class Map : MonoBehaviour
{

	public TextAsset mapText;
	public GameObject p_nomalFloor;
	public GameObject p_nomalWall;

	// Use this for initialization
	void Start ()
	{
		int row = 0;
		int col = 0;
		const int chipSize = 16;
		foreach (char c in this.mapText.text) {

			// when nextline appear, then go to nextline
			if ((c == '\n') || (c == '\r')) {
				row ++;
				col = 0;
				continue;
			}

			// create new mapchip and check it
			GameObject chipObj = this.getChip (c);
			if (chipObj == null) {
				Debug.LogError ("There is a illegal character in map data!");
				continue;
			}

			// put mapchip into correct position
			chipObj.transform.position = new Vector2 (col * chipSize, -row * chipSize);
			chipObj.transform.parent = this.transform;
			col ++;
		}
	}
	
	// Update is called once per frame
	private GameObject getChip (char c)
	{
		GameObject chipObj = null;

		switch (c) {
		case ' ':
			chipObj = Instantiate (this.p_nomalFloor);
			break;
		case '#':
			chipObj = Instantiate (this.p_nomalWall);
			break;
		}

		return chipObj;
	}
}
