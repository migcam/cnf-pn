using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pkg
{
    public class Negations
    {

        private static void SetChar(string input, int i, char character)
        {
            string beforei = "";
            string afteri = "";

            if (i > 0)
                beforei = input.Substring(0, i - 1);
            if (i < input.Length - 2)
                afteri = input.Substring(i + 1);

            input = beforei + character + afteri;
        }

        public static StringBuilder Delete_Negation(StringBuilder input)
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

            return input;
        }

        public static string Delete_Negation(string input)
        {
            // deletes double negations (!!)
            for (int i = 0; i < input.Length - 1;)
            {
                if (input[i].Equals('N') && input[i + 1].Equals('N'))
                    input = input.Remove(i, 1);
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

            for (int i = 1; i < input.Length; i++)
            {
                //if (input[i].Equals('N'))
                //    continue;

                if (mystack.Peek() == 0 || mystack.Peek() == 2)
                {
                    if (input[i - 1].Equals('N'))
                    {
                        if (input[i].Equals('D'))
                        {
                            SetChar(input, i, 'C');
                            input =  input.Remove(--i, 1);
                            mystack.Push(3);
                        }
                        else if (input[i].Equals('C'))
                        {
                            SetChar(input, i, 'D');
                            input = input .Remove(--i, 1);
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

                        if (input[i].Equals('C') || input[i].Equals('D'))
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
                            SetChar(input, i, 'D');
                            mystack.Push(3);
                        }
                        else if (input[i].Equals('D'))
                        {
                            SetChar(input, i, 'C');
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


    }
}
