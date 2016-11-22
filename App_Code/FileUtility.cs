using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Web;

/// <summary>
/// Summary description for FileUtility
/// </summary>
public class FileUtility
{
    //write method
    public static void WriteFile(ArrayList a, string filename)
    {
        //make filestream path, create file, writefile
        FileStream fs = new FileStream(filename, FileMode.Create, FileAccess.Write, FileShare.None);
        //used for transformation between objects and binary data
        BinaryFormatter bf = new BinaryFormatter();
        //Serializing
        bf.Serialize(fs, a);
        //clean up
        fs.Close();
    }

    //read method
    public static ArrayList ReadFile(string filename)
    {
        FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.None);
        ///used for transformation between objects and binary data
        BinaryFormatter bf = new BinaryFormatter();
        //Deserialize
        ArrayList a = (ArrayList)bf.Deserialize(fs);
        //clean up
        fs.Close();

        return a;
    }
}