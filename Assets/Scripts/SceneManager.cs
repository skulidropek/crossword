using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    private WordGenerate _words;
    private Keyboard _keyboard;
    private LattersBoard _lattersBoard;

    private void Start()
    {
        _keyboard = GetComponent<Keyboard>();
        _lattersBoard = GetComponent<LattersBoard>();
        _words = GetComponent<WordGenerate>();
    }

    public void DischargeAll()
    {
        _keyboard.Discharge();
        _lattersBoard.Discharge();
    }

    public void CheckWin(List<char> composeLetters)
    {
        if (_words.WordChars.SequenceEqual(composeLetters.ToArray()))
           Debug.Log("Победа ура");

        _keyboard.Discharge();
        _lattersBoard.Discharge();
    }
}
