using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CalculadoraCompleta_28032017.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            //inicializar valores
            ViewBag.Visor = "0";
            Session["PrimeioroOPerador"] = true;

            return View();
        }

        // GET: Post
        //string op1, op2, operador;
        //int resultado;
        //Boolean i;
        

        [HttpPost]
        public ActionResult Index(string bt, string visor)
        {

            switch (bt)
            {
                case "0":
                case "1":
                case "2":
                case "3":
                case "4":
                case "5":
                case "6":
                case "7":
                case "8":
                case "9":
                    //determinar se n VISOR só existe zero

                    //se o visor igual a "0", então visor iguial a bt, senão visor acresenta o bt no visor
                    if (visor.Equals("0")) visor = bt;
                    else visor += bt;       //visor = visor + bt
                    break;

                //se não contem a virgula adiciona a virgula
                case ",":
                    if (!visor.Contains(",")) visor += ",";
                    break;

                //se se carregou no mais ou menos, vai multiplicar com -1
                case "+/-":
                    //visor = Convert.ToDouble(visor) * -1 + "";              //"" para converter para string
                    //se o visor comeca com menos, vai trocar o visor com string vazia
                    if (visor.StartsWith("-")) visor = visor.Replace("-", "");                               // quando o meu visor comecar com o menos, retirar o meu visor o menos
                    else if(!visor.Equals("0")) visor = "-" + visor;
                    break;

                case "C":
                    visor = "0";
                    Session["PrimeioroOPerador"] = true;
                    break;

                case "+":
                case "-":
                case "x":
                case ":":

                    if ((bool)Session["PrimeioroOPerador"])
                    {
                        // guardar valor do VISOR
                        Session["operando"] = visor;
                        //limpar o VISOR
                        visor = "0";

                        // guardar o operador selecionado/carregado
                        Session["operador"] = bt;

                        //marcar como tendo utilizando o operador
                        Session["PrimeioroOPerador"] = false;
                    }
                    else
                    {
                        //se a primeira vez que se clica num OPERADOR, vou utilizar os valores anteriores
                        switch ((string)Session["operador"])
                        {
                            //recuperar  CÓDIGO da 1ª Calculadora
                        }

                        //guardar os novos valores....
                    }
                    break;
            }

            // entregar os valores à VIEW
            ViewBag.Visor = visor;

            


            return View();
        }
    }
}