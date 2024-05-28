using System.Collections.Generic;
using System;

public class MuayeneHeap
{
	private List<Hasta> heap;

	public MuayeneHeap()
	{
		heap = new List<Hasta>();
	}

	public void Ekle(Hasta yeniHasta)
	{
		heap.Add(yeniHasta);
		int i = heap.Count - 1;

		while (i > 0 && heap[(i - 1) / 2].OncelikPuani < heap[i].OncelikPuani)
		{
			var temp = heap[(i - 1) / 2];
			heap[(i - 1) / 2] = heap[i];
			heap[i] = temp;
			i = (i - 1) / 2;
		}
	}

	public Hasta Cikar()
	{
		if (heap.Count == 0) throw new InvalidOperationException("Heap boş.");

		var root = heap[0];
		heap[0] = heap[heap.Count - 1];
		heap.RemoveAt(heap.Count - 1);

		Heapify(0);
		return root;
	}

	public bool BosMu()
	{
		return heap.Count == 0;
	}

	public List<Hasta> GetHeap()
	{
		return heap;
	}

	private void Heapify(int i)
	{
		int left = 2 * i + 1;
		int right = 2 * i + 2;
		int largest = i;

		if (left < heap.Count && heap[left].OncelikPuani > heap[largest].OncelikPuani)
		{
			largest = left;
		}

		if (right < heap.Count && heap[right].OncelikPuani > heap[largest].OncelikPuani)
		{
			largest = right;
		}

		if (largest != i)
		{
			var temp = heap[i];
			heap[i] = heap[largest];
			heap[largest] = temp;
			Heapify(largest);
		}
	}
}
