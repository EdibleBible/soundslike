using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMove0 : MonoBehaviour
{
    private Image imageComponent;
    public SpoderTrail trailScript;

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

    private void UpdateSprite(Sprite arrowSprite)
    {
        imageComponent.sprite = arrowSprite;
    }
}
