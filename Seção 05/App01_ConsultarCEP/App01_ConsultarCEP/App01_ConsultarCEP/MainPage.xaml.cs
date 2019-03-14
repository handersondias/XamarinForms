using App01_ConsultarCEP.Servico;
using App01_ConsultarCEP.Servico.Modelo;
using System;
using Xamarin.Forms;

namespace App01_ConsultarCEP
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            btnBuscar.Clicked += BuscarCEP;
        }

        private void BuscarCEP(object sender, EventArgs args)
        {

            string cep = txtCEP.Text.Trim();
            //validaçoes
            if (IsValidCEP(cep)) 
            {
                try
                {
                    Endereco endereco = ViaCEPServico.BuscarEnderecoViaCEP(cep);
                    if (endereco!=null)
                    {
                        lblResultado.Text = string.Format("Endereço: {2}, {3} {0},{1} ", endereco.Localidade, endereco.UF, endereco.Logradouro, endereco.Bairro);
                    }
                    else
                    {
                        DisplayAlert("AVISO", "Endereço não localizado no CEP informado: " + cep, "OK");
                    }
                    
                }
                catch (Exception ex)
                {

                    DisplayAlert("ERRO CRÍTICO", ex.Message, "OK");
                }

            }
           
        }
        private bool IsValidCEP(string cep)
        {
         //   bool valido = true;
            if (cep.Length!=8)
            {
                //ERRO
                DisplayAlert("ERRO"," CEP inválido! O CEP deve conter 8 númreros.","OK");
                return false;
            }
            int NovoCEP = 0;
            if (!int.TryParse(cep,out NovoCEP))
            {
                //ERRO
                DisplayAlert("ERRO", " CEP inválido! O CEP deve ser composto apenas por números", "OK");
                return false;
            }
            return true;
        }
    }
}
