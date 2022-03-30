using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventName
{
    public const string ServerMessage = "ServerMessage";

    //1匹配环节   2发牌环节 3叫地主环节 4地主展示环节  5加倍环节 6出牌环节 7结算环节
    public const string GameStateNotify = "GameStateNotify";

    //public const string MatchRoundNotify = "MatchRoundNotify";
    public const string MatchRequest = "MatchRequest";
    public const string MatchResponse = "MatchResponse";
    public const string MatchResultNotify = "MatchResultNotify";

    public const string PlayerEnterRoomNotify = "PlayerEnterRoomNotif";
    public const string PlayerExitRoomNotify = "PlayerExitRoomNotify";

    //public const string SendCardRoundNotify = "SendCardRoundNotify";
    public const string SendCardNotify = "SendCardNotify";

    //public const string CallBankerRoundNotify = "CallBankerRoundNotify";
    public const string CallBankerNotify = "CallBankerNotify";
    public const string CallBankerRequest = "CallBankerRequest";
    public const string CallBankerResultNotify = "CallBankerResultNotify";

    //public const string ShowBankerRoundNotify = "ShowBankerRoundNotify";
    public const string ShowBankerNotify = "ShowBankerNotify";

    //public const string JiaBeiRoundNotify = "JiaBeiRoundNotify";
    public const string JiaBeiNotify = "JiaBeiNotify";
    public const string JiaBeiRequest = "JiaBeiRequest";
    public const string JiaBeiResultNotify = "JiaBeiResultNotify";

    //public const string PlayCardRoundNotify = "PlayCardRoundNotify";
    public const string PlayCardNotify = "PlayCardNotify";
    public const string PlayCardRequest = "PlayCardRequest";
    public const string PlayCardResultNotify = "PlayCardResultNotify";

    //public const string SettleRoundNotify = "SettleRoundNotify";
    public const string SettleNotify = "SettleNotify";
    public const string BSChangeNotify = "BSChangeNotify";



    public const string GeShowCardUpdate = "GeShowCardUpdate";//游戏事件 不断更新牌的张数
    public const string GeShowCardComplete = "GeShowCardComplete";//游戏时间 发牌动画结束
}
