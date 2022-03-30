using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DDZ
{
    public class SCMessage
    {
        private static SCMessage instance;
        public static SCMessage Instance
        {
            get
            {
                if (instance == null)
                    instance = new SCMessage();
                return instance;
            }
        }
        private DDZMainDataProxy ddzProxy;
        public void Initialize()
        {
            ddzProxy = AppFacade.Instance.RetrieveProxy(DDZMainDataProxy.NAME) as DDZMainDataProxy;
        }

        public void Decode(ServerMessage msg)
        {
            object[] _args;
            switch (msg.name)
            {
                case EventName.GameStateNotify:
                    _args = OnDecodeGameStateNotify(msg.body);
                    break;
                case EventName.MatchResponse:
                    _args = OnDecodeMatchResponse(msg.body);
                    break;
                case EventName.MatchResultNotify:
                    _args = OnDecodeMatchResultNotify(msg.body);
                    break;
                case EventName.PlayerEnterRoomNotify:
                    _args = OnDecodePlayerEnterRoomNotify(msg.body);
                    break;
                case EventName.PlayerExitRoomNotify:
                    _args = OnDecodePlayerExitRoomNotify(msg.body);
                    break;
                case EventName.SendCardNotify:
                    _args = OnDecodeSendCardNotify(msg.body);
                    break;
                case EventName.CallBankerNotify:
                    _args = OnDecodeCallBankerNotify(msg.body);
                    break;
                case EventName.CallBankerResultNotify:
                    _args = OnDecodeCallBankerResultNotify(msg.body);
                    break;
                case EventName.ShowBankerNotify:
                    _args = OnDecodeShowBankerNotify(msg.body);
                    break;
                case EventName.JiaBeiNotify:
                    _args = OnDecodeJiaBeiNotify(msg.body);
                    break;
                case EventName.JiaBeiResultNotify:
                    _args = OnDecodeJiaBeiResultNotify(msg.body);
                    break;
                case EventName.PlayCardNotify:
                    _args = OnDecodePlayCardNotify(msg.body);
                    break;
                case EventName.PlayCardResultNotify:
                    _args = OnDecodePlayCardResultNotify(msg.body);
                    break;
                case EventName.SettleNotify:
                    _args = OnDecodeGameSettleNotify(msg.body);
                    break;
                default:
                    _args = null;
                    break;
            }
            QueueMessage _qm = new QueueMessage(msg.name, _args);
            EventQueue.Instance.Add(_qm);
        }

        private object[] OnDecodeGameStateNotify(object data)
        {
            GameStateNotify _gsn = data as GameStateNotify;
            return ddzProxy.OnSetGameStateNotify(_gsn);
        }
        private object[] OnDecodeMatchResponse(object data)
        {
            MatchResponse _mr = data as MatchResponse;
            return ddzProxy.OnSetMatchResponse(_mr);

        }
        private object[] OnDecodeMatchResultNotify(object data)
        {
            MatchResultNotify _mrn = data as MatchResultNotify;
            return ddzProxy.OnSetMatchResultNotify(_mrn);

        }
        private object[] OnDecodePlayerEnterRoomNotify(object data)
        {
            PlayerEnterRoomNotify _pern = data as PlayerEnterRoomNotify;
            return ddzProxy.OnSetPlayerEnterRoomNotify(_pern);

        }
        private object[] OnDecodePlayerExitRoomNotify(object data)
        {
            PlayerExitRoomNotify _pern = data as PlayerExitRoomNotify;
            return ddzProxy.OnSetPlayerExitRoomNotify(_pern);

        }
        private object[] OnDecodeSendCardNotify(object data,bool immediately=false)
        {
            SendCardNotify _scn = data as SendCardNotify;
            return ddzProxy.OnSetSendCardNotify(_scn, immediately);

        }
        private object[] OnDecodeCallBankerNotify(object data)
        {
            CallBankerNotify _cbn = data as CallBankerNotify;
            return ddzProxy.OnSetCallBankerNotify(_cbn);

        }
        private object[] OnDecodeCallBankerResultNotify(object data)
        {
            CallBankerResultNotify _cbrn = data as CallBankerResultNotify;
            return ddzProxy.OnSetCallBankerResultNotify(_cbrn);

        }
        private object[] OnDecodeShowBankerNotify(object data)
        {
            ShowBankerNotify _sbn = data as ShowBankerNotify;
            return ddzProxy.OnSetShowBankerNotify(_sbn);
        }
        private object[] OnDecodeJiaBeiNotify(object data)
        {
            JiaBeiNotify _jbn = data as JiaBeiNotify;
            return ddzProxy.OnSetJiaBeiNotify(_jbn);

        }
        private object[] OnDecodeJiaBeiResultNotify(object data)
        {
            JiaBeiResultNotify _jbrn = data as JiaBeiResultNotify;
            return ddzProxy.OnSetJiaBeiResultNotify(_jbrn);

        }
        private object[] OnDecodePlayCardNotify(object data)
        {
            PlayCardNotify _pcn = data as PlayCardNotify;
            return ddzProxy.OnSetPlayCardNotify(_pcn);

        }
        private object[] OnDecodePlayCardResultNotify(object data)
        {
            PlayCardResultNotify _pcrn = data as PlayCardResultNotify;
            return ddzProxy.OnSetPlayCardResultNotify(_pcrn);

        }
        private object[] OnDecodeGameSettleNotify(object data)
        {
            GameSettleNotify _sn = data as GameSettleNotify;
            return ddzProxy.OnSetGameSettleNotify(_sn);

        }
        public void Clear()
        {
        }
    }
}
