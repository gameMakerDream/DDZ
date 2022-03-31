using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DDZ
{
    public abstract class GroupBase : MonoBehaviour,IIndexer
    {
        protected string path = "";
        protected Dictionary<string,Tween> tweenDic=new Dictionary<string, Tween>();
        protected float[] cardWidthArray;
        protected float[] cardHightArray;
        protected float[] cardIntervalArray;
        protected float cardOffsetY;
        protected int validChildCount
        {
            get { return GetValidChildCount(); }
        }
        protected float groupWidth 
        {
            get { return GetComponent<RectTransform>().rect.width; }
        }
        public int seatIndex
        {
            get;
            set;
        }

        public virtual void Initialize(int seatIndex)
        {
            this.seatIndex = seatIndex;
            InitCard();
        }
        protected void SortPosition(int count)
        {
            int _count = count;
            float _x = 0;
            float _y = 0;
            float _interval = cardIntervalArray[seatIndex];
            if (seatIndex == 1)
                _interval = -_interval;
            if (seatIndex == 0)
            {
                float _totalCardWidth = (_count - 1) * _interval + cardWidthArray[seatIndex];
                float _groupWidth = GetComponent<RectTransform>().rect.width;
                _x = (_groupWidth - _totalCardWidth) / 2 + cardWidthArray[seatIndex] / 2;
                _y = -cardHightArray[seatIndex] / 2;
            }
            for (int i = 0; i < _count; i++)
            {
                if (i == 10 && seatIndex != 0)
                {
                    _y = cardOffsetY;
                    _x = 0;
                }
                RectTransform _child = transform.GetChild(GetRealIndexByLogicIndex(i)).GetComponent<RectTransform>();
                _child.anchoredPosition = new Vector2(_x, _y);
                _x += _interval;
            }
        }
        protected void InitCard()
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                Card _card = transform.GetChild(i).GetComponent<Card>();
                _card.Initialize();
            }
        }
        protected  void SetCard(List<CardData> cardList)
        {
            Clear();
            for (int i = 0; i < cardList.Count; i++)
            {
                Card _card = transform.GetChild(GetRealIndexByLogicIndex(i)).GetComponent<Card>();
                _card.name = cardList[i].name;
                _card.SetIcon(path + cardList[i].name);
            }
        }
        protected void Clear()
        {
            for (int i = 0; i < validChildCount; i++)
            {
                Transform _child = transform.GetChild(i);
                _child.gameObject.SetActive(false);
            }
        }
        protected void ShowCard(int count)
        {
            for (int i = 0; i < count; i++)
            {
                Card _card = transform.GetChild(GetRealIndexByLogicIndex(i)).GetComponent<Card>();
                _card.Show();
            }
        }
        //protected void SortNumberUp(int count)
        //{
        //    for (int i = 0; i < count - 1; i++)
        //    {
        //        for (int j = 0; j < count - i - 1; j++)
        //        {
        //            Transform _child1=transform.GetChild(j);
        //            Transform _child2 = transform.GetChild(j + 1);
        //            if (int.Parse(_child1.name.Substring(1,2)) < int.Parse(_child2.name.Substring(1, 2)))
        //            {
        //                Sprite _tempSprite = _child1.Find("BG").GetComponent<Image>().sprite;
        //                string _tempName = _child1.name;
        //                _child1.Find("BG").GetComponent<Image>().sprite = _child2.Find("BG").GetComponent<Image>().sprite;
        //                _child2.Find("BG").GetComponent<Image>().sprite = _tempSprite;
        //                _child1.name = _child2.name;
        //                _child2.name = _tempName;

        //            }
        //        }
        //    }
        //}
        protected int GetRealIndexByLogicIndex(int index)
        {
            return Constants.seatChildIndexArrayArray[seatIndex][index];
        }
        //protected void SortNumberDown(int count)
        //{
        //    for (int i = 0; i < count - 1; i++)
        //    {
        //        for (int j = 0; j < count - i - 1; j++)
        //        {
        //            Transform _child1 = transform.GetChild(j);
        //            Transform _child2 = transform.GetChild(j + 1);
        //            if (int.Parse(_child1.name.Substring(1, 2)) > int.Parse(_child2.name.Substring(1, 2)))
        //            {
        //                Sprite _tempSprite = _child1.Find("BG").GetComponent<Image>().sprite;
        //                string _tempName = _child1.name;
        //                _child1.Find("BG").GetComponent<Image>().sprite = _child2.Find("BG").GetComponent<Image>().sprite;
        //                _child2.Find("BG").GetComponent<Image>().sprite = _tempSprite;
        //                _child1.name = _child2.name;
        //                _child2.name = _tempName;

        //            }
        //        }
        //    }
        //}
        //protected Card GetCard()
        //{
        //    GameObject _prefab = Resources.Load<GameObject>(PublicDefine.prefabPath + path);
        //    GameObject _instance = Instantiate(_prefab, transform);
        //    Card _card = _instance.GetComponent<Card>();
        //    if (seatIndex == 1)
        //        _card.ChangeAnchors(Vector2.one);
        //    else
        //        _card.ChangeAnchors(Vector2.zero);
        //    return _card;
        //}
        protected float[] GetPosXByCount(int count)
        {
            float[] _xArray = new float[count];
            float _groupWidth = GetComponent<RectTransform>().rect.width;
            float _totalCardWidth = (count - 1) * cardIntervalArray[seatIndex] + cardWidthArray[seatIndex];
            float _x = (_groupWidth - _totalCardWidth) / 2 + cardWidthArray[seatIndex] / 2;
            _xArray[0] = _x;
            for (int i = 1; i < count; i++)
            {
                _x += cardIntervalArray[seatIndex];
                _xArray[i] = _x;
            }
            return _xArray;
        }
        protected int GetValidChildCount()
        {
            int _count = 0;
            for (int i = 0; i < transform.childCount; i++)
            {
                GameObject _child = transform.GetChild(i).gameObject;
                if(_child.activeInHierarchy)
                    _count++;
            }
            return _count;
        }
    }
}
