using System;
using System.Text;
using System.Net;
using System.IO;
using System.IO.Compression;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace ImageDownloadManager {
    
    public class FileDownloadManager {

        public string downloadsDir = "./downloads";
        public string imagepacktxt = "./imagepack.txt";
        public List<string> uriList = new List<string>();
        public void GetImageFromUri(string uri) {
            // Administar los protocolos SSL3 para el HTTPS
            ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
            // Inicializar Cliente Web
            WebClient cliente = new WebClient();
            // Verificar que existe el directorio de descargas
            EnsurePath();
            // Obtener Nombre de la imagen, y ruta de guardado
            string[] urio = uri.Split('/');
            string pathFinal = downloadsDir + urio[ urio.Length - 1 ];
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
            uriList.Add( url );
        }

        public void WriteListUrls() {
            File.WriteAllLines(imagepacktxt, uriList);
        }

        public void EmptyFileList() {
            File.WriteAllText(imagepacktxt, string.Empty);
        }

        public void DownloadPackage() {
            List<string> urls = new List<string>( File.ReadAllLines(imagepacktxt) );

            foreach ( var uri in urls ) {
                GetImageFromUri( uri );
            }
        }
    }

}