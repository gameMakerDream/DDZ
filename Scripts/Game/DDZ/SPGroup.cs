using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System;

namespace DDZ
{
    public class SPGroup : GroupBase
    {
        public override void Initialize(int seatIndex)
        {
            base.Initialize(seatIndex);
            if (seatIndex == 0)
                this.path = "sp/shoupai";
            else
                this.path = "mp/mp";
            this.cardWidthArray = Constants.spCardWidth;
            this.cardHightArray = Constants.spCardHeight;
            this.cardIntervalArray = Constants.spCardInterval;
            this.cardOffsetY = -40;
        }
        private void Update()
        {
            if (seatIndex == 0)
            {
                if(Constants.startDrag)
                {
                    if (Constants.startDragCardIndex != -1 && Constants.endDragCardIndex != -1)
                    {
                        PrepareSelectCard();
                    }
                }
                if (Constants.endDrag)
                {
                    SelectCard(GetBetweenStartAndEndCardName());
                    Constants.startDragCardIndex = -1;
                    Constants.endDragCardIndex = -1;
                    Constants.startDrag = false;
                    Constants.endDrag = false;
                }
            }
        }
        public void ShowSP(List<CardData> spList,bool immediately)
        {
            SetCard(spList);
            if(seatIndex==0)
                SortPosition(spList.Count);
            if (immediately)
            {
                //所有更新手牌都会走这里 包括立刻发牌
                ShowCard(spList.Count);
                AppFacade.Instance.SendNotification(EventName.GeShowCardUpdate, new object[] { seatIndex,spList.Count });
                AppFacade.Instance.SendNotification(EventName.GeShowCardComplete,new object[] { immediately});
            }
            else
            {
                //只有发牌会走这里 动画 
                if (seatIndex == 0)
                    StartCoroutine("ShowCardAnimationClient", spList.Count);
                else
                    StartCoroutine("ShowCardAnimationOther", spList.Count);

            }
        }
        public void BeBanker(List<CardData> spList, List<CardData> dpList)
        {
            ShowSP(spList,true);
            ShowDP(dpList);
        }
        private void ShowDP(List<CardData> dpList)
        {
            List<string> _cardList = new List<string>();
            for (int i = 0; i < dpList.Count; i++)
            {
                _cardList.Add(dpList[i].name);
            }
            SelectCard(_cardList);
        }
        private IEnumerator ShowCardAnimationClient(int count)
        {
            float _speed = Constants.spCardInterval[seatIndex] / 2;
            float _onceTime = 0.3f;
            int _currentTimes = 0;
            int _totalTimes = count - 1;
            float _totalTime = _onceTime * _totalTimes;
            float _distance = _totalTimes * _speed;
            bool _runing = false;
            for (int i = 0; i < _totalTimes; i++)
            {
                RectTransform _rect = transform.GetChild(i).GetComponent<RectTransform>();
                _rect.anchoredPosition = new Vector2(_rect.anchoredPosition.x + _distance, _rect.anchoredPosition.y);
            }
            RectTransform _first = transform.GetChild(0).GetComponent<RectTransform>();
            _first.gameObject.SetActive(true);
            RectTransform _last = transform.GetChild(_totalTimes).GetComponent<RectTransform>();
            Image _lastImage = Util.FindDeepChildAndGetComponent<Image>(_last, "BG");
            Sprite _lastSprite = _lastImage.sprite;
            _last.anchoredPosition = new Vector2(_last.anchoredPosition.x - _distance, _last.anchoredPosition.y);
            _last.gameObject.SetActive(true);
            for (int i = 0; i < _totalTimes; i++)
            {
                string _tweenName = i.ToString() + "left";
                RectTransform _rect = transform.GetChild(i).GetComponent<RectTransform>();
                Tween tween = _rect.DOAnchorPosX(_rect.anchoredPosition.x - _distance, _totalTime).SetEase(Ease.Linear).OnComplete(() =>
                {
                    tweenDic.Remove(_tweenName);
                });
                tweenDic.Add(_tweenName, tween);
            }
            while (_currentTimes < _totalTimes)
            {
                if (!_runing)
                {
                    string _tweenName = _currentTimes.ToString() + "right";
                    Transform _current = transform.GetChild(_currentTimes + 1);
                    Image _currentImage = Util.FindDeepChildAndGetComponent<Image>(_current, "BG");
                    if (_currentTimes + 1 == _totalTimes)
                        _lastImage.sprite = _lastSprite;
                    else
                        _lastImage.sprite = _currentImage.sprite;
                    Tween tween = _last.DOAnchorPosX(_last.anchoredPosition.x + _speed, _onceTime).SetEase(Ease.Linear).OnComplete(() =>
                      {
                          tweenDic.Remove(_tweenName);
                          _current.gameObject.SetActive(true);
                          _currentTimes++;
                          _runing = false;
                      });
                    tweenDic.Add(_tweenName, tween);
                    _runing = true;
                    AppFacade.Instance.SendNotification(EventName.GeShowCardUpdate, new object[] { seatIndex, _currentTimes + 1 });
                }
                yield return new WaitForEndOfFrame();
            }
            yield return new WaitForEndOfFrame();
            StartCoroutine("SortNumberAnimation", count);
        }
        private IEnumerator SortNumberAnimation(int count)
        {
            float _middlePosX = groupWidth / 2 - Constants.spCardWidth[seatIndex] / 2;
            float[] _originPosX = GetPosXByCount(Constants.spCardCount);
            int _finishCount = 0;
            for (int i = 0; i < count; i++)
            {
                RectTransform _rect = transform.GetChild(i).GetComponent<RectTransform>();
                _rect.DOAnchorPosX(_middlePosX, 0.2f).SetEase(Ease.Linear).OnComplete(() => 
                {
                    _finishCount++;
                });
            }
            while(_finishCount<count)
                yield return new WaitForEndOfFrame();
            //SortNumberUp(count);
            int _times = count / 2;
            int _middleIndex = _times;
            float _onceTime = 0.04f;
            int _temp = _times;
            for (int i = 0; i < count; i++)
            {
                RectTransform _child = transform.GetChild(i).GetComponent<RectTransform>();

                if (i < _middleIndex)
                {
                    _temp -=1;
                }
                else if (i == _middleIndex)
                {
                    _temp = 1;
                    _times = 1;
                    _child.anchoredPosition = new Vector2(_originPosX[i], _child.anchoredPosition.y);
                    continue;
                }
                else
                {
                    _temp +=1;
                }
                string _tweenName1 = "SortAnimation1"+i;
                Tween tween1= _child.DOScale(new Vector3(1.1f, 1.1f, 0), _times * _onceTime / 2).SetEase(Ease.Linear).SetLoops(2, LoopType.Yoyo).OnComplete(() =>
                {
                    tweenDic.Remove(_tweenName1);
                });
                string _tweenName2 = "SortAnimation2" + i;
                Tween tween2 = _child.DOAnchorPosX(_originPosX[i], _times * _onceTime).SetEase(Ease.OutBack).OnComplete(() =>
                {
                    tweenDic.Remove(_tweenName2);
                });
                tweenDic.Add(_tweenName1, tween1);
                tweenDic.Add(_tweenName2, tween1);
                _times = _temp;
            }
            yield return new WaitForSeconds(count / 2 * _onceTime);
            AppFacade.Instance.SendNotification(EventName.GeShowCardComplete,new object[] { false});
        }
        private IEnumerator ShowCardAnimationOther(int count)
        {
            for (int i = 0; i < count; i++)
            {
                AppFacade.Instance.SendNotification(EventName.GeShowCardUpdate, new object[] { seatIndex, i + 1 });
                int _index = Constants.seatChildIndexArrayArray[seatIndex][i];
                transform.GetChild(_index).gameObject.SetActive(true);
                yield return new WaitForSeconds(0.3f);
            }
        }

