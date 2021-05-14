using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;
using System.Linq;
public class CSVReader : MonoBehaviour
{
    [Header("CSV Files")]
    [SerializeField] private TextAsset _levelCsvFile = null;

    #region For CSV read
    static string SPLIT_RE = @",(?=(?:[^""]*""[^""]*"")*(?![^""]*""))";
    static string LINE_SPLIT_RE = @"\r\n|\n\r|\n|\r";
    static char[] TRIM_CHARS = { '\"' };
    #endregion

    // private List<Item> readItem()
    // {
    //     var lines = Regex.Split(_itemCsvFile.text, LINE_SPLIT_RE);
    //     List<Item> list = new List<Item>();

    //     if (lines.Length <= 1) return null;

    //     var header = Regex.Split(lines[0], SPLIT_RE);
    //     for (var i = 1; i < lines.Length; i++)
    //     {
    //         var values = Regex.Split(lines[i], SPLIT_RE);
    //         if (values.Length == 0 || values[0] == "") continue;

    //         Item entry = new Item(int.Parse(values[0]), values[1], values[2], int.Parse(values[3]), values[4]);
    //         list.Add(entry);
    //     }
    //     return list;
    // }
}