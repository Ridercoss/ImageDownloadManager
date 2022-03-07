using System;
using System.IO;

namespace ImageDownloadManager {
    public class MainClass {
        static void Main() {

            FileDownloadManager FDM = new FileDownloadManager();

            char next = 'Y';
            char downloadAsk = 'N';

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("#       ImageDownloadManager       #");
            Console.WriteLine("");


            do {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Ingrese la dirección de la imagen:");
                String url = Console.ReadLine();
                FDM.SaveUrlImage( url );

                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("¿Desea agregar mas enlaces? Y/N");
                next = char.Parse(Console.ReadLine());

            } while (next == 'Y');

            FDM.WriteListUrls();
            
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Se han escrito las direcciones en el archivo de paquetes.");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("¿Desea proceder a la descarga de las imagenes? Y/N");
            downloadAsk = Char.Parse( Console.ReadLine() );

            if (downloadAsk == 'Y') {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Se procede a la descarga de archivos en el paquete.");
                FDM.DownloadPackage();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Se han descargados las imagenes");
            } else {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Gracias por usar el programa.");
            }

            FDM.EmptyFileList();
            Console.ForegroundColor = ConsoleColor.White;

            
                     

        }
    }
}