using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
[AddComponentMenu("Layout/Auto Grid Layout Group", 152)] //add components for spacing and padding

public class NewCustomLayoutBlue : GridLayoutGroup
{

    [SerializeField]
    private bool ColumnsSelected; //used if selecting column or row for set size, bool value checked by checkerbox
    [SerializeField]
    private int m_Column = 1, m_Row = 1; //number of columns/rows, whichever is selected

    public override void CalculateLayoutInputHorizontal()
    {
        base.CalculateLayoutInputHorizontal();
        float iColumn = -1;
        float iRow = -1;
        if (ColumnsSelected)
        {
            iColumn = m_Column; //number of columns is inputted 
            iRow = Mathf.CeilToInt(this.transform.childCount / iColumn);//number of rows is caculated w/ -> #tiles/#columns
        }
        else
        {
            iRow = m_Row; //number of rows is inputted 
            iColumn = Mathf.CeilToInt(this.transform.childCount / iRow); //number of columns is calculated w/ -> #tiles/#rows
        }
        //float fHeight = (rectTransform.rect.height - ((iRow - 1) * (spacing.y))) - ((padding.top + padding.bottom));
        float fWidth = (rectTransform.rect.width - ((iColumn - 1) * (spacing.x))) - ((padding.right + padding.left));
        float fHeight = (rectTransform.rect.height - ((iRow - 1) * (spacing.y))) - ((padding.top + padding.bottom));
         fHeight = fWidth * 8 /7;
        //  Vector2 vSize = new Vector2(fWidth / iColumn, (fHeight) / iRow);
        Vector2 vSize = new Vector2(fWidth / iColumn, fWidth / iColumn);
        cellSize = vSize;
    }
}
