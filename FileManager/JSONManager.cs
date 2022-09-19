namespace REST_API_MECATEC.FileManager; 

using System.Text.Json;

public class JSONManager {

    public static void Main() { }

    public JsonElement loadJSON(string text) {
        JsonDocument doc = JsonDocument.Parse(text);
        JsonElement root = doc.RootElement;
        return root;
    }
    
    
}