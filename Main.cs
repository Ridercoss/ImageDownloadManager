using System;
using System.IO;

namespace ImageDownloadManager {
    public class MainClass {
        static void Main() {

            FileDownloadManager FDM = new FileDownloadManager();

            char next = 'Y';

            do {

                Console.WriteLine("#       ImageDownloadManager       #");
                Console.WriteLine("");
                Console.WriteLine("Ingrese la dirección de la imagen:");
                String url = Console.ReadLine();
                FDM.SaveUrlImage( url );

                Console.WriteLine("¿Desea agregar mas enlaces?");
                next = char.Parse(Console.ReadLine());
                

            } while (next == 'Y');
                     

        }
    }
}