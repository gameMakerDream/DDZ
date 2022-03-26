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
            ddzProxy=AppFacade.Instance.RetrieveProxy(DDZMainDataProxy.NAME) as DDZMainDataProxy;
        }

        private void Decode(ServerMessage msg)
        {
            object[] _args;
            switch (msg.name)
            {
                case "RoundNotify":
                    _args=OnDecodeRoundNotify(msg.body);
                    break;
                case "MatchResponse":
                    _args = OnDecodeMatchResponse(msg.body);
                    break;
                case "PlayerEnterRoomNotif":
                    _args = OnDecodePlayerEnterRoomNotify(msg.body);
                    break;
                case "PlayerExitRoomNotify":
                    _args = OnDecodePlayerExitRoomNotify(msg.body);
                    break;
                case "SendCardNotify":
                    _args = OnDecodeSendCardNotify(msg.body);
                    break;
                case "CallBankerNotify":
                    _args = OnDecodeCallBankerNotify(msg.body);
                    break;
                case "CallBankerResultNotify":
                    _args = OnDecodeCallBankerResultNotify(msg.body);
                    break;
                case "ShowBankerNotify":
                    _args = OnDecodeShowBankerNotify(msg.body);
                    break;
                case "JiaBeiNotify":
                    _args = OnDecodeJiaBeiNotify(msg.body);
                    break;
                case "JiaBeiResultNotify":
                    _args = OnDecodeJiaBeiResultNotify(msg.body);
                    break;
                case "PlayCardNotify":
                    _args = OnDecodePlayCardNotify(msg.body);
                    break;
                case "PlayCardResultNotify":
                    _args = OnDecodePlayCardResultNotify(msg.body);
                    break;
                case "SettleNotify":
                    _args = OnDecodeSettleNotify(msg.body);
                    break;
                default:
                    _args =null;
                    break;
            }
            QueueMessage _qm = new QueueMessage(msg.name, _args);
            EventQueue.Instance.Add(_qm);
        }

        private object[] OnDecodeRoundNotify(object data)
        {
            GameStateNotify _gsn = data as GameStateNotify;
            return null;
        }
        private object[] OnDecodeMatchResponse(object data)
        {
            return null;

        }
        private object[] OnDecodePlayerEnterRoomNotify(object data)
        {
            return null;

        }
        private object[] OnDecodePlayerExitRoomNotify(object data)
        {
            return null;

        }
        private object[] OnDecodeSendCardNotify(object data)
        {
            return null;

        }
        private object[] OnDecodeCallBankerNotify(object data)
        {
            return null;

        }
        private object[] OnDecodeCallBankerResultNotify(object data)
        {
            return null;

        }
        private object[] OnDecodeShowBankerNotify(object data)
        {

            return null;
        }
        private object[] OnDecodeJiaBeiNotify(object data)
        {
            return null;

        }
        private object[] OnDecodeJiaBeiResultNotify(object data)
        {
            return null;

        }
        private object[] OnDecodePlayCardNotify(object data)
        {
            return null;

        }
        private object[] OnDecodePlayCardResultNotify(object data)
        {
            return null;

        }
        private object[] OnDecodeSettleNotify(object data)
        {
            return null;

        }
        public void Clear()
        {
        }
    }
}
