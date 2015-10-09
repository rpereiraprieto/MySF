using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.IO;
using System.Runtime.Serialization;


public class Cifrados
{
    public static string Encriptar(string cadena)
    {
        string clave = "1234567890123456";
        // Convierto la cadena y la clave en arreglos de bytes
        // para poder usarlas en las funciones de encriptacion
        byte[] cadenaBytes = Encoding.UTF8.GetBytes(cadena);
        byte[] claveBytes = Encoding.UTF8.GetBytes(clave);
        AesManaged rij = new AesManaged();
        //RijndaelManaged rij = new RijndaelManaged();
        rij.BlockSize = 128;
        byte[] vector = new byte[rij.BlockSize / 8];
        for (int ni = 0; ni < vector.Length; ni++) vector[ni] = 0 ;
        // Configuro para que use encriptacion de 256 bits.
        rij.IV = vector;
        // Declaro un encriptador que use mi clave secreta y un vector
        // de inicializacion aleatorio
        ICryptoTransform encriptador;
        encriptador = rij.CreateEncryptor(claveBytes, vector);

        // Declaro un stream de memoria para que guarde los datos
        // encriptados a medida que se van calculando
        MemoryStream memStream = new MemoryStream();

        // Declaro un stream de cifrado para que pueda escribir aqui
        // la cadena a encriptar. Esta clase utiliza el encriptador
        // y el stream de memoria para realizar la encriptacion
        // y para almacenarla
        CryptoStream cifradoStream;
        cifradoStream = new CryptoStream(memStream, encriptador, CryptoStreamMode.Write);

        // Escribo los bytes a encriptar. A medida que se va escribiendo
        // se va encriptando la cadena
        cifradoStream.Write(cadenaBytes, 0, cadenaBytes.Length);

        // Aviso que la encriptación se terminó
        cifradoStream.FlushFinalBlock();

        // Convert our encrypted data from a memory stream into a byte array.
        byte[] cipherTextBytes = memStream.ToArray();

        // Cierro los dos streams creados
        memStream.Close();
        cifradoStream.Close();

        // Convierto el resultado en base 64 para que sea legible
        // y devuelvo el resultado
        return Convert.ToBase64String(cipherTextBytes);
    }

    public static string Desencriptar(string cadena)
    {
        // Convierto la cadena y la clave en arreglos de bytes
        // para poder usarlas en las funciones de encriptacion
        // En este caso la cadena la convierta usando base 64
        // que es la codificacion usada en el metodo encriptar
        string clave = "1234567890123456";

        byte[] cadenaBytes = Convert.FromBase64String(cadena);
        byte[] claveBytes = Encoding.UTF8.GetBytes(clave);

        // Creo un objeto de la clase Rijndael
        AesManaged  rij = new AesManaged();
        rij.BlockSize = 128;  
        byte[] vector = new byte [rij.BlockSize/8];
        for (int ni = 0; ni < vector.Length; ni++) vector[ni] = 0 ;
        // Configuro para que use encriptacion de 256 bits.



        // Declaro un desencriptador que use mi clave secreta y un vector
        // de inicializacion aleatorio
        ICryptoTransform desencriptador;
        desencriptador = rij.CreateDecryptor(claveBytes, vector);

        // Declaro un stream de memoria para que guarde los datos
        // encriptados
        MemoryStream memStream = new MemoryStream(cadenaBytes);

        // Declaro un stream de cifrado para que pueda leer de aqui
        // la cadena a desencriptar. Esta clase utiliza el desencriptador
        // y el stream de memoria para realizar la desencriptacion

        // Leo todos los bytes y lo almaceno en una cadena
        string resultado="";
        try
        {
            CryptoStream cifradoStream = new CryptoStream(memStream, desencriptador, CryptoStreamMode.Read);
            StreamReader lectorStream = new StreamReader(cifradoStream);
            resultado = lectorStream.ReadToEnd();
             memStream.Close();
             cifradoStream.Close();
        }
        catch
        {
        }
        resultado=resultado.Trim('\0');
        // Cierro los dos streams creados

        // Devuelvo la cadena
        return resultado;
    }
}

