using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Images : MonoBehaviour
{
    [SerializeField] private Transform _imagesPos;
    [SerializeField] private GameObject _image;

    public Transform ImagePos { get => _imagesPos; set => _imagesPos = value; }

    void Start()
    {
        transform.position = _imagesPos.position;
        for(int i = 0; i < 4; i++)
            Instantiate(_image, _imagesPos);
    }
}
