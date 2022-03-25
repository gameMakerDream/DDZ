using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DDZ
{
    public class CPGroup : MonoBehaviour
    {
        private int seatIndex;
        public void Initialize(int seatIndex)
        {
            this.seatIndex = seatIndex;
        }
        // Start is called before the first frame update


        public void ShowCP(string[] cps)
        {
            for (int i = 0; i < cps.Length; i++)
            {
                Card _card = GetCard();
                _card.Show(cps[i]);
            }
            SortPosition();
        }
        public void HideCP()
        {
            
        }
        private void SortPosition()
        {
            int _count = transform.childCount;
            float _x = 0;
            float _y = 0;
            if (seatIndex == 0)
            {
                float _totalCardWidth = (_count - 1) * Constants.cpCardInterval + Constants.cpCardWidth;
                float _groupWidth = GetComponent<RectTransform>().rect.width;
                _x = (_groupWidth - _totalCardWidth) / 2;
            }
            for (int i = 0; i < _count; i++)
            {
                if (i >= 10 && seatIndex != 0)
                    _y = 40;
                RectTransform _child = transform.GetChild(i).GetComponent<RectTransform>();
                _child.anchoredPosition = new Vector2(_x, _y);
                _x += Constants.cpCardInterval;
            }
        }
        private Card GetCard()
        {
            GameObject _prefab = Resources.Load<GameObject>(PublicDefine.prefabPath + "ddz/CP");
            GameObject _instance = Instantiate(_prefab, transform);
            Card _card = _instance.GetComponent<Card>();
            if (seatIndex == 1)
                _card.ChangeAnchors(Vector2.one);
            else
                _card.ChangeAnchors(Vector2.zero);
            return _card;
        }


    }
}
