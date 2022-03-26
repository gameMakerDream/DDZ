using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DDZ
{
    public enum GameState
    {
        Match,
        SendCard,
        CallBanker,
        ShowBanker,
        JiaBei,
        PlayCard,
        Settle
    }
    public class ServerMessage
    {
        public string name;
        public object body;
    }

    public class RoomData
    {
        public string roomId;
        public string roomName;
    }
    public class CardData
    {
        public int color;
        public int number;
        public string name;
        public bool selete;
    }
    public class PlayerData
    {
        public string userId;
        public string nickName;
        public float coin;
        public int sex;
        public int iconIndex;
    }
    public class PlayerCardData
    {
        public List<CardData> spCardList;
        public List<CardData> selectCardList;
    }
    public class DDZMainData
    {
        public RoomData roomData;
        public PlayerData[] playerDataArray;
        public PlayerCardData[] playerCardDataArray;
        public GameState gameState;
    }
}