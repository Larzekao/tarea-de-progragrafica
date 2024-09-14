//using System.Collections.Generic;
//using ConsoleApp3.Figuras_en_3d.ConsoleApp3;
//using OpenTK.Graphics;

//namespace ConsoleApp3
//{
//    public class GestorGraficas
//    {
//        // Diccionario para gestionar múltiples escenarios
//        private Dictionary<string, Escenario> escenarios;

//        // Diccionario para gestionar figuras independientes (no necesariamente ligadas a un escenario)
//        private Dictionary<string, IFigura3D> figuras;

//        public GestorGraficas()
//        {
//            escenarios = new Dictionary<string, Escenario>();
//            figuras = new Dictionary<string, IFigura3D>();
//        }

//        // Método para agregar un nuevo escenario
//        public void AgregarEscenario(string id, Escenario escenario)
//        {
//            escenarios[id] = escenario;  // Agrega o actualiza un escenario
//        }

//        // Método para eliminar un escenario
//        public bool EliminarEscenario(string id)
//        {
//            return escenarios.Remove(id);  // Elimina el escenario por su id
//        }

//        // Método para obtener un escenario por su id
//        public Escenario ObtenerEscenario(string id)
//        {
//            if (escenarios.ContainsKey(id))
//            {
//                return escenarios[id];
//            }
//            return null; // Retorna null si no existe
//        }

//        // Método para agregar una figura directamente al gestor (independiente de escenarios)
//        public void AgregarFigura(string idFigura, IFigura3D figura)
//        {
//            figuras[idFigura] = figura;  // Agrega o actualiza una figura
//        }

//        // Método para eliminar una figura del gestor de figuras
//        public bool EliminarFigura(string idFigura)
//        {
//            return figuras.Remove(idFigura);  // Elimina la figura por su id
//        }

//        // Método para obtener una figura del gestor
//        public IFigura3D ObtenerFigura(string idFigura)
//        {
//            if (figuras.ContainsKey(idFigura))
//            {
//                return figuras[idFigura];
//            }
//            return null;  // Retorna null si no existe
//        }

//        // Método para agregar una figura a un escenario específico
//        public void AgregarFiguraAEscenario(string idEscenario, string idFigura, IFigura3D figura)
//        {
//            var escenario = ObtenerEscenario(idEscenario);
//            if (escenario != null)
//            {
//                escenario.AgregarFigura(idFigura, figura);  // Agrega la figura al escenario
//            }
//        }

//        // Método para agregar una figura existente del gestor a un escenario específico
//        public void AsociarFiguraExistenteAEscenario(string idEscenario, string idFigura)
//        {
//            var figura = ObtenerFigura(idFigura);
//            if (figura != null)
//            {
//                AgregarFiguraAEscenario(idEscenario, idFigura, figura);  // Asocia la figura existente al escenario
//            }
//        }

//        // Método para eliminar una figura de un escenario específico
//        public void EliminarFiguraDeEscenario(string idEscenario, string idFigura)
//        {
//            var escenario = ObtenerEscenario(idEscenario);
//            if (escenario != null)
//            {
//                escenario.EliminarFigura(idFigura);  // Elimina la figura del escenario
//            }
//        }

//        // Método para dibujar un escenario específico
//        public void DibujarEscenario(string idEscenario)
//        {
//            var escenario = ObtenerEscenario(idEscenario);
//            if (escenario != null)
//            {
//                escenario.Dibujar();  // Dibuja el escenario
//            }
//        }

//        // Método para dibujar todas las figuras independientes del gestor
//        public void DibujarFigurasIndependientes()
//        {
//            foreach (var figura in figuras.Values)
//            {
//                figura.Dibujar();  // Dibuja cada figura
//            }
//        }

//        // Método para dibujar todos los escenarios
//        public void DibujarTodosLosEscenarios()
//        {
//            foreach (var escenario in escenarios.Values)
//            {
//                escenario.Dibujar();  // Dibuja cada escenario
//            }
//        }

//        // Método para aplicar una transformación a todas las figuras de un escenario
//        public void TransformarEscenario(string idEscenario, UncPunto traslacion, double factorEscalado, UncPunto centroEscalado,
//                                         double anguloX, double anguloY, double anguloZ, UncPunto centroRotacion)
//        {
//            var escenario = ObtenerEscenario(idEscenario);
//            if (escenario != null)
//            {
//                escenario.TrasladarTodas(traslacion);
//                escenario.EscalarTodas(factorEscalado, centroEscalado);
//                escenario.RotarTodas(anguloX, anguloY, anguloZ, centroRotacion);
//            }
//        }
//    }
//}
