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


        public void OnDecodeGameStateNotify(object data)
        {
            GameStateNotify _gsn = data as GameStateNotify;
            VO.gameState = _gsn.gameState;
        }
        public void OnDecodeMatchResponse(object data)
        {

        }
        public void OnDecodePlayerEnterRoomNotify(object data)
        {
            PlayerEnterRoomNotify _pern = data as PlayerEnterRoomNotify;
            PlayerData _pd = _pern.player;
            VO.playerDataList.Add(_pd);
        }
        public void OnDecodePlayerExitRoomNotify(object data)
        {
            PlayerExitRoomNotify _pern = data as PlayerExitRoomNotify;
            PlayerData _pd = _pern.player;
            VO.playerDataList[_pd.seatIndex] = null;
        }
        public void OnDecodeSendCardNotify(object data)
        {
            SendCardNotify _scn=data as SendCardNotify;
            for (int i = 0; i < _scn.spCardListArray.Length; i++)
            {
                VO.playerCardDataList[i] = new PlayerCardData();
                VO.playerCardDataList[i].spCardList = _scn.spCardListArray[i];
            }
            VO.dpCardList = _scn.dpCardList;
        }
        public void OnDecodeCallBankerNotify(object data)
        {
            //不需要处理 直接转发
        }
        public void OnDecodeCallBankerResultNotify(object data)
        {
            CallBankerResultNotify _cbrn =data as CallBankerResultNotify;
            VO.playerCallBankerDataList.Add(_cbrn as PlayerCallBankerData);
        }
        public void OnDecodeShowBankerNotify(object data)
        {
            ShowBankerNotify _sbn=data as ShowBankerNotify;
            VO.bankerData = _sbn.playerData;
        }
        public void OnDecodeJiaBeiNotify(object data)
        {
            //
        }
        public void OnDecodeJiaBeiResultNotify(object data)
        {
            JiaBeiResultNotify _jbrn =data as JiaBeiResultNotify;
            VO.playerJiaBeiDataList.Add(_jbrn as PlayerJiaBeiData);
        }
        public void OnDecodePlayCardNotify(object data)
        {
         
        }
        public void OnDecodePlayCardResultNotify(object data)
        {
            PlayCardResultNotify _pcrn = data as PlayCardResultNotify;
            VO.lastPlayCardList = _pcrn.cpList;

        }
        public void OnDecodeSettleNotify(object data)
        {

        }
    }
}
