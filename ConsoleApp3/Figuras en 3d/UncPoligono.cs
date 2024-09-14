using System;
using System.Collections.Generic;
using System.Linq;
using ConsoleApp3;


using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;


namespace ConsoleApp3
{
    public class UncPoligono : Figura3D
    {
        public Dictionary<string, UncPunto> Vertices { get; private set; }
        public Color4 Color { get; set; }

        public UncPoligono(Color4 color)
        {
            Vertices = new Dictionary<string, UncPunto>();
            Color = color;
        }

        public void AñadirVertice(string id, UncPunto punto)
        {
            Vertices[id] = punto;
        }

        public bool EliminarVertice(string id)
        {
            return Vertices.Remove(id);
        }

        public UncPunto CalcularCentroDeMasa()
        {
            if (Vertices.Count == 0)
                return new UncPunto();

            double xProm = Vertices.Values.Average(v => v.X);
            double yProm = Vertices.Values.Average(v => v.Y);
            double zProm = Vertices.Values.Average(v => v.Z);

            return new UncPunto(xProm, yProm, zProm);
        }

        public override void Trasladar(UncPunto traslacion)
        {
            foreach (var vertice in Vertices.Values)
            {
                vertice.Trasladar(traslacion);
            }
        }

        public override void Escalar(double factor, UncPunto centro)
        {
            foreach (var vertice in Vertices.Values)
            {
                vertice.Escalar(factor, centro);
            }
        }

        public override void Rotar(double anguloX, double anguloY, double anguloZ, UncPunto centro)
        {
            foreach (var vertice in Vertices.Values)
            {
                vertice.Rotar(anguloX, anguloY, anguloZ, centro);
            }
        }

        public override void Dibujar()
        {
            if (Vertices.Count < 3)
            {
                Console.WriteLine("El polígono no tiene suficientes vértices para ser dibujado.");
                return;
            }

            GL.Begin(PrimitiveType.Polygon);
            GL.Color4(Color);
            foreach (var vertice in Vertices.Values)
            {
                Console.WriteLine($"Dibujando vértice: X={vertice.X}, Y={vertice.Y}, Z={vertice.Z}");
                vertice.Dibujar();
            }
            GL.End();
        }

    }


}
