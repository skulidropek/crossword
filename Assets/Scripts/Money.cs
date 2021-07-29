using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Money : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _moneyText;
    [SerializeField] private int _money;
    public int Moneys { get => _money; set => _money = value; }

    void Update()
    {
        _moneyText.text = _money.ToString();
    }
}
