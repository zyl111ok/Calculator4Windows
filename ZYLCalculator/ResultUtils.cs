using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Utils
{
    class ResultUtils
    {
        //使用两个顺序表，一个存放中序表达式，一个存放后缀表达式
        private System.Collections.ArrayList middleExpression = new System.Collections.ArrayList();
        private System.Collections.ArrayList backExpression = new System.Collections.ArrayList();
        String result;
        
        public ResultUtils(String input)
        {
            //在构造方法处将字符串表达式处理成动态数组
            middleExpression = CalculateUtil.getStringArray(input);
        }
        /**
         * 转换中缀表达式为后缀表达式算法
         */
        private void getBackExpression()
        {
            DefineStack ds = new DefineStack();
            String operators;
            int position = 0;
            while (true)
            {
                if (CalculateUtil.isOperator((String)middleExpression[position]))
                {
                    //如果运算符为"("，直接存入运算符栈
                    if (ds.top == -1 || ((String)middleExpression[position]).Equals("("))
                    {
                        ds.push((String)middleExpression[position]);
                    }
                    //如果运算符是")",出操作符栈并添加到表达式顺序表中，直到遇到"("
                    else if (((String)middleExpression[position]).Equals(")"))
                    {
                        while(!((String)ds.getTop()).Equals("("))
                        {
                            operators = (String)ds.pop();
                            backExpression.Add(operators);
                        }
                        //这里需要弹出"("操作符
                        ds.pop();
                    }
                    //如果当前的运算符比栈顶的运算符优先级低，则输出栈顶运算符到顺序表，并将当前运算符压入运算符栈
                    else if (CalculateUtil.getPority((String)middleExpression[position]) <=
                        CalculateUtil.getPority((String)ds.getTop()) && (ds.top != -1))
                    {
                        operators = (String)ds.pop();
                        if (!operators.Equals("("))
                            backExpression.Add(operators);
                        ds.push((String)middleExpression[position]);
                    }
                    else
                    {
                        ds.push((String)middleExpression[position]);
                    }
                    position++;

                }
                //如果不是操作符，直接将操作数添加到顺序表中
                else
                {
                    backExpression.Add((String)middleExpression[position]);
                    position++;
                }
                if (position >= middleExpression.Count)
                {
                    break;
                }

            }
            while (ds.top != -1)
            {
                operators = (String)ds.pop();
                backExpression.Add(operators);
            }
        
        }
        /**
         * 后缀表达式求值运算
         */
        public String getResult()
        {
            getBackExpression();
            String operator1, operator2, tmp;
            int index = 0;
            DefineStack ds = new DefineStack();
            
            //String first = (String)ienumerator.Current;
            while(index<backExpression.Count)
            {
                tmp =(String)backExpression[index];
                //将栈顶两个操作数出栈，计算二者的值
                index++;
                if (CalculateUtil.isOperator(tmp))
                {
                    operator1 = (String)ds.pop();
                    operator2 = (String)ds.pop();
                    String tmpResult = CalculateUtil.twoOperate(tmp, operator1, operator2);
                    if (tmpResult.Equals("error"))
                    {
                        return "error";
                        break;
                    }
                    ds.push(tmpResult);
                    
                }
                else
                {
                    ds.push(tmp);
                }
                
            }
            result = (String)ds.pop();
            return result;
        }

       
    }
}
