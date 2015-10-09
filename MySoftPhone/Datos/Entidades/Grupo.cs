using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Datos.Entidades
{

    class Grupo : EntidadGenericaPS<Grupo>
    {
        public static string tabla = "Grupos";
        public int id { get; set; }
        public string nombre { get; set; }

        public Grupo()
        {
            nuevo = true;
            _Clave = "id";
        }

        public Grupo(List<object> campos)
        {
            nuevo = false;
            _Clave = "id";
            AsignaValores(campos, this);
        }

        public override void Guardar()
        {
            base.Guardar();
            AnadeElementoLista(this);
            id = _Id;
        }

        public static Grupo Buscar(int _id)
        {
            var item = (from q in lista where q.id == _id select q).FirstOrDefault();
            if (item == null)
            {
                item = Buscar("id=" + _id);
                lista.Add(item);
            }
            return item;
        }


        public static List<Grupo> Listar()
        {
            List<Grupo> listaNew = Listar("");
            foreach (var item in listaNew)
            {
                var itemAlloc = from q in lista where q.id == item.id select q;
                if (itemAlloc == null)
                    lista.Add(item);
            }
            return lista;
        }

        public static Grupo AnadeElementoLista(Grupo item)
        {
            var elemento = (from q in lista where item.id == q.id select q).FirstOrDefault();
            if (elemento == null)
            {
                lista.Add(item);
                return item;
            }
            else
                return elemento;

        }

    }

}
