using UnityEngine;
using System.Collections;

public class Map : MonoBehaviour
{
	public TextAsset mapText;
	public GameObject p_nomalFloor;
	public GameObject p_nomalWall;

	void Start ()
	{
		int row = 0;
		int col = 0;
		const int chipSize = 16;

		string lineSeparater = System.Environment.NewLine; // 改行文字を取得
		string[] lines = mapText.text.Split (lineSeparater.ToCharArray (), System.StringSplitOptions.None);
		foreach (string line in lines) {
			foreach (char c in line) {
				// マップチップを読み込みチェックする
				GameObject chipObj = this.getChip (c);
				if (chipObj == null) {
					Debug.LogError ("Mapファイル内に想定外のな文字があります -> " + c);
					continue;
				}

				// マップチップを配置する
				chipObj.transform.position = new Vector2 (col * chipSize, -row * chipSize);
				chipObj.transform.parent = this.transform;
				col++;
			}
			// 1行出力し終えたら次の行へ
			row++;
			col = 0;
		}
	}

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
