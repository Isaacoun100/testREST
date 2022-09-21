namespace REST_API_MECATEC.FileManager;

using System.IO;



public class readWrite {

    /**
     * This method will return a string with the contents of the specified location, if it doesn't find a valid readable
     * file in the given location it will return an empty JSON
     */
    public static string ReadFile(string path) {
        
        var str = "[]";
        if (File.Exists(path)) 
            str = File.ReadAllText(path);
        return str;
    }

    /**
     * This method will write the text in the contents variable into the specified path, the contents string must be a
     * JSON type string
     */
    public static void WriteFile(string contents, string path) {
        File.WriteAllText(path, contents);
    }
    
}


