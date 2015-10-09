using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Datos.Entidades
{

    class Extension : EntidadGenericaPS<Extension>
    {
        public static string tabla = "Extensiones";
        public int id { get; set; }
        public string nombre { get; set; }

        public Extension()
        {
            nuevo = true;
            _Clave = "id";
        }

        public Extension(List<object> campos)
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

        public static Extension Buscar(int _id)
        {
            var item = (from q in lista where q.id == _id select q).FirstOrDefault();
            if (item == null)
            {
                item = Buscar("id=" + _id);
                lista.Add(item);
            }
            return item;
        }


        public static List<Extension> Listar()
        {
            List<Extension> listaNew = Listar("");
            foreach(var item in listaNew)
            {
                var itemAlloc = from q in lista where q.id == item.id select q;
                if (itemAlloc == null)
                    lista.Add(item);
            }
            return lista;
        }


        public static Extension AnadeElementoLista(Extension item)
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
