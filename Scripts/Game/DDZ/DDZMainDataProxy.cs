using PureMVC.Patterns.Proxy;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DDZ
{
    public class DDZMainDataProxy : Proxy
    {
        public new const string NAME = "DDZMainDataProxy";

        public DDZMainData VO
        {
            get { return (DDZMainData)Data; }
        }
        public DDZMainDataProxy() : base(NAME)
        {
            Data = new DDZMainData();
        }

        public override void OnRegister()
        {
            base.OnRegister();
        }

        public override void OnRemove()
        {
            base.OnRemove();
        }

        public void SetRoomData(RoomData data)
        {
            
        }
        public void SetPlyerData(PlayerData playerData)
        {
            
        }
        public void SetPlayerCardData(PlayerCardData playerCardData)
        {
            
        }



    }
}
