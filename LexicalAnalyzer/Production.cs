using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LexicalAnalyzer
{
    class Production
    {
        private string left;                    //产生式左部
        private List<string> right;             //产生式右部
        private HashSet<string> selectStr;         //产生式对应的select集

        public Production(string left, List<string> right)
        {
            this.left = left;
            this.right = right;
            this.selectStr = new HashSet<string>();
        }

        /// <summary>
        /// set or get 产生式左部
        /// </summary>
        public string Left
        {
            get { return left; }
            set { left = value; }
        }

        /// <summary>
        /// set or get 产生式右部
        /// </summary>
        public List<string> Right
        {
            get { return right; }
            set { right = value; }
        }

        /// <summary>
        /// set or get 产生式的select集
        /// </summary>
        public HashSet<string> SelectStr
        {
            get { return selectStr; }
            set { selectStr = value; }
        }

        /// <summary>
        /// 组合产生式的左部和右部，返回产生式的结构
        /// </summary>
        /// <returns>产生式的结构</returns>
        public override string ToString()
        {
            string productionStr = this.left + " -> ";
            foreach (string str in this.right)
            {
                productionStr = productionStr + str + " ";
            }
            return productionStr;
        }

    }
}
