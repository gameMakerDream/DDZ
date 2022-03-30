using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventName
{
    public const string ServerMessage = "ServerMessage";

    //1ƥ�价��   2���ƻ��� 3�е������� 4����չʾ����  5�ӱ����� 6���ƻ��� 7���㻷��
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



    public const string GeShowCardUpdate = "GeShowCardUpdate";//��Ϸ�¼� ���ϸ����Ƶ�����
    public const string GeShowCardComplete = "GeShowCardComplete";//��Ϸʱ�� ���ƶ�������
}
