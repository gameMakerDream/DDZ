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
        public void Initialize()
        {
        }

        private void Parse(ServerMessage msg)
        {
            switch (msg.name)
            {
                default:
                    break;
            }
        }





        public void Clear()
        {
        }
    }
}
