using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Formation", menuName = "Formation")]
public class Formation : ScriptableObject{

    public static int maxRows = 3;
    public List<string> row0;
    public List<string> row1;
    public List<string> row2;
    public List<string>[] allRows;

    public void Build ()
    {
       allRows = new List<string>[] { row0, row1, row2 };
    }
}
