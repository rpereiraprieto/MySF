using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Datos.Entidades;
using System.ComponentModel;
using System.IO;
using MySql.Data;
using MySql;
using MySql.Data.MySqlClient;

/// <summary>
/// Descripción breve de AccesoDatos
/// </summary>
    
namespace Datos
{
   // public delegate void DelError(String Mensaje);

    public class ErrorConector : Exception
    {
        public override string Message
        {
            get
            {
                return base.Message ;
            }
        }

        public ErrorConector(string clase, string metodo, string mensaje)
            : base("{" + clase + "}:[" + metodo + "]" + mensaje)
        {
            bool log = Datos.Control.Globals.Cnf.log;
            if (log)
                AccesoDatosMySql.Error("{" + clase + "}:[" + metodo + "]" + "=> " + mensaje);
        }
    }

    public class AccesoDatosMySql:IDisposable
    {
        public static  string Log { get; set; }

        #region Atributos
        string mensaje="";
        string server = "";
        static MySqlConnection conex = new MySqlConnection();
        string _servidor="", _database="", _usuario="", _clave="";
        #endregion

        #region Propiedades
        public string Mensaje
        {
            get { return mensaje; }
        }
        #endregion

        #region Contructores

        public AccesoDatosMySql()
        {
            server = conex.DataSource;
            if (Log==null || Log == "")
                Log = Directory.GetCurrentDirectory();
        }

        public AccesoDatosMySql(string servidor, string database,string usuario,string clave)
        {
            _servidor = servidor;
            _database = database;
            _usuario = usuario;
            _clave = clave;
        }

        #endregion

        #region Conexion/Desconexion

        public Boolean Conectar()
        {
            try
            {
                string server, database, user, pass;

                if (conex.State != System.Data.ConnectionState.Open)
                {
                    if(_servidor!=string.Empty)
                    {
                        server = _servidor;
                        database = _database;
                        user = _usuario;
                        pass = _clave;
                    }
                    else
                    {
                        server = Datos.Control.Globals.Cnf.remoteServer;
                        database = Datos.Control.Globals.Cnf.remoteDatabase;
                        user = Datos.Control.Globals.Cnf.remoteUser;
                        pass = Datos.Control.Globals.Cnf.desencriptadaremotepass;
                    }

                    conex.ConnectionString = string.Format("Data Source={0}; Initial Catalog={1}; User Id={2}; password={3};pooling=True;Min Pool Size=2;Max Pool Size=5;Allow Zero Datetime=true;Convert Zero Datetime=true", server, database, user, pass);
                    conex.Open();
                }
                return true;
            }
            catch (MySqlException ex)
            {
                mensaje=$"{ex.Message}";
                Error("Conectar: " + ex.Message + ": "+ Datos.Control.Globals.Cnf.remoteServer   + ", " + conex.ConnectionString);
                return false;
            }
        }




        public static void Desconectar()
        {
            if (conex.State ==System.Data.ConnectionState.Open)
            {
                conex.Close();
            }
        }

        public void Dispose()
        {
            Desconectar();
        }

        #endregion

        //#region Metodo Consultar
        //public DataTable Consultar(string comandoSql)
        //{
        //    if (!Conectar())
        //        return null;
        //    if (comandoSql == "")
        //    {
        //        mensaje="Tienes que introducir un comando";
        //        return null;
        //    }

        //    MySqlCommand cmd = new MySqlCommand(comandoSql, conex);

        //    try
        //    {
        //        MySqlDataReader sdr = cmd.ExecuteReader();
        //        DataTable dt = new DataTable();
        //        dt.Load(sdr);
        //        return dt;
        //    }
        //    catch (MySqlException ex)
        //    {
        //        Error(ex.Message);
        //        mensaje = ex.Message;
        //        return null;
        //    }
        //}
        //#endregion

        //#region Metodo Calcular
        //public double Calcular(string operacion,string campo,string tabla,string condicion)
        //{
        //    if (!Conectar())
        //        return -1;

        //    string comandoSql = "Select " + operacion + "(" + campo + ")" + " from " + tabla + " where " + condicion;
        //    MySqlCommand cmd = new MySqlCommand(comandoSql, conex);

