using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Test : MonoBehaviour
{
    public List<string> list1 = new List<string>() { "Empty", "a", "b", "ab" };
    public List<string> list2 = new List<string>() { "a", "b" };
    public List<string> list3 = new List<string>() { "a", "b", "c" };
    public List<List<string>> setFamily = new List<List<string>>() {
        new List<string>() {},
        new List<string>() {"a"},
        new List<string>() {"b"},
        new List<string>() {"a","b"}
    };

    public List<string> b = new List<string>();

    void Start()
    {
        var a = setFamily[1].Union(setFamily[0]);
        b = a.ToList();
        for (int i = 0; i < a.Count(); i++)
        {
            Debug.Log(b[i]);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
