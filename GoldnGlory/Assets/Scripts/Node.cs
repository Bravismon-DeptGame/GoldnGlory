using UnityEngine;

[System.Serializable]
public class Node {
    private Datas Data;
    private Node Previous;
    private Node[] Pointer;

    public Node(Datas Data, bool doublePointer)
    {
        if (doublePointer) Pointer = new Node[2];
        else Pointer = new Node[1];
        this.Data = Data;
    }

    public void changePointer(int size)
    {
        Pointer = new Node[size];
    }

    public Datas data
    {
        get
        {
            return Data;
        }

        set
        {
            Data = value;
        }
    }

    public Node previous
    {
        get
        {
            return Previous;
        }

        set
        {
            Previous = value;
        }
    }

    public Node pointer
    {
        get
        {
            return Pointer[0];
        }
        set
        {
            Pointer[0] = value;
        }
    }

    public Node leftPointer
    {
        get
        {
            return Pointer[0];
        }
        set
        {
            Pointer[0] = value;
        }
    }

    public Node rightPointer
    {
        get
        {
            return Pointer[1];
        }
        set
        {
            Pointer[1] = value;
        }
    }

    public int getPointer()
    {
        return Pointer.Length;
    }

    public Node[] allPointer
    {
        get
        {
            return Pointer;
        }
        set
        {
            Pointer = value;
        }
    }
}
