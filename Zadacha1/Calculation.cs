﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Zadacha1
{
    class Calculation
    {
        private int[] _array;
        private int[] _arrayMovingAverage;
        private int[] _arrayRatio;
        private int _arraySize;
        private int _ArraySize
        {
            get { return _arraySize; }
            set
            {
                if (value > 100 || value <= 0)
                {
                    Console.WriteLine("Размер массива должен быть больше нуля и меньше 100!");
                }
                else
                {
                    _arraySize = value;
                }
            }
        }

        Random rand = new Random();
        public Calculation(int arraySize)
        {
            this._ArraySize = arraySize;
            _array = new int[_ArraySize];
        }
        public int[] Fill()
        {
            for (int i = 0; i < _array.Length; i++)
            {
                _array[i] = rand.Next(0, 25);
            }
            return _array;
        }
        public int[] GetMovingAverage(int period)
        {
            _arrayMovingAverage = new int[_ArraySize - period + 1];
            for (int j = 0; j <= (_ArraySize - (period - 1)) && j < _arrayMovingAverage.Length; j++)
            {
                int sum = 0;
                for (int i = j + period - 1; i >= j && i < _array.Length; i--)
                {
                    sum += _array[i];
                }
                _arrayMovingAverage[j] = sum / period;
            }
            return _arrayMovingAverage;
        }
        public int[] GetRatio()
        {
            _arrayRatio = new int[_ArraySize - 1];
            for (int i = 0; i < _arrayRatio.Length; i++)
                if (_array[i] != 0)
                {
                    _arrayRatio[i] = _array[i + 1] / _array[i];
                }
                else
                {
                    _arrayRatio[i] = 0;
                }
            return _arrayRatio;
        }
    }
}

