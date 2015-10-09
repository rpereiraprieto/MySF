using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using Datos.Control;

namespace Datos.Entidades
{

    class Contacto : EntidadGenericaPS<Contacto>
    {
        public static string tabla = "Callers";
        
        public int id { get; set; }
        public string nombre { get; set; }
        public int idEmpresa { get; set; }
        public Empresa _empresa;
        public Empresa _Empresa
        {
            get
            {
                if (_empresa == null)
                {
                    _empresa = Empresa.Buscar(idEmpresa);

                }
                return _empresa;
            }
            set { _empresa = value; }
        }
        public int  idGrupo { get; set; }
        public Grupo _grupo;
        public Grupo _Grupo
        {
            get
            {
                if (_grupo == null)
                {
                    _grupo = Grupo.Buscar(idGrupo);

                }
                return _grupo;
            }
            set { _grupo = value; }
        }
        public int idExtension { get; set; }
        public Extension _extension;
        public Extension _Extension
        {
            get
            {
                if (_extension == null)
                {
                    _extension = Extension.Buscar(idExtension);

                }
                return _extension;
            }
            set { _extension = value; }
        }
        public string idOutlook { get; set; }


        public Contacto()
        {
            nuevo = true;
            idOutlook = "";      
        }

        public Contacto(int _id,string _nombre,int _idExtension,string _idOutlook)
        {
            id = _id;
            nombre = _nombre;
            idGrupo = 1;
            idEmpresa = 1;
            idExtension = _idExtension;
            idOutlook = _idOutlook;
        }

        public Contacto(List<object> campos)
        {
            nuevo = false;
            AsignaValores(campos, this);
        }

        public override void Guardar()
        {
            base.Guardar();
            AnadeElementoLista(this);
            id = _Id;
        }

        public static Contacto Buscar(int _id)
        {
            var item = (from q in lista where q.id == _id select q).FirstOrDefault();
            if (item == null)
            {
                item = Buscar("id=" + _id);
                lista.Add(item);
            }
            return item;
        }

        public static List<Contacto> Listar(Extension _ext)
        {
            List<Contacto> listaNew = Listar(" idExtension=idExtension=" + _ext.id);
            foreach (var item in listaNew)
            {
                var itemAlloc = from q in lista where q.id == item.id select q;
                if (itemAlloc == null)
                    lista.Add(item);
            }
            return lista;
        }

        public static List<Contacto> Listar()
        {
            List<Contacto> listaNew = Listar("");
            foreach (var item in listaNew)
            {
                var itemAlloc = (from q in lista where q.id == item.id select q).FirstOrDefault();
                if (itemAlloc == null)
                    lista.Add(item);
            }
            return lista;
        }

        public static Contacto AnadeElementoLista(Contacto item)
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

//public static void ConstruyeVista(object objeto)
//{
//    DataRow dr = objeto as DataRow;
//    PropertyInfo[] piCont = typeof(Contacto).GetProperties();
//    PropertyInfo[] piEmp = typeof(Empresa).GetProperties();
//    PropertyInfo[] piExt = typeof(Extension).GetProperties();
//    PropertyInfo[] piGrp = typeof(Grupo).GetProperties();

//    foreach (var item in dr.ItemArray)
//    {
//        Contacto cont = new Contacto();
//        Extension ext = new Extension();
//        Grupo grp = new Grupo();
//        Empresa emp = new Empresa();

//        DataColumn dc = (DataColumn)item;
//        string prefijo = dc.ColumnName.Substring(0, dc.ColumnName.Length - dc.ColumnName.IndexOf("_")).ToLower();
//        string campo = dc.ColumnName.Substring(dc.ColumnName.IndexOf("_") + 1);
//        switch (prefijo)
//        {
//            case "callers":
//                PropertyInfo pi1 = cont.GetType().GetProperty(campo);
//                pi1.SetValue(cont, item, null);
//                break;
//            case "empresas":
//                PropertyInfo pi2 = emp.GetType().GetProperty(campo);
//                pi2.SetValue(emp, item, null);
//                break;
//            case "grupos":
//                PropertyInfo pi3 = grp.GetType().GetProperty(campo);
//                pi3.SetValue(grp, item, null);
//                break;
//            case "extensiones":
//                PropertyInfo pi4 = ext.GetType().GetProperty(campo);
//                pi4.SetValue(ext, item, null);
//                break;

//        }
//        cont._Empresa = Empresa.AnadeElementoLista(emp);
//        cont._Grupo = Grupo.AnadeElementoLista(grp);
//        cont._Extension = Extension.AnadeElementoLista(ext);
//        AnadeElementoLista(cont);

//    }
//}
