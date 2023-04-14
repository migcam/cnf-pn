using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace pkg
{
    public class SubTree
    {
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

        public static StringBuilder Copy(StringBuilder input, int idx)
        {
            int length = GetSubTreeLength(input,idx);
            return new StringBuilder(input.ToString(idx,length));
        }

        public static string Copy(string input, int idx)
        {
            int length = GetSubTreeLength(input,idx);
            return input.Substring(idx,length);
        }

        // public static StringBuilder Cut(StringBuilder input, int idx)
        // {
        //     int length = GetSubTreeLength(input,idx);
        
        //     input = new StringBuilder(input.ToString().Remove(idx,length));

        //     string res = input.ToString(idx,length);
        //     return new StringBuilder(res);
        // }

        // public static string Cut(ref string input, int idx)
        // {
        //     int length = GetSubTreeLength(input,idx);
        //     string res = input.Substring(idx,length);

        //     input.Remove(idx,length+1);

        //     return res;
        // }

        public static int GetSubTreeLength(string input, int startIndex)
        {
            Stack<bool> mystack = new Stack<bool>();
            //left procesado -> f
            //right procesado -> t
            for (int i = startIndex; i < input.Length; i++)
            {
                //es un operador
                if(input[i] <= 90 && !input[i].Equals('N'))
                {
                    mystack.Push(false);
                }

                if (input[i] > 90)
                {
                    if (mystack.Count == 0)
                        return i-startIndex+1;

                    //es una variable
                    if (mystack.Peek() == false)
                    {
                        mystack.Pop();
                        mystack.Push(true);
                        continue;
                    }
                    
                    while (mystack.Count > 0 && mystack.Peek() == true)
                        mystack.Pop();

                    if (mystack.Count == 0)
                        return i-startIndex+1;
                }
            }

            return input.Length - startIndex;

        }

        public static int GetSubTreeLength(StringBuilder input, int startIndex)
        {
            Stack<bool> mystack = new Stack<bool>();
            //left procesado -> f
            //right procesado -> t
            for (int i = startIndex; i < input.Length; i++)
            {
                //es un operador
                if(input[i] <= 90 && !input[i].Equals('N'))
                {
                    mystack.Push(false);
                }

                if (input[i] > 90)
                {
                    if (mystack.Count == 0)
                        return i-startIndex+1;

                    //es una variable
                    if (mystack.Peek() == false)
                    {
                        mystack.Pop();
                        mystack.Push(true);
                        continue;
                    }
                    
                    while (mystack.Count > 0 && mystack.Peek() == true)
                        mystack.Pop();

                    if (mystack.Count == 0)
                        return i-startIndex+1;
                }
            }

            return input.Length - startIndex;

        }


    }
}
