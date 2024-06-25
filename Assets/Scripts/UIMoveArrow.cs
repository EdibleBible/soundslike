using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static SpoderTrail;

public class UIMoveArrow : MonoBehaviour
{
    private Image imageComponent;
    public SpoderTrail trailScript;
    public int movementEndIndex;

    private void Start()
    {
        imageComponent = GetComponent<Image>();
    }

    private void OnEnable()
    {
        trailScript.UpdateMoveSprite += UpdateSprite;
    }

    private void OnDisable()
    {
        trailScript.UpdateMoveSprite -= UpdateSprite;
    }

    private void UpdateSprite(List<MoveType> moves)
    {
        int movesCount = moves.Count;
        if (movesCount >= movementEndIndex)
        {
            imageComponent.sprite = trailScript.moveSpriteImages[(int)moves[movesCount - movementEndIndex]];
        }
    }
}
