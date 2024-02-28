using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CellDissection : MonoBehaviour
{
    GameObject[][][] cells;
    public int cellLength = 5;

    int[][][] cellStatus;
    public Text text;
    string result = "";

    void Start() {
        cellStatus = new int[cellLength][][]; 
        cells = new GameObject[cellLength][][]; 
        for (int i = 0; i < cellLength; i++) {
            cellStatus[i] = new int[cellLength][]; 
            cells[i] = new GameObject[cellLength][]; 
            for (int j = 0; j < cellLength; j++) {
                cellStatus[i][j] = new int[cellLength]; 
                cells[i][j] = new GameObject[cellLength]; 
                for (int k = 0; k < cellLength; k++) {
                    cellStatus[i][j][k] = 0;
                }
            }
        }
    }

    void Update(){
        dissection();
        text.text = result;
    }

    // Initialize prefab cell in Resources folder
    public void CellsGenerate(){
        GameObject cellPrefab = Resources.Load("Cell") as GameObject;
        if(cellPrefab != null){
            for (int i = 0; i < cellLength; i++){
                for (int j = 0; j < cellLength; j++){
                    for (int k = 0; k < cellLength; k++){
                        cells[i][j][k] = Instantiate(cellPrefab, new Vector3(i - cellLength/2, j + 0.5f, k - cellLength/2), Quaternion.identity);
                        Debug.Log("Instantiate cell at " + i + " " + j + " " + k);
                    }
                }
            }
        }
    }
    public void dissection(){
        result = cellLength + "rows in total. \n";
        for (int i = 0; i < cellLength; i++){
            result += "Row " + i + ": ";
            for (int j = 0; j < cellLength; j++){
                if(j!=0)
                    result += "            ";
                    result += "|";
                for (int k = 0; k < cellLength; k++){
                    GameObject currentCell = cells[i][j][k];
                    if(currentCell != null){
                        Cell cellComponent = currentCell.GetComponent<Cell>();
                        if(cellComponent != null){
                            cellStatus[i][j][k] = cellComponent.isOverlap;
                            result += cellStatus[i][j][k].ToString() + " ";
                        }
                    }
                    else{
                        return;
                    }
                }
                result += "|";
                if(j==cellLength-1){
                    result += "\n";
                }
                else{
                    result += "\n";
                }                    
            }
        }
    }

}
