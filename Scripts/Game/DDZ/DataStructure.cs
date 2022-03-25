using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DDZ
{
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
    }
    public class PlayerData
    {
        public string userId;
        public string nickName;
        public float coin;
        public int sex;
        public int iconIndex;
        public List<CardData> cardList;
    }
    public class DDZMainData
    {
        public RoomData roomData;
    }
}