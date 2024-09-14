using System.Collections.Generic;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;

namespace ConsoleApp3
{
    public class Escenario
    {
        // Diccionario que almacena figuras 3D usando un identificador único
        private Dictionary<string, Figura3D> figuras;
        public Color4 FondoColor { get; set; }
        private PlanoCartesiano plano = new PlanoCartesiano(0.1, 0.02);

        public Escenario(Color4 fondoColor)
        {
            figuras = new Dictionary<string, Figura3D>();
            FondoColor = fondoColor;
        }

        // Método para agregar una figura al escenario
        public void AgregarFigura(string id, Figura3D figura)
        {
            if (figura != null)
            {
                figuras[id] = figura;  // Agrega o actualiza la figura con la clave dada
                Console.WriteLine($"Figura agregada con ID: {id}");
            }
            else
            {
                Console.WriteLine("Error: La figura es nula y no se puede agregar.");
            }
        }


        // Método para eliminar una figura
        public bool EliminarFigura(string id)
        {
            return figuras.Remove(id);  // Elimina la figura por su clave
        }

        // Método para obtener una figura por su id
        public Figura3D ObtenerFigura(string id)
        {
            if (figuras.ContainsKey(id))
            {
                return figuras[id];
            }
            return null; // Retorna null si la figura no existe
        }

        // Método para dibujar todas las figuras del escenario
        public void Dibujar()
        {
            GL.ClearColor(FondoColor);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            // Dibujar el plano cartesiano
            plano.Dibujar();

            // Dibujar todas las figuras en el diccionario
            foreach (var figura in figuras.Values)
            {
                if (figura != null)
                {
                    figura.Dibujar();
                }
                else
                {
                    Console.WriteLine("Error: Figura nula encontrada en el escenario.");
                }
            }
        }


        // Método para trasladar todas las figuras
        public void TrasladarTodas(UncPunto traslacion)
        {
            foreach (var figura in figuras.Values)
            {
                figura.Trasladar(traslacion);
            }
        }

        // Método para escalar todas las figuras
        public void EscalarTodas(double factor, UncPunto centro)
        {
            foreach (var figura in figuras.Values)
            {
                figura.Escalar(factor, centro);
            }
        }

        // Método para rotar todas las figuras
        public void RotarTodas(double anguloX, double anguloY, double anguloZ, UncPunto centro)
        {
            foreach (var figura in figuras.Values)
            {
                figura.Rotar(anguloX, anguloY, anguloZ, centro);
            }
        }

        // Método para cargar una figura deserializada al escenario
        public void CargarFiguraDeserializada(string nombre, string path = @"C:\ruta\por\defecto\")
        {
            UncObjeto figuraCargada = UncObjeto.Deserializar(nombre, path);
            if (figuraCargada != null)
            {
                AgregarFigura(nombre, figuraCargada);
            }
            else
            {
                Console.WriteLine("Error: No se pudo cargar la figura.");
            }
        }
    }
}
