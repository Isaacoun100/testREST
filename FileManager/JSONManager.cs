namespace REST_API_MECATEC.FileManager; 

using System.Text.Json;

public sealed class JSONManager {
    
    private JsonElement loginInfo, client, employee;
    private static JSONManager _instance;
    
    public static JSONManager GetInstance() {
        if (_instance == null)
            _instance = new JSONManager();
        return _instance;
    }

    public JSONManager() {
        
        loginInfo   = loadJSON(readWrite.ReadFile("DataBase/loginInfo.json"));
        client      = loadJSON(readWrite.ReadFile("DataBase/clients.json"));
        employee    = loadJSON(readWrite.ReadFile("DataBase/employee.json"));
        
    }

    private JsonElement loadJSON(string text) {
        JsonDocument doc = JsonDocument.Parse(text);
        JsonElement root = doc.RootElement;
        return root;
    }

    public JsonElement getEmployee(string username) {
        for (int i = 0; i < employee.GetArrayLength(); i++)
            if (employee[i].GetProperty("email").ToString().Equals(username))
                return employee[i];
        return new JsonElement();
    }
    
    public JsonElement getClient(string username) {
        for (int i = 0; i < client.GetArrayLength(); i++)
            if (client[i].GetProperty("email").ToString().Equals(username))
                return client[i];
        return new JsonElement();
    }

    public JsonElement login(string username, string password) {

        for (int i = 0; i < loginInfo.GetArrayLength(); i++) {
            if (loginInfo[i].GetProperty("email").ToString().Equals(username) &&
                loginInfo[i].GetProperty("password").ToString().Equals(password)) {
                
                if (username.Contains("mecatec.com"))
                    return getEmployee(username);
                return getClient(username);

            }
        }
        return new JsonElement();

    }

    public void setClientEmail(string username, string newEmail) {

        JsonElement clientJSON = getClient(username);
        
        clientJSON.
        
    }

}

class Program {
    public static void Main() { }
}