using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Dynamic;
using System.Runtime.Serialization;
using System.Reflection;
using System.Data;

namespace Datos.Entidades
{
    //public delegate void DelAccion();

    public delegate void DelAccion();
    [DataContract]
    public class EntidadGenericaPS<T>
    {
        protected bool nuevo=true;
        public event Datos.Entidades.DelAccion OnGuardar;
        public string _Error { get; set; }
        protected static List<T> lista = new List<T>();

        [DataMember]
        public int _Id
        {
            get;
            set;
        }
        public static Boolean _Cache
        {
            get;
            set;
        }

        public static string _Clave { get; set; }

        static DateTime ultimaVersion = DateTime.MinValue;

        public static DateTime _UltimaVersion
        {
            get { return ultimaVersion; }
            set { ultimaVersion = value; }
        }

        protected static List<T> listaCache = new List<T>();

        //public T Guardar()
        //{
        //    return Guardar("",_Id);
        //}

        public virtual void Guardar()
        {
            _Error = "";
            if (nuevo)
            {
               Insertar();
            }
            else
            {
                Actualizar();
            }
                if (OnGuardar != null)
                    OnGuardar();
                nuevo = false;
        }

        protected void AsignaValores(List<object> campos, T objeto)
        {
            System.Reflection.PropertyInfo[] pii = objeto.GetType().GetProperties();
            for (int ind = 0,pos=0; ind < pii.Length; ind++)
            {
                if (!pii[ind].Name.StartsWith("_"))
                {
                    pii[ind].SetValue(objeto, Convert.ChangeType(campos[pos],pii[ind].PropertyType), null);
                    pos++;
                }
            }            
        }

        static string[] DaCampos(bool conId)
        {
            List<string> res = new List<string>();
            System.Reflection.PropertyInfo[] pii = typeof(T).GetProperties();
            foreach (var item in pii)
            {
                if (!item.Name.StartsWith("_") && (conId || item.Name.ToLower() != _Clave ))
                    res.Add(item.Name);
            }

            return res.ToArray();
        }

        object[] DaValores(bool conId)
        {
            List<object> res = new List<object>();
            System.Reflection.PropertyInfo[] pii = typeof(T).GetProperties();
            foreach (var item in pii)
            {
                if (!item.Name.StartsWith("_") && (conId || item.Name.ToLower()!=_Clave))
                    res.Add(item.GetValue(this, null));
            }

            return res.ToArray();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            System.Reflection.PropertyInfo[] pii = typeof(T).GetProperties();
            foreach (var item in pii)
            {
                if (!item.Name.StartsWith("_"))
                {
                    if (sb.Length != 0)
                        sb.Append(",");
                    string valor="";
                    if(item.PropertyType==typeof(DateTime))
                            valor="\"" + ((DateTime)item.GetValue(this, null)).ToString("yyyy-MM-dd HH:mm:ss") + "\"";
                    else if(item.PropertyType==typeof(string))
                            valor="\"" + item.GetValue(this,null) + "\""; 
                    else
                            valor=item.GetValue(this, null).ToString().Replace(",",".");
                    sb.Append(valor);
                }
            }
            return sb.ToString();
        }


        private bool Insertar()
        {
            string tablaGen = ObtenTabla();
            System.Type tipo=this.GetType();
            Datos.AccesoDatosMySql ad = new Datos.AccesoDatosMySql();
            {
                int respu= ad.Insert(DaCampos(false), DaValores(false), tablaGen);
                _Id = respu;
                return true;
            }
        }

        protected static bool Bulk(string valores)
        {
            string tablaGen = ObtenTabla();
            Datos.AccesoDatosMySql ad = new Datos.AccesoDatosMySql();
            {
                ad.Bulk( valores, tablaGen);
                return true;
            }
        }


        private bool Actualizar()
        {
            string tablaGen = ObtenTabla();
            Datos.AccesoDatosMySql ad = new Datos.AccesoDatosMySql();
            {
                ad.Update(DaCampos(false), DaValores(false), tablaGen, _Clave + "=" + _Id);
                return true;
            }
        }

        void InvocaMetodo(string metodo, EntidadGenericaPS<T>  item)
        {
            System.Reflection.MethodInfo[] ppii = item.GetType().GetMethods();
            foreach (System.Reflection.MethodInfo pi in ppii)
            {
                if (pi.Name == metodo)
                {
                    pi.Invoke(item, null);
                }
            }
        }

        public bool Borrar(string condi)
        {
            string tablaGen = ObtenTabla();
            Datos.AccesoDatosMySql ad = new Datos.AccesoDatosMySql();
            {
                bool respuesta = ad.Borrar(tablaGen, condi);
                if (!respuesta)
                    _Error = ad.Mensaje;
                return respuesta;
            }
        }



        protected static T Buscar(string condicion)
        {
            if (!_Cache)
            {
                List<T> lItem = BuscarDesdeDB(condicion); //Traemos desde BD porque no es caché la entidad
                if (lItem != null && lItem.Count > 0)
                    return lItem[0];
                else
                    return default(T);
            }
            else  // Hay caché 
            {
                CargarCache();
                if (condicion != String.Empty)
                {
                    var query = listaCache.AsQueryable<T>().Where(condicion);

                    if (query.Count() > 0)
                        return query.ToList()[0];
                    else
                        return default(T);
                }
                else
                {
                    var query = listaCache.AsQueryable<T>();
                    if (query.Count() > 0)
                        return query.ToList()[0];
                    else
                        return default(T);
                }
            }
        }

