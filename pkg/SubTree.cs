using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace pkg
{
    public class SubTree
    {
        public static StringBuilder Copy(StringBuilder input, int idx)
        {
            StringBuilder res = new StringBuilder();
            Stack<bool> mystack = new Stack<bool>();

            //left procesado -> f
            //right procesado -> t
            for (int i = idx; i < input.Length; i++)
            {

                res.Append(input[i]);

                if (input[i] > 90)
                {
                    if (mystack.Count == 0)
                        return res;

                    //es una variable
                    if (mystack.Peek() == false)
                    {
                        mystack.Pop();
                        mystack.Push(true);
                    }
                    else
                        while (mystack.Count > 0 && mystack.Peek() == true)
                            mystack.Pop();

                    if (mystack.Count == 0)
                        return res;
                }
                else
                {
                    //es un operador
                    if (!input[i].Equals('N'))
                        mystack.Push(false);
                }
            }

            return res;

        }

        public static string Copy(string input, int idx)
        {
            string res = "";
            Stack<bool> mystack = new Stack<bool>();

            //left procesado -> f
            //right procesado -> t
            for (int i = idx; i < input.Length; i++)
            {

                res = res + input[i];

                if (input[i] > 90)
                {
                    if (mystack.Count == 0)
                        return res;

                    //es una variable
                    if (mystack.Peek() == false)
                    {
                        mystack.Pop();
                        mystack.Push(true);
                    }
                    else
                        while (mystack.Count > 0 && mystack.Peek() == true)
                            mystack.Pop();

                    if (mystack.Count == 0)
                        return res;
                }
                else
                {
                    //es un operador
                    if (!input[i].Equals('N'))
                        mystack.Push(false);
                }
            }

            return res;

        }

        public static StringBuilder Cut(StringBuilder input, int idx)
        {
            StringBuilder res = new StringBuilder();
            Stack<bool> mystack = new Stack<bool>();
      
            //left procesado -> f
            //right procesado -> t
            for (int i = idx; i < input.Length; i++)
            {
                res.Append(input[i]);
                
                //if (input.Length == 0)
                //    break;
                if (input[i] > 90)
                {
                    input.Remove(i--, 1);

                    if (mystack.Count == 0)
                        return res;
                    
                    //es una variable
                    if (mystack.Peek() == false)
                    {
                        mystack.Pop();
                        mystack.Push(true);
                    }
                    else
                        while (mystack.Count > 0 && mystack.Peek() == true)
                            mystack.Pop();

                    if (mystack.Count == 0)
                        return res;
                }
                else
                {
                    //es un operador
                    if (!input[i].Equals('N'))
                        mystack.Push(false);
                    input.Remove(i--, 1);
                }
            }

            return res;

        }


        public static string Cut(ref string input, int idx)
        {
            string res = "";
            Stack<bool> mystack = new Stack<bool>();
      
            //left procesado -> f
            //right procesado -> t
            for (int i = idx; i < input.Length; i++)
            {
                res += input[i];
                
                //if (input.Length == 0)
                //    break;
                if (input[i] > 90)
                {
                    input = input.Remove(i--, 1);

                    if (mystack.Count == 0)
                        return res;
                    
                    //es una variable
                    if (mystack.Peek() == false)
                    {
                        mystack.Pop();
                        mystack.Push(true);
                    }
                    else
                        while (mystack.Count > 0 && mystack.Peek() == true)
                            mystack.Pop();

                    if (mystack.Count == 0)
                        return res;
                }
                else
                {
                    //es un operador
                    if (!input[i].Equals('N'))
                        mystack.Push(false);
                    input = input.Remove(i--, 1);
                }
            }

            return res;

        }


    }
}
