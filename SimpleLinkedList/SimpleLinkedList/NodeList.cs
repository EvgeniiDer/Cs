

using System.Collections;
using System.Diagnostics.Tracing;
using System.Reflection.Metadata;
using System.Text.RegularExpressions;


namespace SimpleLinkedList{
    class ForwardList<T> : IEnumerable
        {
            private Node<T> Head{get;set;}
            private Node<T> LastNode{get; set;}
            public ForwardList(params T[] elements)
            {
                /*for(int i = 0; i < elements.Length ; i++)
                    {
                        push_back(elements[i]);
                    }*/
                foreach(var temp in elements)
                {
                    push_back(temp);
                }
            }
        public void push_back(T _Data)
            {
                if(Head == null)
                    {
                        Head = new Node<T>(_Data);
                        Head.nextNode = null;
                        LastNode = Head;
                    }
                else{
                    Node<T> Current = Head;
                    while(Current.nextNode != null)
                        {
                            Current = Current.nextNode;
                        }
                    Current.nextNode = new Node<T>(_Data);
                    LastNode = Current.nextNode;
                }
            }
            public void push_front(T _Data)
            {
                if(Head == null)
                    {
                        Head = new Node<T>(_Data);
                    }
                else{
                    Node<T> newFrontElem = new Node<T>(_Data);
                    newFrontElem.nextNode = Head;
                    Head = newFrontElem;
                }
            }
            public void push_front2(T _Data)
            {
                Head = new Node<T>(_Data){
                    nextNode = Head
                };
            }
            public void erase(int _Index)
            {
                if(Head == null || _Index < 0)
                {
                    return;
                }else if(_Index == 0)
                {
                    Head = Head.nextNode;
                    return;
                }
                Node<T> Current = Head;
                int currentIndex = 0;
                while(Current != null && currentIndex < _Index - 1/*2*/)//Первой если отчет идет от 0 второй если отчет идет от 1
                {
                    Current = Current.nextNode;
                    currentIndex++;
                }
                if(Current != null && Current.nextNode != null)
                {
                    Current.nextNode = Current.nextNode.nextNode;
                }
            }
            public void insert(T _Data, int _index)
            {
                if(Head == null)
                {
                    push_back(_Data);
                }
                else{
                    Node<T> Current = Head;
                    for(int i = 0; i < _index - i; i++)
                        {
                            Current = Current.nextNode;
                        }
                    Node<T>newNode = new Node<T>(_Data);
                    newNode.nextNode = Current.nextNode;
                    Current.nextNode  = newNode;
                }    

            }
            public void pop_front()
            {
                if(Head == null)
                {
                    Console.WriteLine("List is empty");
                    return;
                }else
                    {   
                    Head = Head.nextNode;
                    }
            }
            public void pop_back()
            {
                if(Head == null)
                {   
                    Console.WriteLine("List is Empty");
                    return;
                }
                else if(Head.nextNode == null)
                {
                    pop_front();
                }
                else{
                    Node<T>Current = Head;
                    while(Current.nextNode.nextNode != null)
                        {
                            Current = Current.nextNode;
                        }
                    Current.nextNode = null;      
                }
            }
            public void Print()
            {
                if(Head == null)
                {
                    Console.WriteLine("List is empty");
                    return;
                }
                else{
                Node<T>iterator = Head;
                while(iterator != null)
                    {
                        string typeName = iterator.GetType().ToString();
                        string pattern = @"\[(.*?)\]";
                        Match match = Regex.Match(typeName, pattern);
                        string type = match.Groups[1].Value;
                        Console.WriteLine($"Type: {type} \t Data: {iterator.getData()}");
                        iterator = iterator.nextNode;
                    }
                }
            }
            public void Print2(Action<T> a)
            {
                Node<T> iterator = Head;
                while(iterator != null)
                    {
                        a(iterator.getData());
                        iterator = iterator.nextNode;
                    }
            }
            public void PrintForeach(ForwardList<T> _List)
            {
                foreach(var temp in _List)
                {
                    Console.WriteLine(temp);
                }
            }
            public void Clear()
            {
                    while(Head.nextNode != null)
                    {
                        pop_back();
                    }
                    Head = null;
            }

        public IEnumerator GetEnumerator()
        {
            return new Enumerator<T>(Head);
            /*Node<T> iterator = Head;
            while(iterator != null)
            {
                yield return iterator.getData(); // Выплевывает значение и потом обратно возвращеться в эту функцию
                iterator = iterator.nextNode;
            }*/
        }
        public void Add(T _Data) => push_back(_Data);
    }


}
