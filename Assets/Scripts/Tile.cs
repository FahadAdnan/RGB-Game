using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class Tile : MonoBehaviour
{

    public int ColumnIndex;
    public int RowIndex;


    // GetSet Method for setting values to each image.
    public void SettingValue(int number)
    {
        if (number == 0)
        {
            SetEmpty();
        }
        else
        {
            ApplyStyleFromHolder(number);
            SetVisible();
        }
    }


    private Text TileText;
    private Image TileImage;
    private Colours ColorClass;

    void Awake()
    {
       TileText = GetComponentInChildren<Text>();
        TileImage = transform.Find("NumberedPanel").GetComponent<Image>();
        ColorClass = GameObject.FindObjectOfType<Colours>();
    }

    void ApplyStyleFromHolder(int num)
    {
        int ArrayVal = (int)Mathf.Floor(Mathf.Log(num, 2)) -1;
        TileText.text = num.ToString();
        TileText.color = Color.black;
        Debug.Log("The value in the array list for: " + num + " is: " + ArrayVal);
        Debug.Log( " Color:" + Colours.Blue[ArrayVal ] + " Color2: " + Colours.Green[ArrayVal]);
        
        TileImage.color = new Color32(Colours.Red[ArrayVal], Colours.Green[ArrayVal], Colours.Blue[ArrayVal], 255);

    }

  



    private void SetVisible()
    {
        TileImage.enabled = true;
        TileText.enabled = true;
    }

    private void SetEmpty()
    {
        TileImage.enabled = false;
        TileText.enabled = false;
    }


}
