using System;
using OpenTK.Graphics.OpenGL;

namespace ConsoleApp3
{
    public class UncPunto : Figura3D
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }

        public UncPunto()
        {
            X = Y = Z = 0.0;
        }

        public UncPunto(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public override void Trasladar(UncPunto tras)
        {
            X += tras.X;
            Y += tras.Y;
            Z += tras.Z;
        }

        public override void Escalar(double factor, UncPunto centro)
        {
            X = centro.X + (X - centro.X) * factor;
            Y = centro.Y + (Y - centro.Y) * factor;
            Z = centro.Z + (Z - centro.Z) * factor;
        }

        public override void Rotar(double anguloX, double anguloY, double anguloZ, UncPunto centro)
        {
            // Conversión de grados a radianes
            double radX = Math.PI * anguloX / 180.0;
            double radY = Math.PI * anguloY / 180.0;
            double radZ = Math.PI * anguloZ / 180.0;

            double cosX = Math.Cos(radX), sinX = Math.Sin(radX);
            double cosY = Math.Cos(radY), sinY = Math.Sin(radY);
            double cosZ = Math.Cos(radZ), sinZ = Math.Sin(radZ);

            double xTemp = X - centro.X;
            double yTemp = Y - centro.Y;
            double zTemp = Z - centro.Z;

            double yRotX = yTemp * cosX - zTemp * sinX;
            double zRotX = yTemp * sinX + zTemp * cosX;

            double xRotY = xTemp * cosY + zRotX * sinY;
            double zRotY = -xTemp * sinY + zRotX * cosY;

            double xRotZ = xRotY * cosZ - yRotX * sinZ;
            double yRotZ = xRotY * sinZ + yRotX * cosZ;

            X = centro.X + xRotZ;
            Y = centro.Y + yRotZ;
            Z = centro.Z + zRotY;
        }

        public override void Dibujar()
        {
            GL.Vertex3(X, Y, Z);
        }
    }

}