        private void PrepareSelectCard()
        {
            AllWhite();
            List<string> _cardNameList = GetBetweenStartAndEndCardName();
            for (int i = 0; i < _cardNameList.Count; i++)
            {
                Card _card = GetCardByName(_cardNameList[i]);
                _card.SetColor(Color.gray);
            }
        }
        private void SelectCard(List<string> cardNameList)
        {
            for (int i = 0; i < cardNameList.Count; i++)
            {
                Card _card = GetCardByName(cardNameList[i]);
                _card.SetColor(Color.white);
                _card.Select();
            }
        }
        private List<string> GetBetweenStartAndEndCardName()
        {
            List<string> _result = new List<string>();
            int _startIndex = Constants.startDragCardIndex;
            int _endIndex = Constants.endDragCardIndex;
            if (_startIndex > _endIndex)
            {
                int _temp = _startIndex;
                _startIndex = _endIndex;
                _endIndex = _temp;
            }
            for (int i = _startIndex; i <= _endIndex; i++)
            {
                string _cardName = transform.GetChild(i).name;
                _result.Add(_cardName);
            }
            return _result;
        }
        public List<string> GetSelectCardData()
        {
            List<string> _result = new List<string>();
            for (int i = 0; i < validChildCount; i++)
            {
                Card _card = transform.GetChild(i).GetComponent<Card>();
                if (_card.IsSelect())
                    _result.Add(_card.name);
            }
            return _result;
        }
        private Card GetCardByName(string cardName)
        {
            for (int i = 0; i < validChildCount; i++)
            {
                Card _card = transform.GetChild(i).GetComponent<Card>();
                if (cardName == _card.name)
                    return _card;
            }
            return null;
        }

        private void AllWhite()
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                Card _card = transform.GetChild(i).GetComponent<Card>();
                _card.SetColor(Color.white);
            }
        }
        private void AllDown()
        {
            AllWhite();
            for (int i = 0; i < transform.childCount; i++)
            {
                Card _card = transform.GetChild(i).GetComponent<Card>();
                _card.Select(false);
            }
        }
    }
}
