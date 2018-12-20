using UnityEngine;
using UnityEditor;
using System.IO;

public class FileHandler : MonoBehaviour
{
    //FileStream fileStream;
    //string path = "Assets/Resources/tutorial.txt";
    //private void Start()
    //{
    //    fileStream = new FileStream(@path,
    //                                   FileMode.OpenOrCreate,
    //                                   FileAccess.ReadWrite,
    //                                   FileShare.None);
    //}
    //[MenuItem("Tools/Write file")]
    //public void CompleteTutorial()
    //{
        

    //    //Write some text to the test.txt file
    //    if (!File.Exists(path))
    //    {
    //        File.Create(path);
    //        Debug.Log("Creating File");
    //    }
    //    File.WriteAllText(path, string.Empty);
    //    StreamWriter sw = File.AppendText(path);
    //    fileStream.Write("1");
    //    sw.WriteLine("1");
    //    sw.Close();

    //    //Re-import the file to update the reference in the editor
    //    AssetDatabase.ImportAsset(path);
    //    TextAsset asset = Resources.Load<TextAsset>("test");

    //    //Print the text from the file
    //    Debug.Log(asset.text);
    //}

    //[MenuItem("Tools/Read file")]
    //public bool ReadTutorial()
    //{
    //    bool returner = false;

    //    if (File.Exists(path))
    //    {
    //        //Read the text from directly from the test.txt file
    //        StreamReader reader = new StreamReader(path);
    //        if(reader.ReadToEnd() == "1")
    //        {
    //            returner = true;
    //        }
    //        reader.Close();
    //    }
    //    else
    //    {
    //        Debug.Log("File does not exist");
    //    }
    //    return returner;
    //}

}