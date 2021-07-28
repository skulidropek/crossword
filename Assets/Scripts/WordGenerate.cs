using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordGenerate : MonoBehaviour
{
    [SerializeField] private List<string> _possibleWords = new List<string>();
    [SerializeField] private List<string> _testedWords = new List<string>();

    private string _randomWord;
    private char[] _wordChars;

    public string RandomWord { get => _randomWord; set => _randomWord = value; }
    public char[] WordChars { get => _wordChars; set => _wordChars = value; }

    private void Awake()
    {
        for (int i = 0; i < _possibleWords.Count; i++)
        {
            if (_possibleWords[i].Length >= 3 && _possibleWords[i].Length <= 9)
            {
                _testedWords.Add(_possibleWords[i]);
            }
        }

        RandomWord = _testedWords[Random.Range(0, _testedWords.Count)];
        Debug.Log(_randomWord);

        WordChars = new char[RandomWord.Length];
        WordChars = RandomWord.ToUpper().ToCharArray();
    }
}
