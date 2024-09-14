namespace ConsoleApp3
{
    public abstract class Figura3D
    {
        public abstract void Trasladar(UncPunto traslacion);
        public abstract void Escalar(double factor, UncPunto centro);
        public abstract void Rotar(double anguloX, double anguloY, double anguloZ, UncPunto centro);
        public abstract void Dibujar();
    }
}
