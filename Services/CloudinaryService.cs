using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Newtonsoft.Json;
using System;
using System.IO;

namespace Project_Foodle.Services
{
    internal class CloudinaryService
    {
        private readonly Cloudinary _cloudinary;

        public CloudinaryService()
        {
            // Menyimpan kredensial langsung dalam kode (bukan di file JSON)
            //tambah sini yang cloud

            // Inisialisasi akun Cloudinary
            var account = new Account(cloudName, apiKey, apiSecret);

            // Inisialisasi Cloudinary dengan akun yang telah diatur
            _cloudinary = new Cloudinary(account);
        }

        // Contoh method untuk mengupload file ke Cloudinary
        public string UploadImage(string imagePath)
        {
            var uploadParams = new ImageUploadParams()
            {
                File = new FileDescription(imagePath)
            };

            var uploadResult = _cloudinary.Upload(uploadParams);
            return uploadResult?.SecureUrl?.ToString(); // Mengembalikan URL aman dari gambar yang diupload
        }
    }
}
