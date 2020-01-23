using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager1 : MonoBehaviour
{
    private Tile TileClass;
    private Colours ColorClass;
    public Tile[,] AllTilesArray = new Tile[4, 4]; // used to change values of the 4x4 array of each tile
    public int[,] ValuesArray = new int[4, 4]; // used to calculate values for the 4x4 array
    List<string> EmptyValuesList = new List<string>();
    public System.Random RandomValue = new System.Random();
    public int ABlockMoved;
    private Text GameOverTxt;
    private Text GameOverTxt2;


    private void Awake()
    {
        TileClass = GameObject.FindObjectOfType<Tile>();
        GameOverTxt = GameObject.Find("GameOverText").GetComponent<Text>();
        GameOverTxt2 = GameObject.Find("PressRetryText").GetComponent<Text>();

    }
    void Start()
    {
        Tile[] AllTilesOneDim = GameObject.FindObjectsOfType<Tile>(); // just used to store the tiles to make the 2d array
    
        foreach (Tile t in AllTilesOneDim)
        {
            t.SettingValue(0);
            AllTilesArray[t.RowIndex, t.ColumnIndex] = t; // adds tile to tilearray according to its row and column set in inspector
                                                           // now we can easily call on tiles accurately, all of them are sorted in a array
        }
       GenerateNewBlock();
       GenerateNewBlock();

    }

    public void RetryClick()
    {
        foreach (Tile t in AllTilesArray)
        {
            t.SettingValue(0);
        }
        Array.Clear(ValuesArray, 0, ValuesArray.Length);
        GenerateNewBlock();
        GenerateNewBlock();

    }

    public void MoveListener(string move)
    {
        Debug.Log(move + " movement");
    }

    public void GenerateNewBlock()
    {
        int GeneratedValue, PercentChanceBlock;
        PercentChanceBlock = RandomValue.Next(0, 11); // Generates a random value between 0 and 11 
        
        if (PercentChanceBlock < 10)
        {
            GeneratedValue = 2;
        }
        else
        {
            GeneratedValue = 4;
        }

        EmptyValuesList.Clear();
        for (int column = 0; column < 4; column++)
        {
            for (int row = 0; row < 4; row++)
            {
                if (ValuesArray[row,column] == 0)
                {
                    EmptyValuesList.Add("" + row + column);
                }
            }
        }

        if (EmptyValuesList.Count > 0)
        {
            int ChosenBlock = RandomValue.Next(EmptyValuesList.Count);
            int row = int.Parse(EmptyValuesList[ChosenBlock]) / 10;
            int column = int.Parse(EmptyValuesList[ChosenBlock]) - 10 * row;
            ValuesArray[row,column] = GeneratedValue;
            AllTilesArray[row, column].SettingValue(GeneratedValue);
        }
    }

    public void UpwardMovement()
    {
        ABlockMoved = 0;
        for (int column = 0; column < 4; column++)
        {
            for (int row = 0; row < 3; row++)
            {
                if (ValuesArray[row,column] == 0)
                {  // Situation 1: Viewing block is empty
                    for (int z = row + 1; z < 4; z++)
                    {
                        if (ValuesArray[z,column] != 0)
                        { // Find first box beneth it thats not empty
                            ValuesArray[row,column] = ValuesArray[z,column]; //move it to the top
                            ValuesArray[z,column] = 0; // set that value equal to 0 
                            AllTilesArray[row, column].SettingValue(ValuesArray[row, column]); //changing display
                            AllTilesArray[z, column].SettingValue(ValuesArray[z, column]); //changing display
                            ABlockMoved++;
                            row--; //recheck the row for merging 
                            break;
                        }
                    }
                }
                else
                {
                    for (int z = row + 1; z < 4; z++)
                    { // Sitation 2: Viewing block is not empty
                        if (ValuesArray[z,column] != 0)
                        {
                            if (ValuesArray[z,column] == ValuesArray[row,column])
                            {
                                ValuesArray[z,column] = 0;
                                ValuesArray[row,column] *= 2;
                                AllTilesArray[row, column].SettingValue(ValuesArray[row, column]); //changing display
                                AllTilesArray[z, column].SettingValue(ValuesArray[z, column]);
                                ABlockMoved++;
                            }
                            break;
                        }
                    }

                }
            }
        }
        if (ABlockMoved > 0)
        {
            GenerateNewBlock();
        }
        else
        {
            CheckForGameover();
        }
    }
    public void DownwardMovement()
    {
        ABlockMoved =0;
        for (int column = 0; column < 4; column++) { // Go through four columns
            for (int row = 3; row > 0; row--) { // Go down the rows/through column values
                if (ValuesArray[row,column] == 0) { // first value in column is 0;
                    for (int z = row - 1; z > -1; z--) {
                        if (ValuesArray[z,column] != 0) { //finds first real value in column
                            ValuesArray[row,column] = ValuesArray[z,column];
                            ValuesArray[z,column] = 0;
                            AllTilesArray[row,column].SettingValue(ValuesArray[row, column]);
                            AllTilesArray[z, column].SettingValue(ValuesArray[z, column]);
                            ABlockMoved++;
                            row++;
                            break;
                        }
                      //  if (z==0){ row=-1;// empty box with no more values under, look at next column }
                    }
                } else {
                    for (int z = row - 1; z > -1; z--) {
                        if (ValuesArray[z,column] != 0) {
                            if (ValuesArray[z,column] == ValuesArray[row,column]) {
                                ValuesArray[z,column] = 0;
                                ValuesArray[row,column] *= 2;
                                AllTilesArray[row, column].SettingValue(ValuesArray[row, column]);
                                AllTilesArray[z, column].SettingValue(ValuesArray[z, column]);
                                ABlockMoved++;
                            }
                            break;
                        }
                    }

                }
            }
        }
        if (ABlockMoved >0){
            GenerateNewBlock();
        }
        else
        {
            CheckForGameover();
        }
    }
    public void LeftMovement()
    {
        ABlockMoved = 0;
        for (int row = 0; row < 4; row++)
        {
            for (int column = 0; column < 3; column++)
            {
                if (ValuesArray[row,column] == 0)
                {
                    for (int z = column + 1; z < 4; z++)
                    {
                        if (ValuesArray[row,z] != 0)
                        {
                            ValuesArray[row,column] = ValuesArray[row,z];
                            ValuesArray[row,z] = 0;
                            AllTilesArray[row, column].SettingValue(ValuesArray[row, column]);
                            AllTilesArray[row, z].SettingValue(ValuesArray[row, z]);
                            column--;
                            ABlockMoved++;
                            break;
                        }

                    }
                }
                else
                {
                    for (int z = column + 1; z < 4; z++)
                    {
                        if (ValuesArray[row,z] != 0)
                        {
                            if (ValuesArray[row,z] == ValuesArray[row,column])
                            {
                                ValuesArray[row,z] = 0;
                                ValuesArray[row,column] *= 2;
                                AllTilesArray[row, column].SettingValue(ValuesArray[row, column]);
                                AllTilesArray[row, z].SettingValue(ValuesArray[row, z]);
                                ABlockMoved++;
                            }
                            break;
                        }
                    }

                }
            }
        }
        if (ABlockMoved > 0)
        {
            GenerateNewBlock();
        }
        else
        {
            CheckForGameover();
        }
    }
    public void RightMovement()
    {
        ABlockMoved = 0;
        for (int row = 0; row < 4; row++)
        {
            for (int column = 3; column > 0; column--)
            {
                if (ValuesArray[row,column] == 0)
                {
                    for (int z = column - 1; z > -1; z--)
                    {
                        if (ValuesArray[row,z] != 0)
                        {
                            ValuesArray[row,column] = ValuesArray[row,z];
                            ValuesArray[row,z] = 0;
                            AllTilesArray[row, column].SettingValue(ValuesArray[row, column]);
                            AllTilesArray[row, z].SettingValue(ValuesArray[row, z]);
                            column++;
                            ABlockMoved++;
                            break;
                        }
                    }
                }
                else
                {
                    for (int z = column - 1; z > -1; z--)
                    {
                        if (ValuesArray[row,z] != 0)
                        {
                            if (ValuesArray[row,z] == ValuesArray[row,column])
                            {
                                ValuesArray[row,z] = 0;
                                ValuesArray[row,column] *= 2;
                                AllTilesArray[row, column].SettingValue(ValuesArray[row, column]);
                                AllTilesArray[row, z].SettingValue(ValuesArray[row, z]);
                                ABlockMoved++;
                            }
                            break;
                        }
                    }

                }
            }
        }
        if (ABlockMoved > 0)
        {
            GenerateNewBlock();
        }
        else
        {
            CheckForGameover();
        }
    }
    public void CheckForGameover()
    {
        int notgameover = 0;

        for (int row = 0; row < 4; row++)
        {
            for (int column =0; column < 4; column++)
            {
                if (row == 3 && column == 3)
                {
                    DisplayGameOver();
                }
                else if (row == 3)
                {
                    if (ValuesArray[row, column] == ValuesArray[row, column + 1])
                    {
                        notgameover = 1;
                        break;
                    }
                }
                else if (column == 3)
                {
                    if (ValuesArray[row, column] == ValuesArray[row + 1, column])
                    {
                        notgameover = 1;
                        break;
                    }
                }
                else
                {
                    if ((ValuesArray[row, column] == ValuesArray[row + 1, column]) || (ValuesArray[row, column] == ValuesArray[row, column + 1]))
                    {
                        notgameover = 1;
                        break;
                    }
                }
            }
            if (notgameover == 1)
            {
                break;
            }
        }

    }
    public void DisplayGameOver()
    {
     foreach(Tile t in AllTilesArray)
        {
            t.SettingValue(0);
        }
     // empty all the values.

        GameOverTxt.text = "Game Over";
        GameOverTxt2.text = "Press Retry to Play Again";
    }






}