        //    try
        //    {
        //        double res = Convert.ToDouble( cmd.ExecuteScalar());
        //        return res;
        //    }
        //    catch (MySqlException ex)
        //    {
        //        Error(ex.Message);
        //        mensaje = ex.Message;
        //        return -1;
        //    }
        //}
        //#endregion


        //#region Metodo CalcularSumaVariosCampos
        //public double [] CalcularSumaVarios(string tabla,string [] campos,string operacion, string condicion)
        //{
        //    List<double> listaFilas = new List<double>();
        //    if (!Conectar())
        //        return null;

        //    string comandoSql = "Select ";
        //    for (int ni = 0; ni < campos.Length; ni++)
        //    {
        //        comandoSql += operacion + "(" + campos[ni] + ")" + (ni == campos.Length - 1 ? "" : ",");
        //    }
        //    comandoSql+=" from " + tabla + " where " + condicion;
        //    MySqlCommand cmd = new MySqlCommand(comandoSql, conex);

        //    try
        //    {
        //        using (MySqlDataReader sdr = cmd.ExecuteReader())
        //        {
        //            while (sdr.Read())
        //            {
        //                object[] objs = new object[sdr.FieldCount];
        //                sdr.GetValues(objs);
        //                foreach (var item in objs)
        //                    listaFilas.Add((double)item);
        //            }
        //            sdr.Close();
        //            return listaFilas.ToArray();
        //        }
        //    }
        //    catch (MySqlException ex)
        //    {
        //        Error(ex.Message);
        //        mensaje = ex.Message;
        //        return null;
        //    }
        //}
        //#endregion


        #region Select tradicional string

        public List<List<object>> Select(string [] campos,string tabla,string condicion,string orden)
        {
            List<List<object>> listaFilas = new List<List<object>>();
            string comando = "Select ";
            for (int ni = 0; ni < campos.Length; ni++)
            {
                string coma=",";
                if (ni == campos.Length - 1)
                    coma = " ";
                comando += campos[ni]+coma ;
            }
            comando += "from " + tabla;
            if (condicion != "")
                comando += " where " + condicion;
            if (orden != "")
                comando += " order by " + orden;

            try
            {
                if (!Conectar())
                    return listaFilas;
                MySqlCommand cmd = new MySqlCommand(comando, conex);

                using (MySqlDataReader sdr = cmd.ExecuteReader())
                {
                    while (sdr.Read())
                    {
                        object[] objs = new object[sdr.FieldCount];
                        sdr.GetValues(objs);
                        listaFilas.Add(objs.ToList());
                    }
                    sdr.Close();
                }
                return listaFilas;

            }
            catch (MySqlException ex)
            {
                throw new ErrorConector("AccesoDatosMySql", "Select", ex.Message);
            }
        }

        #endregion

        #region SelecData

        public DataTable SelectData(string[] campos, string tabla, string condicion, string orden)
        {
            DataTable listaFilas = null;
            string comando = "Select ";
            for (int ni = 0; ni < campos.Length; ni++)
            {
                string coma = ",";
                if (ni == campos.Length - 1)
                    coma = " ";
                comando += campos[ni] + coma;
            }
            comando += "from " + tabla;
            if (condicion != "")
                comando += " where " + condicion;
            if (orden != "")
                comando += " order by " + orden;

            try
            {
                if (!Conectar())
                    return listaFilas;
                listaFilas = new DataTable();
                MySqlCommand cmd = new MySqlCommand(comando, conex);


                using (MySqlDataReader sdr = cmd.ExecuteReader())
                {
                    listaFilas.Load(sdr);
                    sdr.Close();
                }
                return listaFilas;

            }
            catch (MySqlException ex)
            {
                throw new ErrorConector("AccesoDatosMySql", "SelectData", ex.Message);
            }


        }
        #endregion

