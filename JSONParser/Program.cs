using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;


string jsonData = File.ReadAllText(@"C:\Users\phlga\OneDrive\Documentos\dev\JSONParser\invalid.json");

if (IsValidJson(jsonData))
{
    Console.WriteLine("0");
}
else
{
    Console.WriteLine("1");
}



bool IsValidJson(string jsonString)
{
    
        jsonString = jsonString.Trim();

        if (jsonString.StartsWith("{") && jsonString.EndsWith("}"))
        {
            jsonString = jsonString.Substring(1, jsonString.Length - 2).Trim();
            
            string[] keyValuePairs = jsonString.Split(',');

            foreach (var pair in keyValuePairs)
            {
                string[] parts = pair.Split(":");
                if (parts.Length != 2)
                {
                    return false;
                }
                string key = parts[0].Trim();
                string value = parts[1].Trim();

                
                if (!key.StartsWith("\"") || !key.EndsWith("\"") || !value.StartsWith("\"") || !value.EndsWith("\""))
                {
                    return false;
                }  
            }

            return true;
        }

        return true;
   
}