using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static SO_Events;

public class UIPlayerHP : MonoBehaviour
{
    public Image image;
    public List<Sprite> hpSprites = new();

    private void OnEnable()
    {
        UpdateHPEvent += ChangeSprite;
    }

    private void OnDisable()
    {
        UpdateHPEvent -= ChangeSprite;
    }

    private void ChangeSprite(int hp)
    {
        image.sprite = hpSprites[hp];
    }
}
