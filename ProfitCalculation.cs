using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestProfit
{
    public class ProfitCalculation
    {
        
        public int[] valueInput { get { return valueArray; } set { valueArray = value; } }
        private int[] valueArray;
        public int startIndex { get { return _startIndex; } }
        private int _startIndex = 0;
        private int _currentIndex = 0;

        public int findNextSale()
        {
            int index = startIndex;
            bool increasing = false;
           for(int i = startIndex+1; i < valueInput.Length; i++)
            {
                if (valueInput[index] < valueInput[i])
                {
                    index = i;
                    increasing = true;
                }
                else if (increasing && valueInput[index] > valueInput[i]) return (_currentIndex=index);
            }
            return -1;
        }

        #region StartIndex
        /// <summary>
        /// "Örnek senaryoda bir yatırımcı ucuz olan başlangıca en yakın günden..."
        /// </summary>
        /// <returns>En uygun başlangıç değerinin 'array' içindeki konumunu döndürür</returns>
        public int getOptimumStartIndex()
        {
            return getOptimumBuyIndex(0);
        }
        public int getOptimumBuyIndex()
        {
            return getOptimumBuyIndex(_currentIndex);
        }
         public int getOptimumBuyIndex(int _start)
        {
            if (valueArray == null || _start + 1 >= valueArray.Length) return -1;

            int index= _start+1;
            float score= scoreBuyIndex(index);
            for(int s = _start+1; s < valueArray.Length; s++)
            {
                float tempScore = scoreBuyIndex(s);
                if (score < tempScore)
                {
                    index = s;
                    score = tempScore;
                }
            }
            _startIndex = index;
            _currentIndex = index;
            return index;
        }

        public float scoreBuyIndex(int startIndex)
        {
            float sales = countPosibleSalesOfStartIndex(startIndex) * 2f;
            return (sales + (valueInput.Length - startIndex)) / 3;
        }
        public int countPosibleSalesOfStartIndex(int startIndex)
        {
            int value = valueInput[startIndex];
            int count = 0;
            for(int i = startIndex; i < valueInput.Length; i++)
            {
                if (value < valueInput[i]) count++;
            }
            return count;
        }

        #endregion

    }
}
