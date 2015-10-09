using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Datos.Entidades
{

    class Telefono : EntidadGenericaPS<Telefono>
    {
        public static string tabla = "Telefonos";
        public int id { get; set; }
        public string numero { get; set; }
        private Contacto _contacto;
        public int idCaller { get; set; }
        public Contacto _Contacto
        {
            get {if (_contacto == null)
                    _contacto = Contacto.Buscar(idCaller);
                return _contacto; }
            set { _contacto = value; }
        }
        public int idTipo { get; set; }
        public Tipo _tipo { get; set; }
        public Tipo _Tipo
        {
            get
            {
                if (_tipo == null)
                    _tipo = Tipo.Buscar(idTipo);
                return _tipo;
            }
            set { _tipo = value; }
        }

        public Boolean fijo { get; set; }

        public Telefono()
        {
            nuevo = true;
            _Clave = "id";
        }

        public Telefono(List<object> campos)
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

        public static Telefono Buscar(int _id)
        {
            var item = (from q in lista where q.id == _id select q).FirstOrDefault();
            if (item == null)
            {
                item = Buscar("id=" + _id);
                lista.Add(item);
            }
            return item;
        }


        public static List<Telefono> Listar()
        {
            List<Telefono> listaNew = Listar("");
            foreach (var item in listaNew)
            {
                var itemAlloc = from q in lista where q.id == item.id select q;
                if (itemAlloc == null)
                    lista.Add(item);
            }
            return lista;
        }

        public static Telefono AnadeElementoLista(Telefono item)
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
