using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Crosshair : MonoBehaviour
{
    [SerializeField] private Image[] _images;

    [Header("RectTransforms")]
    [SerializeField] private RectTransform _leftRectTransform;
    [SerializeField] private RectTransform _rightRectTransform;
    [SerializeField] private RectTransform _upRectTransform;
    [SerializeField] private RectTransform _downRectTransform;

    [Header("Color")]
    [SerializeField] private Color _colorImages;

    [Header("Transparency")]
    [SerializeField] private float _transparencyImages;

    [Header("Size")]
    [SerializeField] private float _sizeImages;

    [Header("Scale")]
    [SerializeField] private float _scaleImages;

    [Header("Position")]
    [SerializeField] private float _positionImages;

    void Update()
    {
        //Temporary
        SetCrosshairColor();
        SetCrosshairTransparency();
        SetCrosshairSize();
        SetCrosshairScale();
        SetCrosshairPosition();
    }
    public void SetCrosshairColor()
    {
        for (int i = 0; i < _images.Length; i++)
        {
            _images[i].color = _colorImages;
        }
    }

    public void SetCrosshairTransparency()
    {
        _transparencyImages = Mathf.Clamp(_transparencyImages, 0f, 1f);

        for (int i = 0; i < _images.Length; i++)
        {
            _images[i].color = new Color(_images[i].color.r, _images[i].color.g, _images[i].color.b, _transparencyImages);
        }
    }

    public void SetCrosshairSize()
    {
        _sizeImages = Mathf.Clamp(_sizeImages, 10f, 50f);
        _leftRectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, _sizeImages);

        _sizeImages = Mathf.Clamp(_sizeImages, 10f, 50f);
        _rightRectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, _sizeImages);

        _sizeImages = Mathf.Clamp(_sizeImages, 10f, 50f);
        _upRectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, _sizeImages);

        _sizeImages = Mathf.Clamp(_sizeImages, 10f, 50f);
        _downRectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, _sizeImages);
    }

    public void SetCrosshairScale()
    {
        _scaleImages = Mathf.Clamp(_scaleImages, 1f, 50f);
        _leftRectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, _scaleImages);

        _scaleImages = Mathf.Clamp(_scaleImages, 1f, 50f);
        _rightRectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, _scaleImages);

        _scaleImages = Mathf.Clamp(_scaleImages, 1f, 50f);
        _upRectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, _scaleImages);

        _scaleImages = Mathf.Clamp(_scaleImages, 1f, 50f);
        _downRectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, _scaleImages);
    }

    public void SetCrosshairPosition()
    {
        _leftRectTransform.anchoredPosition = new Vector3(_positionImages * -1, 0f, 0f);
        _rightRectTransform.anchoredPosition = new Vector3(_positionImages, 0f, 0f);
        _upRectTransform.anchoredPosition = new Vector3(0f, _positionImages, 0f);
        _downRectTransform.anchoredPosition = new Vector3(0f, _positionImages * -1, 0f);
    }
}
