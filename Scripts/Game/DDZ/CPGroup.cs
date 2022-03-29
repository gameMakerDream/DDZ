using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DDZ
{
    public class CPGroup : GroupBase
    {
        public override void Initialize(int seatIndex)
        {
            this.seatIndex = seatIndex;
            this.path = "cp/chupai";
        }
        // Start is called before the first frame update


        public void ShowCP(List<CardData> cpList, bool immediately = false)
        {
            for (int i = 0; i < cpList.Count; i++)
            {
                Card _card = transform.GetChild(i).GetComponent<Card>();
                _card.name = cpList[i].name;
                _card.SetIcon(path + cpList[i].name);
                _card.Show();
            }
            SortPosition(cpList.Count);
        }
        public void HideCP()
        {
            
        }
    }
}
