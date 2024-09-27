using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tweening : MonoBehaviour
{
    public RectTransform imageRect;  // Reference to the image's RectTransform
    public float floatHeight = 20f;  // Height of the floating effect
    public float floatDuration = 2f;  // Duration of the float effect

    private void Start()
    {
        // Start the floating animation
        StartFloating();
    }

    private void StartFloating()
    {
        // Animate the image's Y position to move up and down repeatedly
        imageRect.DOAnchorPosY(imageRect.anchoredPosition.y + floatHeight, floatDuration)
            .SetEase(Ease.InOutSine)  // Smooth in-out effect
            .SetLoops(-1, LoopType.Yoyo);  // Infinite loop with yoyo effect
    }
}
