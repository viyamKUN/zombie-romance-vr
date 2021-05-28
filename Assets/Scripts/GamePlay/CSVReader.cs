using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;
using System.Linq;
using ConversationModles;
public class CSVReader : MonoBehaviour
{
    [Header("CSV Files")]
    [SerializeField] private TextAsset _levelCsvFile = null;
    [SerializeField] private TextAsset _conversationFile = null;

    #region For CSV read
    static string SPLIT_RE = @",(?=(?:[^""]*""[^""]*"")*(?![^""]*""))";
    static string LINE_SPLIT_RE = @"\r\n|\n\r|\n|\r";
    static char[] TRIM_CHARS = { '\"' };
    #endregion

    public List<Conversation> readConversation()
    {
        var lines = Regex.Split(_conversationFile.text, LINE_SPLIT_RE);
        List<Conversation> list = new List<Conversation>();

        if (lines.Length <= 1) return null;

        var header = Regex.Split(lines[0], SPLIT_RE);
        for (var i = 1; i < lines.Length; i++)
        {
            var values = Regex.Split(lines[i], SPLIT_RE);
            if (values.Length == 0 || values[0] == "") continue;

            Conversation entry = new Conversation(values[0], values[1], values[2], values[3], values[4]);
            list.Add(entry);
        }
        return list;
    }
}