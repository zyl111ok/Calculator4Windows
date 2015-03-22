using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Utils
{   
    /**
    *为转换并计算后缀表达式提供工具的类
     * */
    class CalculateUtil
    {
        //判断给出的字符是否是操作符方法
        public static Boolean isOperator(String str)
        {
            if (str.Equals("+") || str.Equals("-") || str.Equals("(") || str.Equals(")") || str.Equals("*")
                || str.Equals("/"))
            {
                return true;
            }
            else
                return false;
        }
        //该方法用于判断操作符的优先级
        public static int getPority(String str)
        {
            if (str.Equals("+") || str.Equals("-"))
            {
                return 1;
            }
            else if (str.Equals("/") || str.Equals("*"))
            {
                return 2;
            }
            else if (str.Equals("(") || str.Equals(")"))
            {
                return -1;
            }
            else
                return 0;
        }
        //将栈顶取出的两个数进行运算
        public static String twoOperate(String operators,String top1,String top2)
        {
            String op = operators;
            if (top1 == null || top2 == null)
            {
                return "error";
            }
            else
            {
                double x = Double.Parse(top1);
                double y = Double.Parse(top2);
                double z = 0;

                switch (operators)
                {
                    case "+":
                        z = x + y;
                        break;
                    case "-":
                        z = y - x;
                        break;
                    case "*":
                        z = x * y;
                        break;
                    case "/":
                        z = y / x;
                        break;

                    default:
                        z = 0;
                        break;

                }
                return z + "";
            }
        }

        //将字符串表达式转换成所需要的动态数组，并实现数字合并
        public static System.Collections.ArrayList getStringArray(String input)
        {
            char[] tmpChar = input.ToCharArray();
            System.Collections.ArrayList list = new System.Collections.ArrayList();
            StringBuilder str = new StringBuilder();
            int index = 0;
            while (index < tmpChar.Length)
            {
                if (tmpChar[index] != '+' && tmpChar[index] != '-' && tmpChar[index] != '(' && tmpChar[index] != ')'
                    && tmpChar[index] != '*' && tmpChar[index] != '/')
                {
                    str = new StringBuilder();
                    while (tmpChar[index] != '+' && tmpChar[index] != '-' && tmpChar[index] != '(' && tmpChar[index] != ')'
                    && tmpChar[index] != '*' && tmpChar[index] != '/')
                    {
                        str.Append(tmpChar[index]);
                        index++;
                        if (index == tmpChar.Length)
                        {
                            break;
                        }
                    }
                    list.Add(str.ToString()+"");
                }
                else
                {
                    list.Add(tmpChar[index] + "");
                    index++;
                }
            }
            return list;
        }


    }
}
