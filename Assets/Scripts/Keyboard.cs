using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class Keyboard : MonoBehaviour
{
    [SerializeField] private WordGenerate _words;
    [SerializeField] private Transform _keyboard;
    [SerializeField] private GameObject _keyLetterPrefabs;

    private readonly char[] _posibleLatters = new char[15] {'À', 'Á','Â','Ã','Ä','Å','¨','Æ','Ç','È','Ê','Ë','Ì','Í','Î' };

    public List<char> _primordialSortedLatters = new List<char>();
    public List<char> _sortedLetters = new List<char>();
    public List<Transform> _gameObjects = new List<Transform>();
    public List<Transform> _gameObjectsSort = new List<Transform>();

    private void Start()
    {
        _words.RandomWord.ToList().ForEach(word => _primordialSortedLatters.Add(word));
        _posibleLatters.ToList().ForEach(symbol => _primordialSortedLatters.Add(symbol));

        for (int i = 0; i < 14; i++)
        {
            char _randLet = _posibleLatters[UnityEngine.Random.Range(0, _posibleLatters.Length - 1)];

            GameObject _keyLetter = Instantiate(_keyLetterPrefabs, _keyboard);
            _keyLetter.GetComponentInChildren<TextMeshProUGUI>().text = _primordialSortedLatters[i].ToString();
        }

        foreach (Transform child in _keyboard) _gameObjects.Add(child);
        foreach (Transform child in _keyboard) _gameObjectsSort.Add(child);

        Sort();
    }

    public void Sort()
    {
        System.Random _rand = new System.Random();

        for (int i = 0; i < _gameObjects.Count; i++)
        {
            int j = _rand.Next(i);
            Transform tmp = _gameObjects[i];
            _gameObjects[i] = _gameObjects[j];
            _gameObjects[j] = tmp;
        }

        _gameObjects.ForEach(gameobject => gameobject.SetSiblingIndex(gameobject.GetSiblingIndex()));
    }

    public void Discharge()
    {
        for (int i = 0; i < 14; i++)
        {
            if (_keyboard.GetComponentsInChildren<Button>()[i] != null)
                _keyboard.GetComponentsInChildren<KeyboardButton>()[i].SetDefaultColor();

            _keyboard.GetComponentsInChildren<Button>()[i].enabled = true;
        }
    }
}
