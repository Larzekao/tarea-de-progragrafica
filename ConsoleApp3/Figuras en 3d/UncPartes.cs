using ConsoleApp3;

using OpenTK.Graphics;
using System.Collections.Generic;

namespace ConsoleApp3
{
    public class UncParte : Figura3D
    {
        public Dictionary<string, UncPoligono> Poligonos { get; private set; }
        public Color4 Color { get; set; }

        public UncParte(Color4 color)
        {
            Poligonos = new Dictionary<string, UncPoligono>();
            Color = color;
        }

        public void AñadirPoligono(string id, UncPoligono poligono)
        {
            Poligonos[id] = poligono;
        }

        public override void Trasladar(UncPunto traslacion)
        {
            foreach (var poligono in Poligonos.Values)
            {
                poligono.Trasladar(traslacion);
            }
        }

        public override void Escalar(double factor, UncPunto centro)
        {
            foreach (var poligono in Poligonos.Values)
            {
                poligono.Escalar(factor, centro);
            }
        }

        public override void Rotar(double anguloX, double anguloY, double anguloZ, UncPunto centro)
        {
            foreach (var poligono in Poligonos.Values)
            {
                poligono.Rotar(anguloX, anguloY, anguloZ, centro);
            }
        }

        public override void Dibujar()
        {
            foreach (var poligono in Poligonos.Values)
            {
                poligono.Dibujar();
            }
        }
    }
}
