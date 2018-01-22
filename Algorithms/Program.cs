using System;
using System.Collections;
using System.Collections.Generic;

namespace Algorithms
{
        public class Node<T>    // класс узла, который будет представлять одиночный объект в списке
        {
            public Node(T data)
            {
                Data = data;
            }
            public T Data { get; set; }         // Для хранения данных
            public Node<T> Next { get; set; }   //Для ссылки на следующий узел
        }

        public class LinkedList<T> : IEnumerable<T>  // односвязный список
        {
            Node<T> head; // головной/первый элемент
            Node<T> tail; // последний/хвостовой элемент
            int count;  // количество элементов в списке

            // добавление элемента
            public void Add(T data)
            {
                Node<T> node = new Node<T>(data);

                if (head == null)
                    head = node;
                else
                    tail.Next = node;
                tail = node;

                count++;
            }
            // удаление элемента
            public bool Remove(T data)
            {
                Node<T> current = head;
                Node<T> previous = null;

                while (current != null)
                {
                    if (current.Data.Equals(data))
                    {
                        // Если узел в середине или в конце
                        if (previous != null)
                        {
                            // убираем узел current, теперь previous ссылается не на current, а на current.Next
                            previous.Next = current.Next;

                            // Если current.Next не установлен, значит узел последний,
                            // изменяем переменную tail
                            if (current.Next == null)
                                tail = previous;
                        }
                        else
                        {
                            // если удаляется первый элемент
                            // переустанавливаем значение head
                            head = head.Next;

                            // если после удаления список пуст, сбрасываем tail
                            if (head == null)
                                tail = null;
                        }
                        count--;
                        return true;
                    }

                    previous = current;
                    current = current.Next;
                }
                return false;
            }

            public int Count { get { return count; } }
            public bool IsEmpty { get { return count == 0; } }
            // очистка списка
            public void Clear()
            {
                head = null;
                tail = null;
                count = 0;
            }
            // содержит ли список элемент
            public bool Contains(T data)
            {
                Node<T> current = head;
                while (current != null)
                {
                    if (current.Data.Equals(data))
                        return true;
                    current = current.Next;
                }
                return false;
            }
            // добвление в начало
            public void AppendFirst(T data)
            {
                Node<T> node = new Node<T>(data);
                node.Next = head;
                head = node;
                if (count == 0)
                    tail = head;
                count++;
            }
            // реализация интерфейса IEnumerable
            IEnumerator IEnumerable.GetEnumerator()
            {
                return ((IEnumerable)this).GetEnumerator();
            }

            IEnumerator<T> IEnumerable<T>.GetEnumerator()
            {
                Node<T> current = head;
                while (current != null)
                {
                    yield return current.Data;
                    current = current.Next;
                }
            }
        }
	//}

	public class DoublyNode<T>
	{
		public DoublyNode(T data)
		{
			Data = data;
		}
		public T Data { get; set; }
		public DoublyNode<T> Previous { get; set; }
		public DoublyNode<T> Next { get; set; }
	}

	public class DoublyLinkedList<T> : IEnumerable<T>  // двусвязный список
	{
		DoublyNode<T> head; // головной/первый элемент
		DoublyNode<T> tail; // последний/хвостовой элемент
		int count;  // количество элементов в списке

		// добавление элемента
		public void Add(T data)
		{
			DoublyNode<T> node = new DoublyNode<T>(data);

			if (head == null)
				head = node;
			else
			{
				tail.Next = node;
				node.Previous = tail;
			}
			tail = node;
			count++;
		}
		public void AddFirst(T data)
		{
			DoublyNode<T> node = new DoublyNode<T>(data);
			DoublyNode<T> temp = head;
			node.Next = temp;
			head = node;
			if (count == 0)
				tail = head;
			else
				temp.Previous = node;
			count++;
		}
		// удаление
		public bool Remove(T data)
		{
			DoublyNode<T> current = head;

			// поиск удаляемого узла
			while (current != null)
			{
				if (current.Data.Equals(data))
				{
					break;
				}
				current = current.Next;
			}
			if (current != null)
			{
				// если узел не последний
				if (current.Next != null)
				{
					current.Next.Previous = current.Previous;
				}
				else
				{
					// если последний, переустанавливаем tail
					tail = current.Previous;
				}

				// если узел не первый
				if (current.Previous != null)
				{
					current.Previous.Next = current.Next;
				}
				else
				{
					// если первый, переустанавливаем head
					head = current.Next;
				}
				count--;
				return true;
			}
			return false;
		}

		public int Count { get { return count; } }
		public bool IsEmpty { get { return count == 0; } }

		public void Clear()
		{
			head = null;
			tail = null;
			count = 0;
		}

