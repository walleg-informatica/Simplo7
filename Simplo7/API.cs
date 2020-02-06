using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using RestSharp;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Simplo7
{
    public class API
    {
        private readonly String httpAddress;
        private readonly String appKey;
        private readonly RestClient restClient;

        public API(String lojaId, String appKey) {
            httpAddress = $"http://{lojaId}.simplo7.net/ws";
            this.appKey = appKey;
            this.restClient = new RestClient(httpAddress);
        }

        private String GetEndpoint(Endpoints endpoint) {
            switch(endpoint){
                case Endpoints.Categorias: return "wscategorias";
                case Endpoints.Unidades: return "wsunidades";
                case Endpoints.Marcas: return "wsmarcas";
                case Endpoints.Combinacoes: return "wscombinacoes";
                case Endpoints.Produtos: return "wsprodutos";
                case Endpoints.Estoque: return "wsestoque";
                case Endpoints.Pedidos: return "wspedidos";
            }

            return "";
        }

        private Method GetMethod(Methods method) {
            switch(method) {
                case Methods.PUT: return Method.PUT;
                case Methods.POST: return Method.POST;
                case Methods.DELETE: return Method.DELETE;
            }

            return Method.GET;
        }

        private String ApiCall(Endpoints endpoint, Method method, Object body = null){
            var request = new RestRequest($"{GetEndpoint(endpoint)}.json", method);
            request.AddHeader("appKey", appKey);

            if(body != null){
                request.RequestFormat = DataFormat.Json;
                request.AddJsonBody(body);
            }

            var httpResponse = restClient.Execute(request).Content;
            return httpResponse;
        }

        public List<JObject> call(Endpoints endpoint) {
            var httpResponse = ApiCall(endpoint, Method.GET);
            dynamic json = JsonConvert.DeserializeObject(httpResponse);
            var list = (JArray)json.result;
            List<JObject> listItems = list.Children().Select(x => (JObject)x).ToList();
            
            //var id = (string)listItems.First()["Wscategoria"]["id"];
            
            return listItems;
        }

        public JObject call(Endpoints endpoint, Methods method, Object body = null){
            var httpResponse = ApiCall(endpoint, GetMethod(method), body);
            dynamic json = JsonConvert.DeserializeObject(httpResponse);
            var obj = (JObject)json.result;
            return obj;
        }
    }
}
