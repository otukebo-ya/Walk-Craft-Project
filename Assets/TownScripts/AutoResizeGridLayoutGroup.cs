using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(GridLayoutGroup))]
public class AutoResizeGridLayoutGroup : GridLayoutGroup
{
    protected AutoResizeGridLayoutGroup() { }

    private void resizeCellSize()
    {
        float gridWidth = rectTransform.rect.width;
        float newCellSize = (gridWidth - (spacing.x * (constraintCount - 1))) / constraintCount;

        Vector2 newSize = new Vector2(newCellSize, newCellSize);
        cellSize = newSize;
    }

    public override void CalculateLayoutInputVertical()
    {
        resizeCellSize();
        base.CalculateLayoutInputVertical();
    }
}
