using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Board : MonoBehaviour {
	
	public Cell CellPrefab;
	public GameObject PawnPrefab;

	public List<Cell> Cells;
	public Material blackMaterial;
	public Material whiteMaterial;

	public void generate() {

		Cells = new List<Cell> ();

		for(int x = 0; x < 8; x++) {
			
			for(int y = 0; y < 8; y++) {
				
				Cells.Add( createCell (x, y, (x + y) % 2) );
				
			}
			
		}

	}

	Cell createCell(int posx, int posy, int type) {
		Cell newCell = Instantiate (CellPrefab) as Cell;

		if (type == 0) {
			newCell.GetComponent<Renderer> ().material = blackMaterial;
		} else {
			newCell.GetComponent<Renderer> ().material = whiteMaterial;
		}

		newCell.x = posx;
		newCell.y = posy;

		newCell.transform.localPosition = new Vector3 (posx , posy, 0);

		newCell.name = "Board cell [" + posx + "," + posy + "]";
		
		return newCell;
	}

	public void populate() {

		foreach (Cell cellInstance in Cells) {
			cellInstance.occupied = true;

			GameObject newPawn = Instantiate (PawnPrefab) as GameObject;

			newPawn.transform.localPosition = new Vector3(cellInstance.transform.position.x, cellInstance.transform.position.y, -2);

		}
	}

}
