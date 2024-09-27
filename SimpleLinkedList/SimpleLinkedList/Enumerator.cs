using System.Collections;
using System.Diagnostics.CodeAnalysis;
namespace SimpleLinkedList{

public class Enumerator<T> : IEnumerator
    {
        private Node<T>Head{get; set;}
        private Node<T>Temp{get; set;}
        public Enumerator(object Head)
        {
            this.Head = (Node<T>)Head;         
            this.Temp = null;

        }
        public object Current{get => Temp.getData();}
        public bool MoveNext()
        {
            Temp = Temp == null ? Head : Temp.nextNode;
            return Temp != null;
        }
        public void Reset(){
            Temp = null;
        }
    }



}
