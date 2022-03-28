using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
namespace DDZ
{
    public class SPGroup : GroupBase
    {
        public override void Initialize(int seatIndex)
        {
            this.seatIndex = seatIndex;
            this.path = "sp/shoupai";
        }

        public void ShowSP(List<CardData> spList,bool immediately=false)
        {
            for (int i = 0; i < spList.Count; i++)
            {
                Card _card = transform.GetChild(i).GetComponent<Card>();
                _card.name = spList[i].name;
                _card.SetIcon(path + spList[i].name);
                _card.gameObject.SetActive(false);
            }
            if (!immediately)
            {

                StartCoroutine("SendCardAnimation");
            }
            else
            {
                for (int i = 0; i < spList.Count; i++)
                {
                    Card _card = transform.GetChild(i).GetComponent<Card>();
                    _card.Show();
                }
            }
            //SortPosition();
        }
        bool a = false;
        private IEnumerator SendCardAnimation()
        {
            transform.GetChild(0).gameObject.SetActive(true);
            transform.GetChild(transform.childCount-1).gameObject.SetActive(true);

            float middle = GetComponent<RectTransform>().rect.width / 2-Constants.spCardWidth[0]/2;
            transform.GetChild(0).GetComponent<RectTransform>().anchoredPosition = new Vector2(middle, 0);
            transform.GetChild(transform.childCount - 1).GetComponent<RectTransform>().anchoredPosition = new Vector2(middle, 0);
            int leftCount = 1;
            int count = 2;
            while (true)
            {
                if (!a)
                {
                    var pos = GetPosXByCount(count);
                    for (int i = 0; i < leftCount; i++)
                    {
                        RectTransform temp = transform.GetChild(i).GetComponent<RectTransform>();
                        temp.DOAnchorPosX(pos[i], 0.2f).SetEase(Ease.Linear);
                    }
                    RectTransform last = transform.GetChild(transform.childCount - 1).GetComponent<RectTransform>();
                    last.DOAnchorPosX(pos[leftCount], 0.2f).SetEase(Ease.Linear).OnComplete(() =>
                    {
                        leftCount += 1;
                        count = leftCount + 1;
                        last.Find("BG").GetComponent<Image>().sprite = transform.GetChild(leftCount - 1).Find("BG").GetComponent<Image>().sprite;
                        transform.GetChild(leftCount - 1).GetComponent<RectTransform>().anchoredPosition = last.anchoredPosition;
                        transform.GetChild(leftCount - 1).gameObject.SetActive(true);
                        a = false;
                    });
                    a = true;
                }
                yield return new WaitForEndOfFrame();
            }
        }
        private float[] GetPosXByCount(int count)
        {
            float[] _xArray = new float[count];
            float _groupWidth = GetComponent<RectTransform>().rect.width;
            float _totalCardWidth = (count - 1) * Constants.spCardInterval[seatIndex]+Constants.spCardWidth[seatIndex];
            float _x = (_groupWidth - _totalCardWidth) / 2;
            _xArray[0] = _x;
            for (int i = 1; i < count; i++)
            {
                _x+=Constants.spCardInterval[seatIndex];
                _xArray[i] = _x;
            }
            return _xArray;
        }

    }
}
