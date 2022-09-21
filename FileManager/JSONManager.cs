using REST_API_MECATEC.DataBase;

namespace REST_API_MECATEC.FileManager; 

using Newtonsoft.Json;
using System.Text.Json;

public sealed class JSONManager {
    
    private static JSONManager _instance;

    public List<EmployeeObj> employeeList;
    public List<ClientObj> clientList;
    public List<LoginObj> loginList;

    public static JSONManager GetInstance() {
        if (_instance == null)
            _instance = new JSONManager();
        return _instance;
    }

    public JSONManager() {

        string loginInfo = readWrite.ReadFile("DataBase/loginInfo.json"),
                clientInfo = readWrite.ReadFile("DataBase/clients.json") , 
                employeeInfo = readWrite.ReadFile("DataBase/employee.json");

        loginList   = JsonConvert.DeserializeObject<List<LoginObj>>(loginInfo);
        clientList  = JsonConvert.DeserializeObject<List<ClientObj>>(clientInfo);
        employeeList = JsonConvert.DeserializeObject<List<EmployeeObj>>(employeeInfo);

    }

    public LoginObj getLogin(string username) {
        for (int i = 0; i < loginList.Count; i++)
            if (loginList[i].Equals(username))
                return loginList[i];
        return new LoginObj();
    }

    public EmployeeObj getEmployee(string username) {

        for (int i = 0; i < employeeList.Count ; i++)
            if (employeeList[i].email.Equals(username))
                return employeeList[i];
        return new EmployeeObj();

    }
    
    public ClientObj getClient(string username) {
        
        for (int i = 0; i < clientList.Count ; i++)
            if (clientList[i].email.Equals(username))
                return clientList[i];
        return new ClientObj();

    }

    public string login(string username, string password) {

        for (int i = 0; i < loginList.Count; i++) {
            if (loginList[i].email.Equals(username) &&
                loginList[i].password.Equals(password)) {

                if (username.Contains("mecatec.com")) {
                    return System.Text.Json.JsonSerializer.Serialize(getEmployee(username));
                }
                return System.Text.Json.JsonSerializer.Serialize(getClient(username));
            }
        }

        return string.Empty;

    }

    public void setClientEmail(string username, string newEmail) {
        getClient(username).email = newEmail;
        getLogin(username).email = newEmail;
    }
    
    public void setClientPassword(string username, string newPassword) {
        getClient(username).password = newPassword;
        getLogin(username).password = newPassword;
    }
    
    public void setClientFirstName(string username, string newName) {
        getClient(username).firstName = newName;
    }
    
    public void setClientLastName(string username, string newLastName) {
        getClient(username).lastName = newLastName;
    }
    
    public void setClientID(string username, int newID) {
        getClient(username).ID = newID;
    }
    
    public void setClientPhone(string username, int newPhone) {
        getClient(username).ID = newPhone;
    }
    
    public void setClientInfo(string username, string newInfo) {
        getClient(username).info = newInfo;
    }
    
    public void setClientZipCode(string username, int newZipCode) {
        getClient(username).zipCode = newZipCode;
    }

    public void setEmployeeEmail(string username, string newEmail) {
        getEmployee(username).email = newEmail;
        getLogin(username).email = newEmail;

    }
    
    public void setEmployeePassword(string username, string newPassword) {
        getEmployee(username).password = newPassword;
        getLogin(username).password = newPassword;
    }

    public void setEmployeeFirstName(string username, string newFirstName) {
        getEmployee(username).firstName = newFirstName;
    }

    public void setEmployeeLastName(string username, string newLastName) {
        getEmployee(username).lastName = newLastName;
    }
    
    public void setEmployeeID(string username, int newID) {
        getEmployee(username).ID = newID;
    }

    public void setEmployeeStartingDate(string username, string newStartingDate) {
        getEmployee(username).startingDate = newStartingDate;
    }
    
    public void setEmployeeBirthDate(string username, string newBirthDate) {
        getEmployee(username).birthDate = newBirthDate;
    }
    
    public void setEmployeeAge(string username, int newAge) {
        getEmployee(username).age = newAge;
    }
    
    public void setEmployeeRoll(string username, string newRoll) {
        getEmployee(username).roll = newRoll;
    }

    public void addClient(string clientJson) {
        ClientObj newClient = JsonConvert.DeserializeObject<ClientObj>(clientJson);
        if (newClient != null) clientList.Add(newClient);

        LoginObj loginObj = new LoginObj();
        loginObj.email = newClient.email;
        loginObj.password = newClient.password;
        
        loginList.Add(loginObj);

    }
    
    public void addEmployee(string employeeJson) {
        EmployeeObj newEmployee = JsonConvert.DeserializeObject<EmployeeObj>(employeeJson);
        if (newEmployee != null) employeeList.Add(newEmployee);

        LoginObj loginObj = new LoginObj();
        loginObj.email = newEmployee.email;
        loginObj.password = newEmployee.password;
        
        loginList.Add(loginObj);

    }

    public void saveInfo() {
        readWrite.WriteFile(System.Text.Json.JsonSerializer.Serialize(loginList),"DataBase/loginInfo.json");
        readWrite.WriteFile(System.Text.Json.JsonSerializer.Serialize(employeeList),"DataBase/employee.json");
        readWrite.WriteFile(System.Text.Json.JsonSerializer.Serialize(clientList),"DataBase/clients.json");
    }
}


class Program {
    public static void Main() { }
}