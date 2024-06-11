
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AzureOnlineShop.Models;
using Newtonsoft.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Microsoft.AspNetCore.Mvc.Formatters;
using System.Drawing.Imaging;
using System.Data;
using System.Linq;
using System.Net;
using System.Web;

namespace AzureOnlineShop.Controller
{
    public class ProductController : Microsoft.AspNetCore.Mvc.Controller
    {

        Uri baseAddress = new Uri("https://ecommerceonlineapi.azurewebsites.net/");
        private readonly HttpClient _client;

        Uri baseFnAddress = new Uri("https://efnapp.azurewebsites.net/");
        private readonly HttpClient _fnclient;
        public ProductController() {
        
            _client = new HttpClient();
            _client.BaseAddress = baseAddress;
            _fnclient = new HttpClient();
            _fnclient.BaseAddress = baseFnAddress;
        
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<ProductViewModel> products = new List<ProductViewModel>();
            HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "api/product/GetProducts").Result;
            if (response.IsSuccessStatusCode) {

                var data = response.Content.ReadAsStringAsync().Result;
                products = JsonConvert.DeserializeObject<List<ProductViewModel>>(data);

            }
            return View(products);
        }

        [HttpPost]
        public IActionResult Search(string searchText)
        {
            List<ProductViewModel> products = new List<ProductViewModel>();
            HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "api/product/SearchProduct?productName=" + searchText).Result;
            if (response.IsSuccessStatusCode)
            {

                var data = response.Content.ReadAsStringAsync().Result;
                products = JsonConvert.DeserializeObject<List<ProductViewModel>>(data);

            }
            return View(products);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

       [HttpPost]
        public IActionResult Create(ProductViewModel ProductViewModel)
        {
            List<ProductViewModel> resModel = new List<ProductViewModel>();

            string data = JsonConvert.SerializeObject(ProductViewModel);
            StringContent content = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage response = _client.PostAsync(_client.BaseAddress + "api/product/CreateProduct", content).Result;

            if (response.IsSuccessStatusCode)
            {
                data = response.Content.ReadAsStringAsync().Result;
                resModel = JsonConvert.DeserializeObject<List<ProductViewModel>>(data);

                return new RedirectResult(url: "/Product/Index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Update(ProductViewModel ProductViewModel)
        { return View(); }

        [HttpGet]
        public IActionResult Details(ProductViewModel ProductViewModel)
        { return View(ProductViewModel); }



        [HttpPost]
        public IActionResult Save(ProductViewModel ProductViewModel)
        {
            List<ProductViewModel> products = new List<ProductViewModel>();
            string data = JsonConvert.SerializeObject(ProductViewModel);
            StringContent content = new StringContent(data, System.Text.Encoding.UTF8, "application/json");

            HttpResponseMessage response = _client.PostAsync(_client.BaseAddress + "api/product/UpdateProduct", content).Result;
            if (response.IsSuccessStatusCode)
            {
                var resdata = response.Content.ReadAsStringAsync().Result;
                products = JsonConvert.DeserializeObject<List<ProductViewModel>>(resdata);

                return new RedirectResult(url: "/Product/Index");
            }
            return View();
        }
       

      
        [HttpGet]
        public IActionResult Delete(int product_id)
        {
            List<ProductViewModel> resModel = new List<ProductViewModel>();

            ProductViewModel model = new ProductViewModel();
            model.product_id = product_id;
            string data = JsonConvert.SerializeObject(model);
            StringContent content = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage response = _client.PostAsync(_client.BaseAddress + "api/product/DeleteProduct", content).Result;

            if (response.IsSuccessStatusCode)
            {
                data = response.Content.ReadAsStringAsync().Result;
                resModel = JsonConvert.DeserializeObject<List<ProductViewModel>>(data);
                
                return new RedirectResult(url: "/Product/Index", permanent: true,
                             preserveMethod: true);
            }
           return View();
        }


    }
}
