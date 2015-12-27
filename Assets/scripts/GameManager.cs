using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {
	
	public Board boardPrefab;

	public Text DebugText;

	private Board boardInstance;

	private int[,] grid;

	// Use this for initialization
	void Start () {

		grid = new int[8,8];

		boardInstance = Instantiate (boardPrefab) as Board;
		boardInstance.transform.localPosition = new Vector3 (-3.5f, -3.5f, 0);

		boardInstance.generate ();

	}
	
	// Update is called once per frame
	void Update () {
		detectInput ();
	}
		
	void detectInput() {
		if (Input.GetMouseButtonDown(0)) {

			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

			if (Physics.Raycast(ray, out hit, 1000.000f)) {
				Cell hitCell = hit.collider.GetComponent<Cell> ();

				activateCell (hitCell.x, hitCell.y);

				updateDebugView ();

			}
		}
	}

	void activateCell(int x, int y) {
		grid [x, y] = 1;
	}

	string debugGameState() {
		string map = "";

		for (int x = 0; x < 8; x++) {

			map += x + ": ";

			for (int y = 0; y < 8; y++) {
				map += "[" + grid [x, y] + "]";
			}
			map += "\n";
		}

		return map;
	}

	void updateDebugView() {
		DebugText.text = debugGameState ();
		
	}
}
