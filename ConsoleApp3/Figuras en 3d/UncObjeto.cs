using ConsoleApp3;

using OpenTK.Graphics;
using System.Collections.Generic;
using System.Text.Json;

namespace ConsoleApp3
{
    public class UncObjeto : Figura3D
    {
        public Dictionary<string, UncParte> Partes { get; private set; }
        public Color4 Color { get; set; }
        private UncPunto centroDeMasa;

        public UncObjeto(Color4 color)
        {
            Partes = new Dictionary<string, UncParte>();
            Color = color;
            centroDeMasa = new UncPunto(0, 0, 0); // Centra el objeto en (0, 0, 0)
        }

        public void AñadirParte(string id, UncParte parte)
        {
            Partes[id] = parte;
        }

        public override void Trasladar(UncPunto traslacion)
        {
            foreach (var parte in Partes.Values)
            {
                parte.Trasladar(traslacion);
            }
        }

        public override void Escalar(double factor, UncPunto centro)
        {
            foreach (var parte in Partes.Values)
            {
                parte.Escalar(factor, centro);
            }
        }

        public override void Rotar(double anguloX, double anguloY, double anguloZ, UncPunto centro)
        {
            foreach (var parte in Partes.Values)
            {
                parte.Rotar(anguloX, anguloY, anguloZ, centroDeMasa);
            }
        }

        public override void Dibujar()
        {
            Console.WriteLine("Dibujando el objeto...");
            foreach (var parte in Partes.Values)
            {
                parte.Dibujar();
            }
        }
        // Método para serializar una figura (UncObjeto)
        public void Serializar(string nombre, string path = @"C:\ruta\por\defecto\")
        {
            string save = JsonSerializer.Serialize(this);
            path += nombre + ".json";
            try
            {
                File.WriteAllText(path, save);
                Console.WriteLine("Figura guardada correctamente");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error al guardar la figura: " + e.Message);
            }
        }

        // Método para deserializar una figura (UncObjeto)
        public static UncObjeto Deserializar(string nombre, string path = @"C:\ruta\por\defecto\")
        {
            UncObjeto objeto = null;
            path += nombre + ".json";
            try
            {
                string serie = File.ReadAllText(path);
                objeto = JsonSerializer.Deserialize<UncObjeto>(serie);
                Console.WriteLine("Figura cargada correctamente");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error al cargar la figura: " + e.Message);
            }
            return objeto;
        }
    }



}
