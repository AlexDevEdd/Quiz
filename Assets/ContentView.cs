using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;
using DG.Tweening;

public class ContentView : MonoBehaviour
{

    [SerializeField] private Transform _view;
    [SerializeField] private CardDataSO[] _cardDataSO;
    [SerializeField] private Text _taskValue;
    [SerializeField] private FadingPanel _fadingPanel;
    [SerializeField] private LevelDataSO[] _levelDataSO;
    [SerializeField] private Cell _cellPrefab;

    private List<CardData> _cardDataList;
    private List<LevelData> _levelDataList;
    private int _iterator = 0;
    private Cell _cell;
    public Text TaskValue => _taskValue;
    private Tween _fadeTween;
    void Awake()
    {
        _cardDataList = new List<CardData>();
        _levelDataList = new List<LevelData>();


        CreateCells(SetLevelsDataList());
        SetTask();

        //_fadingPanel.FadeOutButton(0);
        _fadingPanel.FadeOut( duration: 0F);
      
    }
    private void Start()
    {
      _fadingPanel.RestartCanvasGroup.alpha = 0f;
        _fadingPanel.RestartCanvasGroup.blocksRaycasts = false;
        StartCoroutine(FadeInCoroutine());
       // StartCoroutine(FadeInButtonCoroutine());
    }
    private void CreateLevel()
    {
        _cardDataList.Clear();
        DestroyPreviosLevelCells();
        CreateCells(SetLevelsDataList());
        SetTask();
     
    }


    private List<LevelData> SetLevelsDataList()
    {
        foreach (var item in _levelDataSO)
            _levelDataList.Add(item.LevelData);

        return _levelDataList;
    }

    private void CreateCells(List<LevelData> levelDataList)
    {
        var cardData = GetRandomCardData().CardData;

        for (int i = 0; i < levelDataList[_iterator].CapacityLvl; i++)
        {
            _cellPrefab = Instantiate(_cellPrefab);
            _cellPrefab.transform.SetParent(_view);
            _cellPrefab.transform.localScale = Vector3.one;
            _cellPrefab.name = string.Format("Cell [{0}]", i);
            _cell = _cellPrefab.GetComponent<Cell>();
            _cell.OnNextLevelAction += CreateLevel;

            FillCells(_cellPrefab, cardData);
        }

        if (_iterator < _levelDataSO.Length)
            _iterator++;
        else if (_iterator >= _levelDataSO.Length)
        {       
            _fadeTween = _fadingPanel.RestartCanvasGroup.DOFade(1, 3);
            _fadingPanel.RestartCanvasGroup.blocksRaycasts = true;
            _fadingPanel.RestartCanvasGroup.gameObject.SetActive(true);
            _iterator = 0;
        }
  
    }

    private CardDataSO GetRandomCardData()
    {
        var cardDataSO = _cardDataSO[Random.Range(0, _cardDataSO.Length)];
        return cardDataSO;
    }

    private CardData GetRandomCardData(CardData[] cardDataList) => cardDataList[Random.Range(0, cardDataList.Length)];

    private void FillCells(Cell cell, CardData[] cardDataList)
    {
        CardData randomItem = GetRandomCardData(cardDataList);
       
        if (_cardDataList.Contains(randomItem))
        {
            do
            {
                randomItem = GetRandomCardData(cardDataList);
            }
            while (_cardDataList.Exists(x => x == randomItem));

            SetCell(cell, randomItem);
        }
        else
            SetCell(cell, randomItem);
    }

    private void SetCell(Cell cell, CardData randomItem)
    {
        _cardDataList.Add(randomItem);
        cell.GetComponent<Image>().sprite = randomItem.Sprite;
        cell.gameObject.GetComponent<Cell>().Indentifier = randomItem.Indentifier;

    }

    private void SetTask()
    {
        var randomItem = _cardDataList[Random.Range(0, _cardDataList.Count)];
        _taskValue.text = randomItem.Indentifier;
    }

    private void DestroyPreviosLevelCells()
    {
        _view.transform.DetachChildren();
    }

    private IEnumerator FadeInCoroutine()
    {
        yield return new WaitForSeconds(2f);
        _fadingPanel.FadeIn( duration: 3f);
      // _fadingPanel.FadeIn(_fadingPanel.TaskCanvasGroup,duration: 3f);

    }
  




}

