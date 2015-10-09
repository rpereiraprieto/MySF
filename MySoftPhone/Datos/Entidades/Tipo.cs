using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Datos.Entidades
{

    class Tipo : EntidadGenericaPS<Tipo>
    {
        public static string tabla = "Tipos";
        public int id { get; set; }
        public string nombre { get; set; }

        public Tipo()
        {
            nuevo = true;
            _Clave = "id";
        }

        public Tipo(List<object> campos)
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

        public static Tipo Buscar(int _id)
        {
            var item = (from q in lista where q.id == _id select q).FirstOrDefault();
            if (item == null)
            {
                item = Buscar("id=" + _id);
                lista.Add(item);
            }
            return item;
        }


        public static List<Tipo> Listar()
        {
            List<Tipo> listaNew = Listar("");
            foreach (var item in listaNew)
            {
                var itemAlloc = from q in lista where q.id == item.id select q;
                if (itemAlloc == null)
                    lista.Add(item);
            }
            return lista;
        }

        public static Tipo AnadeElementoLista(Tipo item)
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
