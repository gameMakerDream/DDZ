using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DDZ
{
    public abstract class GroupBase : MonoBehaviour,IIndexer
    {
        protected string path = "";


        public int seatIndex
        {
            get;
            set;
        }

        public virtual void Initialize(int seatIndex)
        {
            this.seatIndex = seatIndex;
        }
        protected void SortPosition()
        {
            int _count = transform.childCount;
            float _x = 0;
            float _y = 0;
            if (seatIndex == 0)
            {
                float _totalCardWidth = (_count - 1) * Constants.spCardInterval[seatIndex] + Constants.spCardWidth[seatIndex];
                float _groupWidth = GetComponent<RectTransform>().rect.width;
                _x = (_groupWidth - _totalCardWidth) / 2;
            }
            for (int i = 0; i < _count; i++)
            {
                if (i >= 10 && seatIndex != 0)
                {
                    _y = 40;
                    _x = 0;
                }
                RectTransform _child = transform.GetChild(i).GetComponent<RectTransform>();
                _child.anchoredPosition = new Vector2(_x, _y);
                _x += Constants.spCardInterval[seatIndex];
            }
        }
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
    }
}
