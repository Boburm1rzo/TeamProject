
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
namespace TeamProject;

internal static class WorkingWithFile
{
    public static async Task<List<HouseData>> ReadToFile()
    {
        using (StreamReader reader = new StreamReader(@"D:\С# .net   PDP\G5\modul_4\TeamProject\Data.json"))
        {
            string data = await reader.ReadToEndAsync();
            List<HouseData>? datas = JsonSerializer.Deserialize<List<HouseData>>(data);
            return datas;
        }
    }
    public static async Task WriteToFile(List<HouseData> datas)
    {
        using (StreamWriter writer = new StreamWriter(@"D:\С# .net   PDP\G5\modul_4\TeamProject\Data.json"))
        {
            JsonSerializerOptions options = new JsonSerializerOptions()
            {
                WriteIndented = true
            };
            string data = JsonSerializer.Serialize(datas, options);
            await writer.WriteAsync(data);
        }
    }
   
}
