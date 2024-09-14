using ConsoleApp3.Serializacion;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using System;

namespace ConsoleApp3
{
  

    
        public class UnCGraficas : GameWindow
        {
            private Camara camara;
            private UncObjeto objeto = new UncObjeto(Color4.Violet); 
            private Escenario escenario = new Escenario(Color4.White); 
        private PlanoCartesiano plano = new PlanoCartesiano(0.1, 0.02);
        public UnCGraficas()
                : base(1920, 1080, GraphicsMode.Default, "Mi Ventana", GameWindowFlags.Fullscreen)
            {
                VSync = VSyncMode.On;
                camara = new Camara(this);  
            }

            protected override void OnLoad(EventArgs e)
            {
                base.OnLoad(e);
                GL.Enable(EnableCap.DepthTest);
                GL.ClearColor(Color4.Black);

               
                camara.IniciarMatrices(Width, Height);

                Serializador ser = new Serializador();

               
                CrearObjetoEnFormaDeT();
                ser.Serializar(objeto, "miObjetoT4854");  // Serializa el objeto en un archivo


                
            }

            // Método para crear un objeto en forma de "T"
            private void CrearObjetoEnFormaDeT()
            {
                
                double anchoHorizontal = 2.0, altoHorizontal = 0.2, profundidad = 0.5;
                double anchoVertical = 0.5, altoVertical = 1.0;

             
                UncParte rectanguloHorizontal = CrearRectangulo(anchoHorizontal, altoHorizontal, profundidad, Color4.Red);
                UncParte rectanguloVertical = CrearRectangulo(anchoVertical, altoVertical, profundidad, Color4.Blue);

               
                rectanguloHorizontal.Trasladar(new UncPunto(0.0, 0.15, 0.0));
                rectanguloVertical.Trasladar(new UncPunto(0.0, 0.0, 0.0));

                
                objeto.AñadirParte("rectanguloHorizontal", rectanguloHorizontal);
                objeto.AñadirParte("rectanguloVertical", rectanguloVertical);

                objeto.Trasladar(new UncPunto(0.2, 0.5, 0.23));
                objeto.Rotar(15, 0, 0, new UncPunto(0.2, 0.5, 0.23));
            }

            // Método para crear un rectángulo como un prisma
            private UncParte CrearRectangulo(double ancho, double alto, double profundidad, Color4 color)
            {
                UncParte rectangulo = new UncParte(color);

                // Definir los vértices del prisma rectangular
                UncPunto v1 = new UncPunto(-ancho / 2, -alto / 2, -profundidad / 2);
                UncPunto v2 = new UncPunto(ancho / 2, -alto / 2, -profundidad / 2);
                UncPunto v3 = new UncPunto(ancho / 2, alto / 2, -profundidad / 2);
                UncPunto v4 = new UncPunto(-ancho / 2, alto / 2, -profundidad / 2);
                UncPunto v5 = new UncPunto(-ancho / 2, -alto / 2, profundidad / 2);
                UncPunto v6 = new UncPunto(ancho / 2, -alto / 2, profundidad / 2);
                UncPunto v7 = new UncPunto(ancho / 2, alto / 2, profundidad / 2);
                UncPunto v8 = new UncPunto(-ancho / 2, alto / 2, profundidad / 2);

                // Crear las caras del prisma
                UncPoligono caraFrontal = new UncPoligono(color);
                caraFrontal.AñadirVertice("v1", v1);
                caraFrontal.AñadirVertice("v2", v2);
                caraFrontal.AñadirVertice("v3", v3);
                caraFrontal.AñadirVertice("v4", v4);

                UncPoligono caraTrasera = new UncPoligono(color);
                caraTrasera.AñadirVertice("v5", v5);
                caraTrasera.AñadirVertice("v6", v6);
                caraTrasera.AñadirVertice("v7", v7);
                caraTrasera.AñadirVertice("v8", v8);

                // Otras caras del prisma
                UncPoligono caraSuperior = new UncPoligono(color);
                caraSuperior.AñadirVertice("v4", v4);
                caraSuperior.AñadirVertice("v3", v3);
                caraSuperior.AñadirVertice("v7", v7);
                caraSuperior.AñadirVertice("v8", v8);

                UncPoligono caraInferior = new UncPoligono(color);
                caraInferior.AñadirVertice("v1", v1);
                caraInferior.AñadirVertice("v2", v2);
                caraInferior.AñadirVertice("v6", v6);
                caraInferior.AñadirVertice("v5", v5);

                UncPoligono caraIzquierda = new UncPoligono(color);
                caraIzquierda.AñadirVertice("v1", v1);
                caraIzquierda.AñadirVertice("v5", v5);
                caraIzquierda.AñadirVertice("v8", v8);
                caraIzquierda.AñadirVertice("v4", v4);

                UncPoligono caraDerecha = new UncPoligono(color);
                caraDerecha.AñadirVertice("v2", v2);
                caraDerecha.AñadirVertice("v6", v6);
                caraDerecha.AñadirVertice("v7", v7);
                caraDerecha.AñadirVertice("v3", v3);

                // Añadir las caras al rectángulo
                rectangulo.AñadirPoligono("caraFrontal", caraFrontal);
                rectangulo.AñadirPoligono("caraTrasera", caraTrasera);
                rectangulo.AñadirPoligono("caraSuperior", caraSuperior);
                rectangulo.AñadirPoligono("caraInferior", caraInferior);
                rectangulo.AñadirPoligono("caraIzquierda", caraIzquierda);
                rectangulo.AñadirPoligono("caraDerecha", caraDerecha);

                return rectangulo;
            }

            // Método para renderizar el escenario
            protected override void OnRenderFrame(FrameEventArgs e)
            {
                base.OnRenderFrame(e);

                GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
                camara.ConfigurarMatrices(); // Configurar la cámara
                                             //escenario.Dibujar();
            plano.Dibujar();                           // Dibujar el escenario
                objeto.Dibujar();
                SwapBuffers();
            }

            
        
    

    
        protected override void OnMouseWheel(MouseWheelEventArgs e)
        {
            camara.MouseWheel(e);  
        }

        protected override void OnMouseMove(MouseMoveEventArgs e)
        {
            camara.MouseMove(e);
        }
        protected override void OnMouseDown(MouseButtonEventArgs e)
        {
            camara.onMouseDown(e);  
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);
            KeyboardState input = Keyboard.GetState();

            if (input.IsKeyDown(Key.Escape))
            {
                Exit();
            }
        }
    }
}
