using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pkg
{
    public class Negations
    {
        // !p or q === !p and !q; 
        // !p and q === !p or !q
        public static void Delete_Negation(StringBuilder input)
        {
            // deletes double negations (!!)
            for (int i = 0; i < input.Length - 1;)
            {
                if (input[i].Equals('N') && input[i + 1].Equals('N'))
                    input.Remove(i, 1);
                else
                    i++;
            }

            Stack<int> mystack = new Stack<int>();
            
            /*
            0 = ambos procesados no cambios necesarios
            1 = ambos procesado cambios necesarios
            2 = hijo izquierdo procesado no cambios necesarios
            3 = hijo izquierdo procesado cambios necesarios
            */

            mystack.Push(0);

            for (int i = 1; i < input.Length ; i++)
            {
                //if (input[i].Equals('N'))
                //    continue;

                if (mystack.Peek() == 0 || mystack.Peek() == 2)
                {
                    if(input[i - 1].Equals('N'))
                    {
                        if(input[i].Equals('D'))
                        {
                            input[i] = 'C';
                            input.Remove(--i, 1);
                            mystack.Push(3);
                        }
                        else if(input[i].Equals('C'))
                        {
                            input[i] = 'D';
                            input.Remove(--i, 1);
                            mystack.Push(3);
                        }
                        else
                        {
                            if (mystack.Peek().Equals(2))
                            {
                                mystack.Pop();
                                mystack.Push(0);
                            }
                            else
                            {
                                while (mystack.Count > 0 && (mystack.Peek().Equals(0) || mystack.Peek().Equals(1)))
                                    mystack.Pop();
                                
                            }
                        }
                    }
                    else
                    {
                        mystack.Push(2);
                    }

                }
                else
                {
                    if (input[i - 1].Equals('N'))
                    {
                        input.Remove(--i, 1);

                        if(input[i].Equals('C') || input[i].Equals('D'))
                            mystack.Push(2);
                        else
                        {
                            mystack.Pop();
                            mystack.Push(1);
                        }
                    }
                    else
                    {
                        if (input[i].Equals('N'))
                            continue;
                        
                        if (input[i].Equals('C'))
                        {
                            input[i] = 'D';
                            mystack.Push(3);
                        }
                        else if (input[i].Equals('D'))
                        {
                            input[i] = 'C';
                            mystack.Push(3);
                        }
                        else
                        {
                            input.Insert(i++, 'N');

                            if (mystack.Peek().Equals(3))
                            {
                                mystack.Pop();
                                mystack.Push(1);
                            }
                            else
                            {
                                while (mystack.Count > 0 && (mystack.Peek().Equals(0) || mystack.Peek().Equals(1))) 
                                    mystack.Pop();
                                
                            }
                        }
                        
                    }
                }
            }

            // return input;
        }

        public static string Delete_Negation(string input)
        {
            // deletes double negations (!!)
            for (int i = 0; i < input.Length - 1;)
            {
                if (input[i].Equals('N') && input[i + 1].Equals('N'))
                    input  = input.Remove(i, 1);
                else
                    i++;
            }

            Stack<int> mystack = new Stack<int>();
            
            /*
            0 = ambos procesados no cambios necesarios
            1 = ambos procesado cambios necesarios
            2 = hijo izquierdo procesado no cambios necesarios
            3 = hijo izquierdo procesado cambios necesarios
            */

            mystack.Push(0);

            for (int i = 1; i < input.Length ; i++)
            {
                //if (input[i].Equals('N'))
                //    continue;

                if (mystack.Peek() == 0 || mystack.Peek() == 2)
                {
                    if(input[i - 1].Equals('N'))
                    {
                        if(input[i].Equals('D'))
                        {
                            // input[i] = 'C';
                            input = SetChar(input,i,'C');
                            input = input.Remove(--i, 1);
                            mystack.Push(3);
                        }
                        else if(input[i].Equals('C'))
                        {
                            // input[i] = 'D';
                            input  = SetChar(input,i,'D');
                            input = input.Remove(--i, 1);
                            mystack.Push(3);
                        }
                        else
                        {
                            if (mystack.Peek().Equals(2))
                            {
                                mystack.Pop();
                                mystack.Push(0);
                            }
                            else
                            {
                                while (mystack.Count > 0 && (mystack.Peek().Equals(0) || mystack.Peek().Equals(1)))
                                    mystack.Pop();
                                
                            }
                        }
                    }
                    else
                    {
                        mystack.Push(2);
                    }

                }
                else
                {
                    if (input[i - 1].Equals('N'))
                    {
                        input = input.Remove(--i, 1);

                        if(input[i].Equals('C') || input[i].Equals('D'))
                            mystack.Push(2);
                        else
                        {
                            mystack.Pop();
                            mystack.Push(1);
                        }
                    }
                    else
                    {
                        if (input[i].Equals('N'))
                            continue;
                        
                        if (input[i].Equals('C'))
                        {
                            // input[i] = 'D';
                            input = SetChar(input,i,'D');
                            mystack.Push(3);
                        }
                        else if (input[i].Equals('D'))
                        {
                            // input[i] = 'C';
                            input = SetChar(input,i,'C');
                            mystack.Push(3);
                        }
                        else
                        {
                            input = input.Insert(i++, "N");

                            if (mystack.Peek().Equals(3))
                            {
                                mystack.Pop();
                                mystack.Push(1);
                            }
                            else
                            {
                                while (mystack.Count > 0 && (mystack.Peek().Equals(0) || mystack.Peek().Equals(1))) 
                                    mystack.Pop();
                                
                            }
                        }
                        
                    }
                }
            }

            return input;
        }

        public static ReadOnlySpan<char> Delete_Negation(ReadOnlySpan<char> input)
        {
            // deletes double negations (!!)
            for (int i = 0; i < input.Length - 1;)
            {
                if (input[i].Equals('N') && input[i + 1].Equals('N'))
                    input  = input.Remove(i, 1);
                else
                    i++;
            }

            Stack<int> mystack = new Stack<int>();
            
            /*
            0 = ambos procesados no cambios necesarios
            1 = ambos procesado cambios necesarios
            2 = hijo izquierdo procesado no cambios necesarios
            3 = hijo izquierdo procesado cambios necesarios
            */

            mystack.Push(0);

            for (int i = 1; i < input.Length ; i++)
            {
                //if (input[i].Equals('N'))
                //    continue;

                if (mystack.Peek() == 0 || mystack.Peek() == 2)
                {
                    if(input[i - 1].Equals('N'))
                    {
                        if(input[i].Equals('D'))
                        {
                            // input[i] = 'C';
                            input = SetChar(input,i,'C');
                            input = input.Remove(--i, 1);
                            mystack.Push(3);
                        }
                        else if(input[i].Equals('C'))
                        {
                            // input[i] = 'D';
                            input  = SetChar(input,i,'D');
                            input = input.Remove(--i, 1);
                            mystack.Push(3);
                        }
                        else
                        {
                            if (mystack.Peek().Equals(2))
                            {
                                mystack.Pop();
                                mystack.Push(0);
                            }
                            else
                            {
                                while (mystack.Count > 0 && (mystack.Peek().Equals(0) || mystack.Peek().Equals(1)))
                                    mystack.Pop();
                                
                            }
                        }
                    }
                    else
                    {
                        mystack.Push(2);
                    }

                }
                else
                {
                    if (input[i - 1].Equals('N'))
                    {
                        input = input.Remove(--i, 1);

                        if(input[i].Equals('C') || input[i].Equals('D'))
                            mystack.Push(2);
                        else
                        {
                            mystack.Pop();
                            mystack.Push(1);
                        }
                    }
                    else
                    {
                        if (input[i].Equals('N'))
                            continue;
                        
                        if (input[i].Equals('C'))
                        {
                            // input[i] = 'D';
                            input = SetChar(input,i,'D');
                            mystack.Push(3);
                        }
                        else if (input[i].Equals('D'))
                        {
                            // input[i] = 'C';
                            input = SetChar(input,i,'C');
                            mystack.Push(3);
                        }
                        else
                        {
                            input = input.Insert(i++, "N");

                            if (mystack.Peek().Equals(3))
                            {
                                mystack.Pop();
                                mystack.Push(1);
                            }
                            else
                            {
                                while (mystack.Count > 0 && (mystack.Peek().Equals(0) || mystack.Peek().Equals(1))) 
                                    mystack.Pop();
                                
                            }
                        }
                        
                    }
                }
            }

            return input;
        }

        private static string SetChar(string input, int i, char character)
        {
            string beforei = "";
            string afteri = "";

            if (i > 0)
                beforei = input.Substring(0, i);
            if (i < input.Length - 2)
                afteri = input.Substring(i + 1);

            return beforei + character + afteri;
        }

        private static ReadOnlySpan<char> SetChar(ReadOnlySpan<char> input, int i, char character)
        {
            ReadOnlySpan<char> beforei = "";
            ReadOnlySpan<char> afteri = "";
            ReadOnlySpan<char> charSpan = character.ToString();

            if (i > 0)
                beforei = input.Slice(0, i);
            if (i < input.Length - 2)
                afteri = input.Slice(i + 1);

            // input = beforei + character + afteri;
            return string.Concat(beforei,charSpan,afteri);
        }

        


    }

    public static class Extension
    {
        public static ReadOnlySpan<char> Remove(this ReadOnlySpan<char> input, int idx, int length)
        {
           return string.Concat(input.Slice(0,idx),input.Slice(idx+length,input.Length-idx-length));
        }

        public static ReadOnlySpan<char> Insert(this ReadOnlySpan<char> input, int idx, string newStr)
        {
           return string.Concat(input.Slice(0,idx),newStr,input.Slice(idx,input.Length-idx));
        }

        public static ReadOnlySpan<char> Insert(this ReadOnlySpan<char> input, int idx, ReadOnlySpan<char> newStr)
        {
           return string.Concat(input.Slice(0,idx),newStr,input.Slice(idx,input.Length-idx));
        }
    }
}
