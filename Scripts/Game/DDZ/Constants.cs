using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DDZ
{

    public class Constants
    {
        public static float[] spCardInterval = new float[]{50,25,25};
        public static float[] spCardWidth = new float[] { 149, 100, 100 };
        public static float[] spCardHeight = new float[] { 198, 63, 63 };
        private static int[] seat0ChildIndexArray = new int[] {0,1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19 };
        private static int[] seat1ChildIndexArray = new int[] {9,8,7,6,5,4,3,2,1,0,19,18,17,16,15,14,13,12,11,10 };
        private static int[] seat2ChildIndexArray = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19 };
        public static int[][] seatChildIndexArrayArray = new int[][] { seat0ChildIndexArray, seat1ChildIndexArray , seat2ChildIndexArray };


        public static float cpCardInterval = 40;
        public const float cpCardWidth = 100;

        public const int spCardCount = 17;

        public static GameState gameState;
    }
}
