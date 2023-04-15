using System;
using System.Collections.Generic;
using System.Text;

namespace pkg
{
    public class SubTree
    {

        public static StringBuilder Copy(StringBuilder input, int idx)
        {
            int length = GetSubTreeLength(input,idx);
            return new StringBuilder().Append(input,idx,length);
        }

        public static string Copy(string input, int idx)
        {
            int length = GetSubTreeLength(input,idx);
            return input.Substring(idx,length);
        }
        public static ReadOnlySpan<char> Copy(ReadOnlySpan<char> input, int idx)
        {
            int length = GetSubTreeLength(input,idx);
            return input.Slice(idx,length);
        }

        public static StringBuilder Cut(StringBuilder input, int idx)
        {
            int length = GetSubTreeLength(input,idx);
            StringBuilder res = new StringBuilder().Append(input,idx,length);

            input = input.Remove(idx,length);

            return res;
        }

        // TODO: remove ref
        public static string Cut(ref string input, int idx)
        {
            int length = GetSubTreeLength(input,idx);
            string res = input.Substring(idx,length);

            input = input.Remove(idx,length);

            return res;
        }

        public static ReadOnlySpan<char> Cut(ref ReadOnlySpan<char> input, int idx)
        {
            int length = GetSubTreeLength(input,idx);
            var res = input.Slice(idx,length);

            input = string.Concat(res.Slice(0,idx),res.Slice(idx+length,res.Length-idx-length));

            return res;
        }

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

        public static int GetSubTreeLength(ReadOnlySpan<char> input, int startIndex)
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


        #region previso method
        // public static StringBuilder Cut(StringBuilder input, int idx)
        // {
        //     StringBuilder res = new StringBuilder();
        //     Stack<bool> mystack = new Stack<bool>();
      
        //     //left procesado -> f
        //     //right procesado -> t
        //     for (int i = idx; i < input.Length; i++)
        //     {
        //         res.Append(input[i]);
                
        //         //if (input.Length == 0)
        //         //    break;
        //         if (input[i] > 90)
        //         {
        //             input.Remove(i--, 1);

        //             if (mystack.Count == 0)
        //                 return res;
                    
        //             //es una variable
        //             if (mystack.Peek() == false)
        //             {
        //                 mystack.Pop();
        //                 mystack.Push(true);
        //             }
        //             else
        //                 while (mystack.Count > 0 && mystack.Peek() == true)
        //                     mystack.Pop();

        //             if (mystack.Count == 0)
        //                 return res;
        //         }
        //         else
        //         {
        //             //es un operador
        //             if (!input[i].Equals('N'))
        //                 mystack.Push(false);
        //             input.Remove(i--, 1);
        //         }
        //     }

        //     return res;

        // }


        // public static string Cut(ref string input, int idx)
        // {
        //     string res = "";
        //     Stack<bool> mystack = new Stack<bool>();
      
        //     //left procesado -> f
        //     //right procesado -> t
        //     for (int i = idx; i < input.Length; i++)
        //     {
        //         res += input[i];
                
        //         //if (input.Length == 0)
        //         //    break;
        //         if (input[i] > 90)
        //         {
        //             input = input.Remove(i--, 1);

        //             if (mystack.Count == 0)
        //                 return res;
                    
        //             //es una variable
        //             if (mystack.Peek() == false)
        //             {
        //                 mystack.Pop();
        //                 mystack.Push(true);
        //             }
        //             else
        //                 while (mystack.Count > 0 && mystack.Peek() == true)
        //                     mystack.Pop();

        //             if (mystack.Count == 0)
        //                 return res;
        //         }
        //         else
        //         {
        //             //es un operador
        //             if (!input[i].Equals('N'))
        //                 mystack.Push(false);
        //             input = input.Remove(i--, 1);
        //         }
        //     }

        //     return res;

        // }
        #endregion
    }
}
