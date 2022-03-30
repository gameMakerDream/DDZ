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
        }
        // Start is called before the first frame update


        public void ShowCP(List<CardData> cpList, bool immediately = false)
        {
            SortPosition(cpList.Count);
        }
        public void HideCP()
        {
            
        }
    }
}
