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
            base.Initialize(seatIndex);
            this.path = "cp/chupai";
            this.cardWidthArray = Constants.cpCardWidth;
            this.cardHightArray = Constants.cpCardHeight;
            this.cardIntervalArray = Constants.cpCardInterval;
            this.cardOffsetY = -45;
        }
        // Start is called before the first frame update


        public void ShowCP(List<CardData> cpList, bool immediately = false)
        {
            SetCard(cpList);
            if (seatIndex == 0)
                SortPosition(cpList.Count);
            ShowCard(cpList.Count);
           
        }
        public void HideCP()
        {
            
        }
    }
}
