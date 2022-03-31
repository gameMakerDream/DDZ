using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DDZ
{

    public class Constants
    {
        public static float[] spCardInterval ={ 50, 25, 25 };
        public static float[] spCardWidth = { 149, 100, 100 };
        public static float[] spCardHeight ={ 198, 63, 63 };
        public static float[] cpCardInterval = { 35, 35, 35 };
        public static float[] cpCardWidth = { 100, 100, 100 };
        public static float[] cpCardHeight = { 126, 126, 126 };
        private static int[] seat0ChildIndexArray = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19 };
        private static int[] seat1ChildIndexArray = new int[] { 9, 8, 7, 6, 5, 4, 3, 2, 1, 0, 19, 18, 17, 16, 15, 14, 13, 12, 11, 10 };
        private static int[] seat2ChildIndexArray = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19 };
        public static int[][] seatChildIndexArrayArray = new int[][] { seat0ChildIndexArray, seat1ChildIndexArray, seat2ChildIndexArray };

        public static int startDragCardIndex = -1;
        public static int endDragCardIndex = -1;
        public static bool startDrag = false;
        public static bool endDrag = false;


        public const int spCardCount = 17;

        public static GameState gameState;
    }
}
