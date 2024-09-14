using System;
using System.IO;
using System.Text.Json;

namespace ConsoleApp3.Serializacion
{
    public class Serializador
    {
        // Método para serializar un objeto UncObjeto y guardarlo en un archivo
        public void Serializar<T>(T objeto, string nombreArchivo, string path = @"C:\Users\Lenovo\Desktop\Universidad\6 Semestre\programacion grafica\practicas\Programacion-grafica-full-main")
        {
            try
            {
                string jsonString = JsonSerializer.Serialize(objeto);
                File.WriteAllText(Path.Combine(path, nombreArchivo + ".json"), jsonString);
                Console.WriteLine($"Objeto serializado correctamente en {Path.Combine(path, nombreArchivo)}.json");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error al serializar el objeto: " + e.Message);
            }
        }

        // Método para deserializar un objeto UncObjeto desde un archivo
        public T Deserializar<T>(string nombreArchivo, string path = @"C:\Users\Lenovo\Desktop\Universidad\6 Semestre\programacion grafica\practicas\Programacion-grafica-full-main")
        {
            try
            {
                string jsonString = File.ReadAllText(Path.Combine(path, nombreArchivo + ".json"));
                T objeto = JsonSerializer.Deserialize<T>(jsonString);
                Console.WriteLine("Objeto deserializado correctamente.");
                return objeto;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error al deserializar el objeto: " + e.Message);
                return default(T); // En caso de error, devuelve el valor por defecto del tipo T
            }
        }
    }
}
