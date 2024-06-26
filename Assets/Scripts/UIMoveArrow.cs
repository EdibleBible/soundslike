using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static SO_Enums;

public class UIMoveArrow : MonoBehaviour
{
    private Image imageComponent;
    public int movementEndIndex; //Which in order is this value from last in the move list supposed to be. Starts at 1

    private void Start()
    {
        imageComponent = GetComponent<Image>(); //Saves the Image component of this object to memory for later use
    }

    private void OnEnable() //Subscribes to the sprite update event
    {
        SO_Events.UpdateMoveSprite += UpdateSprite;
    }

    private void OnDisable() //Unsubscribes from the sprite update event
    {
        SO_Events.UpdateMoveSprite -= UpdateSprite;
    }

    private void UpdateSprite(List<MoveType> moves, List<Sprite> sprites)
    {
        int movesCount = moves.Count; //Gets the size of the list of moves
        if (movesCount >= movementEndIndex) //If the move list is not more than 4, this looks at whether to even show a sprite to prevent null references
        {
            imageComponent.sprite = sprites[(int)moves[movesCount - movementEndIndex]]; //Gets the sprite at the index matching the move (cast to int) it's supposed to be
        } else
        {
            imageComponent.sprite = sprites[0]; //Resets the sprite to default "No move"
        }
    }
}
