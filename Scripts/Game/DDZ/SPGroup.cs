using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DDZ
{
    public class SPGroup : MonoBehaviour
    {
        private int seatIndex;
        public void Initialize(int seatIndex)
        {
            this.seatIndex = seatIndex;
        }

        public void ShowSP(string[] sps)
        {
            for (int i = 0; i < sps.Length; i++)
            {
                Card _card = GetCard();
                _card.Show(sps[i]);
            }
        }


        private Card GetCard()
        {
            GameObject _prefab = Resources.Load<GameObject>(PublicDefine.prefabPath + "ddz/SP");
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