		public bool Contains(T data)
		{
			DoublyNode<T> current = head;
			while (current != null)
			{
				if (current.Data.Equals(data))
					return true;
				current = current.Next;
			}
			return false;
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable)this).GetEnumerator();
		}

		IEnumerator<T> IEnumerable<T>.GetEnumerator()
		{
			DoublyNode<T> current = head;
			while (current != null)
			{
				yield return current.Data;
				current = current.Next;
			}
		}

		public IEnumerable<T> BackEnumerator()
		{
			DoublyNode<T> current = tail;
			while (current != null)
			{
				yield return current.Data;
				current = current.Previous;
			}
		}
	}


	/*public class FixedStack<T>
	{
		private T[] items; // элементы стека
		private int count;  // количество элементов
		const int n = 10;   // количество элементов в массиве по умолчанию
		public FixedStack()
		{
			items = new T[n];
		}
		public FixedStack(int length)
		{
			items = new T[length];
		}
		// пуст ли стек
		public bool IsEmpty
		{
			get { return count == 0; }
		}
		// размер стека
		public int Count
		{
			get { return count; }
		}
		// добвление элемента
		public void Push(T item)
		{
			// если стек заполнен, выбрасываем исключение
			if (count == items.Length)
				throw new InvalidOperationException("Переполнение стека");
			items[count++] = item;
		}
		// извлечение элемента
		public T Pop()
		{
			// если стек пуст, выбрасываем исключение
			if (IsEmpty)
				throw new InvalidOperationException("Стек пуст");
			T item = items[--count];
			items[count] = default(T); // сбрасываем ссылку
			return item;
		}
		// возвращаем элемент из верхушки стека
		public T Peek()
		{
			return items[count - 1];
		}
	}*/

	public class Nodes<T>
	{
		public Nodes(T data)
		{
			Data = data;
		}
		public T Data { get; set; }
		public Node<T> Next { get; set; }
	}

	public class NodeStack<T> : IEnumerable<T>
	{
		Node<T> head;
		int count;

		public bool IsEmpty
		{
			get { return count == 0; }
		}
		public int Count
		{
			get { return count; }
		}

		public void Push(T item)
		{
			// увеличиваем стек
			Node<T> node = new Node<T>(item);
			node.Next = head; // переустанавливаем верхушку стека на новый элемент
			head = node;
			count++;
		}
		public T Pop()
		{
			// если стек пуст, выбрасываем исключение
			if (IsEmpty)
				throw new InvalidOperationException("Стек пуст");
			Node<T> temp = head;
			head = head.Next; // переустанавливаем верхушку стека на следующий элемент
			count--;
			return temp.Data;
		}
		public T Peek()
		{
			if (IsEmpty)
				throw new InvalidOperationException("Стек пуст");
			return head.Data;
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable)this).GetEnumerator();
		}

		IEnumerator<T> IEnumerable<T>.GetEnumerator()
		{
			Node<T> current = head;
			while (current != null)
			{
				yield return current.Data;
				current = current.Next;
			}
		}
	}

	class MainClass
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
			LinkedList<string> linkedList = new LinkedList<string>();
			// добавление элементов
			linkedList.Add("Tom");
			linkedList.Add("Alice");
			linkedList.Add("Bob");
			linkedList.Add("Sam");

			// выводим элементы
			foreach (var item in linkedList)
			{
				Console.WriteLine(item);
			}
			// удаляем элемент
			linkedList.Remove("Alice");
			foreach (var item in linkedList)
			{
				Console.WriteLine(item);
			}
			// проверяем наличие элемента
			bool isPresent = linkedList.Contains("Sam");
			Console.WriteLine(isPresent == true ? "Sam присутствует" : "Sam отсутствует");

			// добавляем элемент в начало            
			linkedList.AppendFirst("Bill");
			foreach (var item in linkedList)
			{
				Console.WriteLine(item);
			}

            Console.WriteLine("\n");

            DoublyLinkedList<string> linkedList2 = new DoublyLinkedList<string>();
			// добавление элементов
			linkedList2.Add("Bob");
			linkedList2.Add("Bill");
			linkedList2.Add("Tom");
			linkedList2.AddFirst("Kate");
			foreach (var item in linkedList2)
			{
				Console.WriteLine(item);
			}
			// удаление
			linkedList2.Remove("Bill");

			// перебор с последнего элемента
			foreach (var t in linkedList2.BackEnumerator())
			{
				Console.WriteLine(t);
			}

			
            Console.WriteLine("\n");

            /*try
			{
				FixedStack<string> stack = new FixedStack<string>(8);
				// добавляем четыре элемента
				stack.Push("Kate");
				stack.Push("Sam");
				stack.Push("Alice");
				stack.Push("Tom");

				// извлекаем один элемент
				var head = stack.Pop();
				Console.WriteLine(head);    // Tom

				// просто получаем верхушку стека без извлечения
				head = stack.Peek();
				Console.WriteLine(head);    // Alice
			}
			catch (InvalidOperationException ex)
			{
				Console.WriteLine(ex.Message);
			}*/

			NodeStack<string> stack = new NodeStack<string>();
			stack.Push("Tom");
			stack.Push("Alice");
			stack.Push("Bob");
			stack.Push("Kate");

			foreach (var item in stack)
			{
				Console.WriteLine(item);
			}
			Console.WriteLine();
			string header = stack.Peek();
			Console.WriteLine($"Верхушка стека: {header}");
			Console.WriteLine();

			header = stack.Pop();
			foreach (var item in stack)
			{
				Console.WriteLine(item);
			}

		}
    }
}
