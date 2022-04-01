using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DDZ
{
    public enum CardType
    {
        None,
        Single=1,
        Double=2,
        Three=3,
        Boom4=4,
        Boom5=5,
        Boom6=6,
        Boom7=7,
        Boom8=8,
        ThreeBySingle=9,
        ThreeByDouble=10,
        FourByDouble=11,
        FourBy2Double=12,
        Straight=13,
        DoubleStraight=14,
        Plane=15,
        PlaneBySingle=16,
        PlaneByDouble=17,
        Rocket=18,
    }
    public class AlgorithmHelper
    {



        private static DDZMainDataProxy proxy = AppFacade.Instance.RetrieveProxy(DDZMainDataProxy.NAME) as DDZMainDataProxy;
        private static CardData[] spDataArray;

        public static void Hint()
        {
            LastPlayCardData _lpcd = proxy.VO.lastCpCardData;
            spDataArray = new List<CardData>(proxy.VO.playerCardDataArray[0].spCardList).ToArray();
            if (_lpcd.clientSeat == 0)
            {

            }
            else
            {
                object[] _typeAndMin = GetTypeAndMin(_lpcd.cpList.ToArray());
                CardType _cardType = (CardType)_typeAndMin[0];
                int _min = (int)_typeAndMin[1];
                HintForFight(_cardType, _min);
            }
        }
        private static void HintForFight(CardType cardType, int min)
        {
            switch (cardType)
            {
                case CardType.None:
                    break;
                case CardType.Single:
                    break;
                case CardType.Double:
                    break;
                case CardType.Three:
                    break;
                case CardType.Boom4:
                    break;
                case CardType.Boom5:
                    break;
                case CardType.Boom6:
                    break;
                case CardType.Boom7:
                    break;
                case CardType.Boom8:
                    break;
                case CardType.ThreeBySingle:
                    break;
                case CardType.ThreeByDouble:
                    break;
                case CardType.FourByDouble:
                    break;
                case CardType.FourBy2Double:
                    break;
                case CardType.Straight:
                    break;
                case CardType.DoubleStraight:
                    break;
                case CardType.Plane:
                    break;
                case CardType.PlaneBySingle:
                    break;
                case CardType.PlaneByDouble:
                    break;
                case CardType.Rocket:
                    break;
                default:
                    break;
            }
        }
        private static void HintForRun()
        {

        }
        private static object[] GetTypeAndMin(CardData[] array)
        {
            CardType _cardType = CardType.None;
            int _min = -1;
            _min = IsSingle(array);
            if (_min != -1)
            {
                _cardType = CardType.Single;
                return new object[] { _cardType, _min };
            }
            _min = IsDouble(array);
            if (_min != -1)
            {
                _cardType = CardType.Double;
                return new object[] { _cardType, _min };
            }
            _min = IsThree(array);
            if (_min != -1)
            {
                _cardType = CardType.Three;
                return new object[] { _cardType, _min };
            }
            _min = IsBoom(array, array.Length);
            if (_min != -1)
            {
                _cardType = (CardType)array.Length;
                return new object[] { _cardType, _min };
            }
            _min = IsThreeBySingle(array);
            if (_min != -1)
            {
                _cardType = CardType.ThreeBySingle;
                return new object[] { _cardType, _min };
            }
            _min = IsThreeByDouble(array);
            if (_min != -1)
            {
                _cardType = CardType.ThreeByDouble;
                return new object[] { _cardType, _min };
            }
            _min = IsFourByDouble(array);
            if (_min != -1)
            {
                _cardType = CardType.FourByDouble;
                return new object[] { _cardType, _min };
            }
            _min = IsFourBy2Double(array);
            if (_min != -1)
            {
                _cardType = CardType.FourBy2Double;
                return new object[] { _cardType, _min };
            }
            _min = IsStraight(array);
            if (_min != -1)
            {
                _cardType = CardType.Straight;
                return new object[] { _cardType, _min };
            }
            _min = IsDoubleStraight(array);
            if (_min != -1)
            {
                _cardType = CardType.DoubleStraight;
                return new object[] { _cardType, _min };
            }
            _min = IsPlane(array);
            if (_min != -1)
            {
                _cardType = CardType.Plane;
                return new object[] { _cardType, _min };
            }
            _min = IsPlanBySingle(array);
            if (_min != -1)
            {
                _cardType = CardType.PlaneBySingle;
                return new object[] { _cardType, _min };
            }
            _min = IsPlaneByDouble(array);
            if (_min != -1)
            {
                _cardType = CardType.PlaneByDouble;
                return new object[] { _cardType, _min };
            }
            _min = IsRocket(array);
            if (_min != -1)
            {
                _cardType = CardType.Rocket;
                return new object[] { _cardType, _min };
            }
            return null;
        }
        #region 判断类型获取最小主牌
        private static int IsSingle(CardData[] array)
        {
            return array.Length == 1 ? array[0].number : -1;
        }
        private static int IsDouble(CardData[] array)
        {
            return (array.Length == 2 && array[0] == array[1]) ? array[0].number : -1;
        }
        private static int IsThree(CardData[] array)
        {
            return (array.Length == 3 && array[0].number == array[1].number && array[1].number == array[2].number) ? array[0].number : -1;
        }
        private static int IsBoom(CardData[] array, int count)
        {
            if (array.Length != count)
                return -1;
            for (int i = 0; i < array.Length - 1; i++)
            {
                if (array[i].number != array[i + 1].number)
                    return -1;
            }
            return array[0].number;
        }
        private static int IsThreeBySingle(CardData[] array)
        {
            //wenti
            if (array.Length != 4)
                return -1;
            int[] _array = Translate(array);
            for (int i = 0; i < _array.Length; i++)
            {
                if (_array[i] == 3)
                    return i;
            }
            return -1;
        }
        private static int IsThreeByDouble(CardData[] array)
        {
            if (array.Length != 5)
                return -1;
            int[] _array = Translate(array);
            bool main = false;
            bool vice = false;
            int min = 0;
            for (int i = 0; i < _array.Length; i++)
            {
                if (_array[i] == 3)
                {
                    main = true;
                    min = i;
                }
                if (_array[i] == 2)
                    vice = true;
            }
            return main && vice ? min : -1;
        }
        private static int IsFourByDouble(CardData[] array)
        {
            if (array.Length != 6)
                return -1;
            int[] _array = Translate(array);
            for (int i = 0; i < _array.Length; i++)
            {
                if (_array[i] == 4)
                    return i;
            }
            return -1;
        }
        private static int IsFourBy2Double(CardData[] array)
        {
            if (array.Length != 8)
                return -1;
            int[] _array = Translate(array);
            bool main = false;
            bool vice = false;
            int count = 0;
            int min = 0;
            for (int i = 0; i < _array.Length; i++)
            {
                if (_array[i] == 4)
                {
                    main = true;
                    min = i;
                }
                if (_array[i] == 2)
                {
                    count++;
                    if (count == 2)
                        vice = true;
                }
            }

            return main && vice ? min : -1;
        }
        private static int IsStraight(CardData[] array)
        {
            if (array.Length < 5)
                return -1;
            int count = 1;
            for (int i = 0; i < array.Length - 1; i++)
            {
                if (array[i].number + 1 == array[i + 1].number && array[i].number + 1 < 15)
                    count++;
            }
            return count == array.Length ? array[0].number : -1;
        }
        private static int IsDoubleStraight(CardData[] array)
        {
            if (array.Length < 6 || array.Length % 2 != 0)
                return -1;
            int[] _array = Translate(array);
            int _count = 1;
            for (int i = 0; i < _array.Length - 1; i++)
            {
                if (_array[i] == 2)
                {
                    if (_array[i] + 1 == _array[i + 1] && array[i].number + 1 < 15)
                        _count++;
                }
            }
            return _count * 2 == array.Length ? array[0].number : -1;
        }
        public static int IsPlane(CardData[] array)
        {
            if (array.Length < 6 || array.Length % 3 != 0)
                return -1;
            int[] _array = Translate(array);
            int _count = 1;
            for (int i = 0; i < _array.Length - 1; i++)
            {
                if (_array[i] == 3)
                {
                    if (_array[i] + 1 == _array[i + 1] && array[i].number + 1 < 15)
                        _count++;
                }
            }
            return _count * 3 == array.Length ? array[0].number : -1;
        }
        private static int IsPlanBySingle(CardData[] array)
        {
            if (array.Length < 8 || array.Length % 4 != 0)
                return -1;
            int[] _array = Translate(array);
            List<int> main = new List<int>();
            int viceCount = 0;
            int min = 0;
            for (int i = 0; i < _array.Length; i++)
            {
                if (_array[i] == 3)
                {
                    main.Add(i);
                    if (min == 0)
                        min = i;
                }
                else if (_array[i] < 3 && _array[i] != 0)
                    viceCount += _array[i];
            }
            if (main.Count < 2 || viceCount != main.Count)
                return -1;
            for (int i = 0; i < main.Count - 1; i++)
            {
                if (main[i] + 1 != main[i + 1] || main[i] + 1 == 15)
                    return -1;
            }
            return min;

        }
        private static int IsPlaneByDouble(CardData[] array)
        {
            if (array.Length < 8 || array.Length % 5 != 0)
                return -1;
            int[] _array = Translate(array);
            List<int> main = new List<int>();
            int viceCount = 0;
            int min = 0;
            for (int i = 0; i < _array.Length; i++)
            {
                if (_array[i] == 3)
                {
                    main.Add(i);
                    if (min == 0)
                        min = i;
                }
                else if (_array[i] == 2)
                    viceCount += _array[i];
            }
            if (main.Count < 2 || viceCount / 2 != main.Count)
                return -1;
            for (int i = 0; i < main.Count - 1; i++)
            {
                if (main[i] + 1 != main[i + 1] || main[i] + 1 == 15)
                    return -1;
            }
            return min;
        }
        private static int IsRocket(CardData[] array)
        {
            if (array.Length != 2)
                return -1;
            int sum = 0;
            for (int i = 0; i < array.Length; i++)
                sum += array[i].number;
            return sum == 33 ? 16 : -1;
        }
        private static int[] Translate(CardData[] array)
        {
            int[] temp = new int[18];
            for (int i = 0; i < array.Length; i++)
                temp[array[i].number]++;
            return temp;
        }
        #endregion
        #region 从手牌中找牌
        private static List<List<int>> FindSingle(int min)
        {
            List<List<int>> _result = new List<List<int>>();
            int[] _array = Translate(spDataArray);
            int _minCount = 1;
            int _maxCount = 3;
            min = min + 1;
            for (int i = _minCount; i <= _maxCount; i++)
            {
                for (int j = min; j < _array.Length; j++)
                {
                    List<int> _group = new List<int>();
                    if (_array[j] == i)
                    {
                        _group.Add(i);
                        _result.Add(_group);
                    }
                }
            }

            return _result;
        }
        private static List<List<int>> FindDouble(int min)
        {
            List<List<int>> _result = new List<List<int>>();
            int[] _array = Translate(spDataArray);
            int _minCount = 2;
            int _maxCount = 3;
            min = min + 1;
            for (int i = _minCount; i <= _maxCount; i++)
            {
                for (int j = min; j < _array.Length; j++)
                {
                    List<int> _group = new List<int>();
                    if (_array[j] == i)
                    {
                        _group.Add(i);
                        _group.Add(i);
                        _result.Add(_group);
                    }
                }
            }
            return _result;
        }
        private static List<List<int>> FindThree(int min)
        {
            List<List<int>> _result = new List<List<int>>();
            int[] _array = Translate(spDataArray);
            int _minCount = 3;
            int _maxCount = 3;
            min = min + 1;
            for (int i = _minCount; i <= _maxCount; i++)
            {
                for (int j = min; j < _array.Length; j++)
                {
                    List<int> _group = new List<int>();
                    if (_array[j] == i)
                    {
                        _group.Add(i);
                        _group.Add(i);
                        _group.Add(i);
                        _result.Add(_group);
                    }
                }
            }
            return _result;
        }
        private static List<List<int>> FindBoom(int min, int count)
        {
            List<List<int>> _result = new List<List<int>>();
            int[] _array = Translate(spDataArray);
            int _minCount = count;
            int _maxCount = 8;
            min = min + 1;
            for (int i = _minCount; i <= _maxCount; i++)
            {
                if (i > _minCount)
                    min = 3;
                for (int j = min; j < _array.Length; j++)
                {
                    List<int> _group = new List<int>();
                    if (_array[j] == i)
                    {
                        _group.Add(i);
                        _group.Add(i);
                        _group.Add(i);
                        _group.Add(i);
                        _result.Add(_group);
                    }
                }
            }
            return _result;
        }
        private static List<List<int>> FindThreeByOne(int min)
        {
            List<List<int>> _result = new List<List<int>>();
            List<int> _mainList = new List<int>();
            List<int> _viceList = new List<int>();
            int[] _array = Translate(spDataArray);
            int _mainMinCount = 3;
            int _mainMaxCount = 3;
            int _viceMinCount = 1;
            int _viceMaxCount = 3;
            min = min + 1;
            for (int i = _mainMinCount; i <= _mainMaxCount; i++)
            {
                for (int j = min; j < 16; j++)
                {
                    if (_array[j] == i)
                    {
                        _array[j] -= i;//防止后面需要再4张以上来找三张的话 找到的副牌和主牌成为一个炸弹 所以这里把所有这张牌都去掉
                        _mainList.Add(j);
                    }
                }
            }
            for (int i = _viceMinCount; i <= _viceMaxCount; i++)
            {
                for (int j = 3; j < _array.Length; j++)
                {
                    if (_array[j] == i)
                        _viceList.Add(j);
                }
            }
            if (_mainList.Count != 0 && _viceList.Count != 0)
            {
                for (int i = 0; i < _mainList.Count; i++)
                {
                    List<int> _group = new List<int>();
                    _group.Add(_mainList[i]);
                    _group.Add(_mainList[i]);
                    _group.Add(_mainList[i]);
                    _group.Add(_viceList[i%_viceList.Count]);
                    _result.Add(_group);
                }
            }
            return _result;
        }
        private static List<List<int>> FindThreeByDouble(int min)
        {
            List<List<int>> _result = new List<List<int>>();
            List<int> _mainList = new List<int>();
            List<int> _viceList = new List<int>();
            int[] _array = new int[] { 0, 0, 0, 2, 2, 3, 2, 3, 3, 3, 3, 3, 3, 3, 1, 4, 4, 4 };
            int _mainMinCount = 3;
            int _mainMaxCount = 3;
            int _viceMinCount = 2;
            int _viceMaxCount = 3;
            min = min + 1;
            for (int i = _mainMinCount; i <= _mainMaxCount; i++)
            {
                for (int j = min; j < 16; j++)
                {
                    if (_array[j] == i)
                    {
                        _array[j] -= i;//防止后面需要再4张以上来找三张的话 找到的副牌和主牌成为一个炸弹 所以这里把所有这张牌都去掉
                        _mainList.Add(j);
                    }
                }
            }
            for (int i = _viceMinCount; i <= _viceMaxCount; i++)
            {
                for (int j = 3; j < _array.Length; j++)
                {
                    if (_array[j] == i)
                        _viceList.Add(j);
                }
            }
            if (_mainList.Count != 0 && _viceList.Count != 0)
            {
                for (int i = 0; i < _mainList.Count; i++)
                {
                    List<int> _group = new List<int>();
                    _group.Add(_mainList[i]);
                    _group.Add(_mainList[i]);
                    _group.Add(_mainList[i]);
                    _group.Add(_viceList[i % _viceList.Count]);
                    _group.Add(_viceList[i % _viceList.Count]);
                    _result.Add(_group);
                }
            }
            return _result;
        }
        #endregion
    }
}