        protected static List<T> Listar(string condicion)
        {
            if (!_Cache)
                return ListarDesdeDB(condicion); //Traemos desde BD porque no es caché la entidad
            else  // Hay caché 
            {
                CargarCache();
                if (condicion != String.Empty)
                {
                    var query = listaCache.AsQueryable<T>().Where(condicion);
                    if (query.Count() > 0)
                        return query.ToList();
                    else
                        return new List<T>();
                }
                else
                {
                    return listaCache;
                }
            }
        }

        protected static List<T> Listar(string condicion, string order)
        {
            if (!_Cache)
            {
                List<T> lItem = ListarDesdeDB(condicion); //Traemos desde BD porque no es caché la entidad
                    return lItem;
            }
            else  // Hay caché 
            {
                CargarCache();
                if (condicion != String.Empty)
                {
                    var query = listaCache.AsQueryable<T>().Where(condicion);
                    if (order != "")
                        query = query.OrderBy(order);

                    if (query.Count() > 0)
                        return query.ToList();
                    else
                        return null;
                }
                else
                {
                    var query = listaCache.AsQueryable<T>().OrderBy(order);
                    if (query.Count() > 0)
                        return query.ToList();
                    else
                        return null;
                }
            }
        }

        protected static List<T> ListarVista(Type tipo,string vista,string condicion, string order)
        {
               List<T> lItem = ListarDesdeDBVista(tipo, vista,condicion,order); //Traemos desde BD porque no es caché la entidad
                return lItem;
        }

        private static List<T> ListarDesdeDBVista(Type tipo,string vista, string condicion,string order)
        {
            string tablaGen = vista;
            Datos.AccesoDatosMySql ad = new Datos.AccesoDatosMySql();
            {
                List<T> lista = new List<T>();
                DataTable filas = ad.SelectData(DaCampos(true), tablaGen, condicion, order);

                if (filas!=null)
                {
                    MethodInfo mi = tipo.GetMethod("ConstruyeVista");
                    if(mi!=null)
                    foreach (var item in filas.Rows)
                    {
                          lista.Add((T)mi.Invoke(null,new object[] { item }));
                    }
                }
                return lista;
            }
        }

        protected static void CargarCache()
        {
            if (_Cache) //Es cacheable la entidad?
            {
                if (listaCache.Count == 0)  // está vacia
                {
                    listaCache = ListarDesdeDB(""); //Traemos desde BD porque la cahcé está vacia
                }
                else //tiene datos
                {
                    Nullable<DateTime> res = DaVersion();
                    if (res.HasValue)
                    {
                        if (res.Value != _UltimaVersion)
                        {
                            _UltimaVersion = res.Value;
                            listaCache = ListarDesdeDB(""); //Traemos desde BD porque la versión es anterior
                        }
                    }
                }
            }
        }

        private static  Nullable<DateTime> DaVersion()
        {
            string tablaGen = ObtenTabla();
            //using (Datos.AccesoDatosMySql ads = new Datos.AccesoDatosMySql())
            {
                return DateTime.Now;
            }
        }

        public static int MaxId()
        {
            string tablaGen = ObtenTabla();
            Datos.AccesoDatosMySql ads = new Datos.AccesoDatosMySql();
            {
                return ads.MaxId(tablaGen,_Clave);
            }
        }

        public static bool Vaciar()
        {
            string tablaGen = ObtenTabla();
            Datos.AccesoDatosMySql ads = new Datos.AccesoDatosMySql();
            {
                return ads.Borrar(tablaGen, "1=1");
            }
        }
        protected static Boolean CambioVersion()
        {
            string tablaGen = ObtenTabla();
            Datos.AccesoDatosMySql ads = new Datos.AccesoDatosMySql();
            {
                    Nullable<DateTime> res = DaVersion();
                    if (res.HasValue)
                    {
                        if (res.Value != _UltimaVersion)
                        {
                            _UltimaVersion = res.Value;
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                        return false;
            }          
        }

        private static List<T> ListarDesdeDB(string condicion)
        {
            string tablaGen = ObtenTabla();
            Datos.AccesoDatosMySql ad = new Datos.AccesoDatosMySql();
            {
                List<T> lista = new List<T>();
                List<List<object>> filas = ad.Select(DaCampos(true), tablaGen,condicion, "");

                if (filas!=null)
                {
                    foreach (var item  in filas)
                    {
                        System.Reflection.ConstructorInfo ci = typeof(T).GetConstructor(new Type[] {typeof(List<object>) });
                        lista.Add((T)ci.Invoke(new object[]{item}));
                    }
                }
                return lista;
            }
        }

        private static List<T> BuscarDesdeDB(string condicion)
        {
            string tablaGen = ObtenTabla();
            Datos.AccesoDatosMySql ad = new Datos.AccesoDatosMySql();
            {
                
                List<T> lista = new List<T>();
                List<List<object>> filas = ad.SelectOne(DaCampos(true), tablaGen, condicion, "");
                if (filas != null)
                {
                    foreach (var item in filas)
                    {
                        System.Reflection.ConstructorInfo ci = typeof(T).GetConstructor(new Type[] { typeof(List<object>) });
                        lista.Add((T)ci.Invoke(new object[] { item }));
                    }
                }
                return lista;
            }
        }

        static string ObtenTabla()
        {
            T obj=(T)(typeof(T).GetConstructor(new Type[] {})).Invoke(null);
            System.Reflection.FieldInfo[] pii = typeof(T).GetFields();
            foreach (var item in pii)
            {
                if (item.Name == "tabla")
                    return item.GetValue(obj).ToString();
            }
            return "";
        }



    }
}
