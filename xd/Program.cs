// See https://aka.ms/new-console-template for more information

using System.Text;
using System;
using System.Security.Cryptography;

string IVKEY = "R3PR353N";
string EncryptionK = "rpaSPvIvVLlrcmtzPU9/c67Gkj7yL1S5";

try
{
    Console.WriteLine("Ingrese un numero");
    string numero1 = Console.ReadLine();
    int intparced;
    decimal decimalparced;

    if (int.TryParse(numero1, out int parced))
    {
        Convert.ToInt32(numero1);
        byte[] IV = ASCIIEncoding.ASCII.GetBytes(IVKEY);
        byte[] EncryptionKey = Convert.FromBase64String(EncryptionK);
        byte[] BUFFER = Encoding.UTF8.GetBytes(numero1);
        TripleDESCryptoServiceProvider des = new TripleDESCryptoServiceProvider();
        des.Key = EncryptionKey;
        des.IV = IV;

        Console.WriteLine($"El numero Encryptado es :" +
            $" {Convert.ToBase64String(des.CreateEncryptor().TransformFinalBlock(BUFFER, 0, BUFFER.Length))} ");
    }
    else if (decimal.TryParse(numero1, out decimalparced))
    {
        Console.WriteLine("Usted ingreso un numero decimal y no un numero entero");
    }
    else
    {
        Console.WriteLine("Usted coloco un string o un numero escrito y no un numero");
    }
}
catch (Exception ex)
{
    Console.WriteLine("Ocurrio el siguiente error al ejecutar el programa: " + ex.Message);
    Console.WriteLine("Porfavor comunicarse con TI");
}
finally
{
    Console.WriteLine("Precione enter para cerrar el programa");
}

