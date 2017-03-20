using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PriorityQueue : MonoBehaviour {

	int count = 0;
	float[] keys;
	GameObject[] values;

	int getParent(int i)
	{
		return (i - 1) / 2;
	}

	int getLeft(int i)
	{
		return 2 * i + 1;
	}

	int getRight(int i)
	{
		return 2 * i + 2;
	}
    
    public int Count { get { return count; } }

	void heapifyUp(int i)
	{
		if (i <= 0) return;
		int j = getParent(i);

		//if child is less than parent, swap places and rearrange
		if (keys[i] < keys[j]) {
			//swap keys
			swap(i,j);
		}
		heapifyUp(j);
	}

	void heapifyDn(int i)
	{
		//index of second node
		int j;

		// If no children...
		if (getLeft(i) > count - 1) return;

		// If no right child...
		if (getRight(i) > count - 1) {
			j = getLeft(i);
		}
		else {
			// If both right and left children
			j = (keys[getLeft(i)] < keys[getRight(i)]) ? (getLeft(i)) : (getRight(i));
		}

		//swap
		if (keys[i] > keys[j]) {
			//swap keys
			swap(i, j);
		}

		heapifyDn(j);
	}

	void swap(int i, int j)
	{
		//swap keys
		float temp = keys[i];
		keys[i] = keys[j];
		keys[j] = temp;

		//swap values
		GameObject temp2 = values[i];
		values[i] = values[j];
		values[j] = temp2;
	}

	public GameObject pop()
	{
		if (count > 0) {
			//create a copy of the first
			GameObject tempVal = values[0];
			float tempKey = keys[0];

			//replace first with last
			keys[0] = keys[count - 1];
			values[0] = values[count - 1];

			//'remove' last element
			if (count > 0) count -= 1;

			//rearrange
			heapifyDn(0);

			//test
			Debug.Log( "removing: " + tempKey + " : " + tempVal.name + ", count = " + count);

			return tempVal;
		}
		//test
		Debug.Log("Queue is empty, cannot pop...");

		//Value null = Value();
		return null;
	}


	public void push(float newKey, GameObject val)
	{
		//add new key and value to next array slot
		keys[count] = newKey;
		values[count] = val;

		//test
		Debug.Log( "adding: " + newKey + " {" + val.name + ", count = " + count + "}" );

		//increase count and rearrange
		count += 1;
		heapifyUp(count - 1);
	}

    public bool Contains(GameObject val)
    {
        for (int i = 0; i < values.Length; i++)
        {
            if (values[i] == val)
                return true;
        }
        return false;
    }

    public GameObject Find(GameObject val)
    {
        for (int i = 0; i < values.Length; i++)
        {
            if (values[i] == val)
                return values[i];
        }
        return null;
    }
		

	// Use this for initialization
	public void Setup () {
		count = 0;
		keys = new float[100];
		values = new GameObject[100];
	}

}
