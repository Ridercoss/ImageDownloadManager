using System;
using System.Text;
using System.Net;
using System.IO;
using System.IO.Compression;

namespace ImageDownloadManager {
    
    public class FileDownloadManager {

        public string downloadsDir = "./downloads";
        public string imagepacktxt = "./imagepack.txt";
        public string[] uriArray;
        public void GetImageFromUri(string uri) {
            // Administar los protocolos SSL3 para el HTTPS
            ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
            // Inicializar Cliente Web
            WebClient cliente = new WebClient();
            // Verificar que existe el directorio de descargas
            EnsurePath();
            // Verificar que existe el archivo de enlaces de descarga
            EnsureTextFileStorage();
            // Obtener Nombre de la imagen, y ruta de guardado
            string[] urio = uri.Split('/');
            String pathFinal = downloadsDir + urio[ urio.Length - 1 ];
            // Descargar recurso
            cliente.DownloadFile( uri, pathFinal );

            if ( File.Exists( pathFinal ) ) {
                Console.WriteLine(pathFinal + " OK!");
            }
        }

        public void GetUrlsFromFile() {
            string[] images = File.ReadAllLines( imagepacktxt );
        }

        private void EnsurePath() {
            if (Directory.Exists(downloadsDir)) {
                Console.WriteLine("Downloads Directory OK!");
            } else {
                Directory.CreateDirectory(downloadsDir);
            }
        }

        public void EnsureTextFileStorage() {
            if ( File.Exists(imagepacktxt) ) {
                Console.WriteLine(imagepacktxt + " File OK!");
            } else {
                File.Create(imagepacktxt);
            }
        }

        public void SaveUrlImage( string url ) {
            
            EnsureTextFileStorage();

            if ( uriArray.Length != 0 ) {
                uriArray[ uriArray.Length + 1] = url;
            } else {
                uriArray[0] = url;
            }

            File.AppendAllLines(imagepacktxt, uriArray);
        }
    }

}