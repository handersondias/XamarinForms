using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using App01_ConsultarCEP.Servico.Modelo;
using Newtonsoft.Json;

namespace App01_ConsultarCEP.Servico
{
   public class ViaCEPServico
    {
        private static string EnderecoURL = "http://viacep.com.br/ws/{0}/json/";
        public static Endereco BuscarEnderecoViaCEP(string cep)
        {
            //lembrar de limpar caracteres
            string novoEnderecoURL = string.Format(EnderecoURL, cep);
            WebClient webClient = new WebClient();
            string conteudo = webClient.DownloadString(novoEnderecoURL);

            Endereco endereco = JsonConvert.DeserializeObject<Endereco>(conteudo);

            if (endereco.Cep == null)
            {
                return null;
            }

            return endereco;
        }
    }
}
