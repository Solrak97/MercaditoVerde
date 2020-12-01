using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MercaditoVerde.Models
{
    public class FileAccess
    {
        public byte[] contenido { set; get; }
        public string tipo { get; set; }
        
        
        public FileAccess(byte[] contenido, string tipo)
        {
            this.contenido = contenido;
            this.tipo = tipo;
        }
        
        
        private byte[] getBytes(HttpPostedFileBase file)
        {
            byte[] bytes;
            BinaryReader reader = new BinaryReader(file.InputStream);
            bytes = reader.ReadBytes(file.ContentLength);
            return bytes;
        }
        
        
        
        
        public Tuple<byte[], string> downloadContent(string email)
        {
            //FileAdapter adapter = db.Query("CommunityMember").Select("memberSignature as fileContent", "fileType").Where("email", email).First<FileAdapter>();
            return new Tuple<byte[], string>(contenido, tipo);
        }
    }
}