using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class KeyboardButton : MonoBehaviour
{
    private LattersBoard _lattersBoard;
    private Image _image;

    private void Start()
    {
        _image = GetComponent<Image>();

        _lattersBoard = GameObject.FindGameObjectWithTag("GameController").GetComponent<LattersBoard>();
    }

    public void Press()
    {
        SetPressedColor();
            
        char[] _letterChar = GetComponentInChildren<TextMeshProUGUI>().text.ToCharArray();
        char letter = _letterChar[0];

        _lattersBoard.ChangeLatter(gameObject.transform, letter, GetComponent<Button>());
    }

    public void SetPressedColor()
    {
        _image.color = new Color(1, 1, 1, 0.5f);
    }

    public void SetDefaultColor()
    {
        _image.color = new Color(1, 1, 1, 1);
    }
}