        #region Metodo SelectOne
        public List<List<object>> SelectOne(string [] campos,string tabla,string condicion,string orden)
        {
            List<List<object>> listaFilas = new List<List<object>>();
            string comando = "Select ";

            for (int ni = 0; ni < campos.Length; ni++)
            {
                string coma=",";
                if (ni == campos.Length - 1)
                    coma = " ";
                comando += campos[ni]+coma ;
            }

            comando += "from " + tabla;

            if (condicion != "")
                comando += " where " + condicion;

            if (orden != "")
                comando += " order by " + orden;

            comando += " limit 1";
            try
            {
                if (!Conectar())
                    return listaFilas;
                MySqlCommand cmd = new MySqlCommand(comando.Replace("condition","`condition`"), conex);
                using (MySqlDataReader sdr = cmd.ExecuteReader())
                {

                    while (sdr.Read())
                    {
                        object[] objs = new object[sdr.FieldCount];
                        sdr.GetValues(objs);
                        listaFilas.Add(objs.ToList());
                    }
                    sdr.Close();
                }
                return listaFilas;

            }
            catch (MySqlException ex)
            {
                throw new ErrorConector("AccesoDatosMySql", "SelectOne", ex.Message);
            }
        }
        #endregion

        #region Metodo Insert
        public int Insert(string[] campos, object[] valores, string tabla)
        {
            string delimit;
            string comando = "Insert into " + tabla + " (";
            for (int ni = 0; ni < campos.Length; ni++)
            {
                string coma=",";
                if (ni == campos.Length - 1)
                    coma = ") ";
                comando += campos[ni] + coma;

            }
            comando += " values (";

            for (int ni = 0; ni < valores.Length; ni++)
            {
                string valor = "";
                
                if (valores[ni] is string )
                {
                    valor = valores[ni].ToString();
                    delimit = "'";
                }
                else if (valores[ni] is DateTime)
                {
                    delimit = "'";
                    valor = ((DateTime)valores[ni]).ToString("yyyy-MM-dd HH:mm:ss");
                }
                else
                {
                    valor = valores[ni].ToString().Replace(",", ".");
                    delimit = "";
                }
                string coma = ",";
                if (ni == valores.Length - 1)
                    coma = ") ";
                comando += delimit + valor+ delimit + coma;
            }

            //comando += " select @@Identity";
            comando += "; select last_insert_id()";
            try
            {
                if (!Conectar())
                    throw new ErrorConector("AccesoDatosMySql", "Insert", "sin conexión");
                MySqlCommand cmd = new MySqlCommand(comando, conex);
                object obj = cmd.ExecuteScalar();
                if (obj == DBNull.Value )
                    return 0;
                else 
                    return int.Parse(obj.ToString());

            }
            catch (MySqlException ex)
            {
                throw new ErrorConector("AccesoDatosMySql", "Insert", ex.Message);
            }

        }
        #endregion

