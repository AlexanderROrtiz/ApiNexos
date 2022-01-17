using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using WebNexos.Entitys;

namespace WebNexos.Models
{
    public class LibroModel
    {

        private String UriApi;
        MediaTypeWithQualityHeaderValue mediaheader;
        public LibroModel()
        {

            this.UriApi = "https://localhost:7119/"; 
            this.mediaheader = new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json");
        }

        public async Task<List<LibroEntity>> GetLibro()
        {
            using (HttpClient client = new HttpClient())
            {
                String petition = "api/Libro";
                client.BaseAddress = new Uri(this.UriApi);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(mediaheader);
                HttpResponseMessage respuesta = await client.GetAsync(petition);
                if (respuesta.IsSuccessStatusCode)
                {
                    List<LibroEntity> cList = await respuesta.Content.ReadAsAsync<List<LibroEntity>>();
                    return cList;
                }
                else { return null; }
            }
        }


        public async Task<LibroEntity> GetLibroByID(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                String petition = "api/Libro/" + id;
                client.BaseAddress = new Uri(this.UriApi);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(mediaheader);
                HttpResponseMessage respuesta = await client.GetAsync(petition);
                if (respuesta.IsSuccessStatusCode)
                {
                    LibroEntity c = await respuesta.Content.ReadAsAsync<LibroEntity>();
                    return c;
                }
                else { return null; }
            }
        }


        public async Task AddLibro(LibroEntity c)
        {
            using (HttpClient client = new HttpClient())
            {
                String peticion = "api/Libro/";
                client.BaseAddress = new Uri(this.UriApi);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(mediaheader);
                await client.PostAsJsonAsync(peticion, c);
            }
        }

        public async Task EditLibro(LibroEntity c)
        {
            using (HttpClient client = new HttpClient())
            {
                String peticion = "api/Libro/";
                client.BaseAddress = new Uri(this.UriApi);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(mediaheader);
                await client.PutAsJsonAsync(peticion, c);
            }
        }

        public async Task DeleteLibro(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                String peticion = "api/Libro/" + id;
                client.BaseAddress = new Uri(this.UriApi);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(mediaheader);
                await client.DeleteAsync(peticion);
            }
        }

    }
}