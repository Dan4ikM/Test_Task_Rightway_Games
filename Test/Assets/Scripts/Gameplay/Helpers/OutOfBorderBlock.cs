using UnityEngine;
using System.Collections;
using Gameplay.Helpers;

public class OutOfBorderBlock : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer _representation;

    void LateUpdate()
    {
        GameAreaHelper.BlockInGameplayArea(transform,_representation.bounds);
    }
}
