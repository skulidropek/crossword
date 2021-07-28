using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ImageButton : MonoBehaviour
{
    [SerializeField] private ImageStatus _imageStatus;
    [SerializeField] private Image _normalImage;

    private Image _image;
    private Vector3 _position;
    private bool _imageEnlarged;
    private Images _images;

    void Start()
    {
        _image = GetComponent<Image>();
        _images = FindObjectOfType<Images>();
    }


    enum ImageStatus
    {
        unlock = 0,
        buylock = 1,
        block = 2,
    }

    public void OnClick()
    {
        if (_imageStatus == ImageStatus.unlock)
        {
            if (_imageEnlarged)
            {
                Debug.Log("Вы уменьшили картинку");
            }
            else
            {
                _position = transform.position;
                
                Debug.Log("Вы увеличили картинку");
            }

            transform.localScale = _imageEnlarged ? transform.localScale / 2 : transform.localScale * 2;
            transform.position = _imageEnlarged ? _position : _images.transform.position;
            _imageEnlarged = !_imageEnlarged;

            foreach (Transform transform in _images.ImagePos)
                if (this.transform != transform)
                    transform.gameObject.SetActive(!_imageEnlarged);
        }
        if (_imageStatus == ImageStatus.buylock)
        {
            _image.sprite = _normalImage.sprite;
     
            _imageStatus = ImageStatus.unlock;
            Debug.Log("Нужно купить");
        }
        else if (_imageStatus == ImageStatus.block)
            Debug.Log("Заблокировано");
    }
}
