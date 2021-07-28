using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class LattersBoard : MonoBehaviour
{
    [SerializeField] private GameObject _letterEmptyPrefab;
    [SerializeField] private GameObject _letterYellowPrefab;
    [SerializeField] private Transform _lettersBoard;

    private WordGenerate _words;
    private SceneManager _sceneManager;

    public List<char> _composeLetters = new List<char>();

    private List<Transform> _pressedLet = new List<Transform>();
    public List<Transform> PressedLet { get => _pressedLet; set => _pressedLet = value; }

    private void Start()
    {
        _words = GetComponent<WordGenerate>();
        _sceneManager = GetComponent<SceneManager>();

        for (int i = 0; i < _words.RandomWord.Length; i++)
        {
            Instantiate(_letterEmptyPrefab, _lettersBoard);
        }
    }

    public void ChangeLatter(Transform buttonObj, char letter, Button button)
    {
        if (PressedLet.Count != _words.RandomWord.Length + 1)
        {
            PressedLet.Add(buttonObj);
        }

        if (PressedLet.Count != _words.RandomWord.Length + 1)
        {
            _composeLetters.Add(letter.ToString().ToUpper().First());

            button.enabled = false;

            GameObject _keyLetter = Instantiate(_letterYellowPrefab, _lettersBoard);
            _keyLetter.GetComponentInChildren<TextMeshProUGUI>().text = letter.ToString();

            for (int i = PressedLet.Count - 1; i < PressedLet.Count; i++)
            {
                Destroy(_lettersBoard.GetChild(i).gameObject);

                _keyLetter.transform.SetSiblingIndex(i);
            }
        }
        else
        {
            PressedLet.Remove(buttonObj);
        }

        if (PressedLet.Count == _words.RandomWord.Length)
        {
            PressedLet.Remove(buttonObj);
            _sceneManager.CheckWin(_composeLetters);
            return;
        }

    }

    public void Discharge()
    {
        _composeLetters.Clear();
        PressedLet.Clear();

        for (int i = 0; i < _words.RandomWord.Length; i++)
        {
            Destroy(_lettersBoard.GetChild(i).gameObject);
            Instantiate(_letterEmptyPrefab, _lettersBoard);
        }
    }
}
