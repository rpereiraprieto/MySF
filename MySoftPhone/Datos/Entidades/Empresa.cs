using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Datos.Entidades;

    namespace Datos.Entidades
    {

    class Empresa : EntidadGenericaPS<Empresa>
    {
        public static string tabla = "Empresas";
        public int id { get; set; }
        public string nombre { get; set; }

        public Empresa()
        {
            nuevo = true;
            _Clave = "id";
        }

        public Empresa(List<object> campos)
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

        public static Empresa Buscar(int _id)
        {
            var item = (from q in lista where q.id == _id select q).FirstOrDefault();
            if (item == null)
            {
                item = Buscar("id=" + _id);
                lista.Add(item);
            }
            return item;
        }

        public static List<Empresa> Listar()
        {
            List<Empresa> listaNew = Listar("");
            foreach (var item in listaNew)
            {
                var itemAlloc = from q in lista where q.id == item.id select q;
                if (itemAlloc == null)
                    lista.Add(item);
            }
            return lista;
        }

        public static Empresa AnadeElementoLista(Empresa item)
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