        #region Metodo Bulk
        public void Bulk( string contenido, string tabla)
        {
            System.Random rnd = new Random((int)System.DateTime.Now.Ticks);
            string file=Log + "\\" + rnd.Next(10,1000000).ToString() + ".txt";
            using (StreamWriter sw = new StreamWriter(file))
            {
                sw.Write(contenido);
                sw.Close();
            }

            string comando = "Load data local infile '" + file.Replace(@"\",@"\\") + "' into table " + tabla  + 
                             "\r\n FIELDS TERMINATED BY ',' ENCLOSED BY '\"'" + 
                             "\r\n Lines terminated by '\\r\\n'";

            try
            {
                if (!Conectar())
                    throw new ErrorConector("AccesoDatosMySql", "Bulk", "sin conexión");
                MySqlCommand cmd = new MySqlCommand(comando, conex);
                cmd.CommandTimeout = 120;
                cmd.ExecuteNonQuery();
                if (File.Exists(file))
                    File.Delete(file);
            }
            catch (Exception ex)
            {
                throw new ErrorConector("AccesoDatosMySql", "Bulk", ex.Message);
            }

        }
        #endregion

        #region Metodo Update
        public Boolean Update(string[] campos, object[] valores, string tabla, string condicion)
        {
            //Update nombreTabla set campo1=valor1,campo2=valor2 where condicion
            MySqlCommand cmd = new MySqlCommand(); ;
            string comando = "Update " + tabla + " set ";
            for (int ni = 0; ni < campos.Length; ni++)
            {

                string coma = ",";
                cmd.Parameters.AddWithValue("@" + campos[ni], valores[ni]);
                if (ni == campos.Length - 1)
                    coma = " ";
                comando += campos[ni] + "=@" +campos[ni]  + coma;
                

            }
            comando += " where " + condicion;

            try
            {
                if (!Conectar())
                    throw new ErrorConector("AccesoDatosMySql", "Update", "Sin conexión");
                cmd .CommandText=comando.Replace("condition", "`condition`");
                cmd.Connection = conex;
                cmd.ExecuteNonQuery();
                return true;

            }
            catch (MySqlException ex)
            {
                throw new ErrorConector("AccesoDatosMySql", "Update", ex.Message);
            }
        }

        #endregion

        #region Metodo Borrar
        public Boolean Borrar(string tabla, string condicion)
        {
            //Delete from tabla where condicion
            string comando = "delete from " + tabla + " where " + condicion;
            try
            {
                if (!Conectar())
                    return false;
                MySqlCommand cmd = new MySqlCommand(comando, conex);
                int res=cmd.ExecuteNonQuery();
                return true;
            }
            catch (MySqlException ex)
            {
                Error(ex.Message);
                throw new ErrorConector("AccesoDatosMySql", "Borrar", ex.Message);

            }
        }

        //public Boolean Delete(string tabla, string condicion)
        //{
        //    //Delete from tabla where condicion
        //    string comando = "delete from " + tabla + " where " + condicion;
        //    try
        //    {
        //        if (!Conectar())
        //            return false;
        //        MySqlCommand cmd = new MySqlCommand(comando, conex);
        //        cmd.ExecuteNonQuery();
        //        return true;
        //    }
        //    catch (MySqlException ex)
        //    {
        //        Error(ex.Message);
        //        mensaje = ex.Message;
        //        return false;
        //    }
        //}
        #endregion

        #region Metodo Error
        public static void Error(string _texto)
        {
            try
            {
                string file = Log + "\\log" + DateTime.Now.ToString("yyyyMMdd") + ".log";
                System.IO.StreamWriter sw = new System.IO.StreamWriter(file, true);
                sw.WriteLine(DateTime.Now.ToShortTimeString() + " - " + _texto);
                sw.Close();
            }
            catch
            {
            }
        }

        #endregion

        #region TipoNetToTipoSql
        SqlDbType TipoNetToTipoSql(string tipo)
        {
            Array valores=Enum.GetValues(typeof(SqlDbType));
            string[] nombres = Enum.GetNames(typeof(SqlDbType));

            for (int ind=0;ind < valores.Length;ind++)
            {
                if (nombres[ind].ToLower() == tipo.ToLower())
                {
                    return (SqlDbType)((int) valores.GetValue(ind));
                }
            }
            return SqlDbType.Variant;
        }
        #endregion


        object FromSqlToNet(string tipo,object valor)
        {
            switch (tipo.ToLower())
            {
                case "bit":
                    int nRes;
                    string cVal = valor.ToString();
                    if (int.TryParse(cVal, out nRes))
                        return cVal == "1";
                    else
                        return Convert.ToBoolean(valor);
                case "int":
                    return Convert.ToInt32(valor);
                case "money":
                    return Convert.ToDecimal(valor);
                case "real":
                    return Convert.ToSingle(valor);
                case "float":
                    return Convert.ToDouble(valor);
                case "smalldatetime":
                    return Convert.ToDateTime(valor);
                case "datetime":
                    return Convert.ToDateTime(valor);
                case "bigint":
                    return Convert.ToInt64(valor);
                case "tinyint":
                    return Convert.ToByte(valor);
                case "varbinary":
                case "binary":
                case "image":
                    return Convert.FromBase64String(valor.ToString());
                default:
                    return valor;
            }
        }

        internal int MaxId(string tablaGen, string _Clave)
        {
            
            string comando = string.Format("Select max({0}) from {1}",_Clave,tablaGen);
            

            try
            {
                if (!Conectar())
                    return -1;
                MySqlCommand cmd = new MySqlCommand(comando.Replace("condition", "`condition`"), conex);
                object obj= cmd.ExecuteScalar();

                return Convert.ToInt32( obj);

            }
            catch (MySqlException ex)
            {
                throw new ErrorConector("AccesoDatosMySql", "MaxId", ex.Message);
            }
        }
    }
}

