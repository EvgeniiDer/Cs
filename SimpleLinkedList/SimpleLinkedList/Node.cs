using System.Dynamic;
using System.Runtime.InteropServices.ObjectiveC;
using System.Collections;

namespace SimpleLinkedList{

    class Node<T> 
    {
        T Data{get;} 
        public Node<T> nextNode{get; set;}
        public Node(T _Data)
        {
            this.Data = _Data;
        }
        public T getData()
        {
            return this.Data;
        }



    }
}
