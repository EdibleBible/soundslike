using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static SO_Enums;

public class UIMoveArrow : MonoBehaviour
{
    private Image imageComponent;
    public int movementEndIndex;

    private void Start()
    {
        imageComponent = GetComponent<Image>();
    }

    private void OnEnable()
    {
        SO_Events.UpdateMoveSprite += UpdateSprite;
    }

    private void OnDisable()
    {
        SO_Events.UpdateMoveSprite -= UpdateSprite;
    }

    private void UpdateSprite(List<MoveType> moves, List<Sprite> sprites)
    {
        int movesCount = moves.Count;
        if (movesCount >= movementEndIndex)
        {
            imageComponent.sprite = sprites[(int)moves[movesCount - movementEndIndex]];
        } else
        {
            imageComponent.sprite = sprites[0];
        }
    }
}
