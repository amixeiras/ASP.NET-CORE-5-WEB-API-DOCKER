using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASP_NET_CORE_DOCKER_API.Services.Implementations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ASP_NET_CORE_DOCKER_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculadoraController : ControllerBase
    {

        private readonly ILogger<CalculadoraController> _logger;
        public CalculadoraController(ILogger<CalculadoraController> logger)
        {
            _logger = logger;
        }

        [HttpGet("index")]
        public ActionResult Get()
        {
            return Ok("Bem vindo");
        }

        [HttpGet("somar/{firstNumber}/{secondNumber}")]
        public ActionResult Get(string firstNumber, string secondNumber)
        {
            try
            {
                if (ISNumeric(firstNumber) && ISNumeric(secondNumber))
                {
                    var sum = ConvertToDecimal(firstNumber) + ConvertToDecimal(firstNumber);
                    return Ok(sum);
                }

                return BadRequest("Entrada inválida");
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }

        }

        [HttpGet("subtrair/{firstNumber}/{secondNumber}")]
        public ActionResult Subtrair(string firstNumber, string secondNumber)
        {
            try
            {
                if (ISNumeric(firstNumber) && ISNumeric(secondNumber))
                {
                    var sum = ConvertToDecimal(firstNumber) - ConvertToDecimal(firstNumber);
                    return Ok(sum);
                }

                return BadRequest("Entrada inválida");
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }

        }

        [HttpGet("dividir/{firstNumber}/{secondNumber}")]
        public ActionResult Dividir(string firstNumber, string secondNumber)
        {
            try
            {
                if (ISNumeric(firstNumber) && ISNumeric(secondNumber))
                {
                    var sum = ConvertToDecimal(firstNumber) / ConvertToDecimal(firstNumber);
                    return Ok(sum);
                }

                return BadRequest("Entrada inválida");
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }

        }

        [HttpGet("multiplicacao/{firstNumber}/{secondNumber}")]
        public ActionResult Multiplicacao(string firstNumber, string secondNumber)
        {
            try
            {
                if (ISNumeric(firstNumber) && ISNumeric(secondNumber))
                {
                    var sum = ConvertToDecimal(firstNumber) * ConvertToDecimal(firstNumber);
                    return Ok(sum);
                }

                return BadRequest("Entrada inválida");
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }

        }

        [HttpGet("raizquadrada/{firstNumber}")]
        public ActionResult RaizQuadrada(string firstNumber)
        {
            try
            {
                if (ISNumeric(firstNumber))
                {
                    return Ok(RaizQuadrada(ConvertToDecimal(firstNumber)));
                }

                return BadRequest("Entrada inválida");
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }

        }

        [HttpGet("raizcubica/{firstNumber}")]
        public ActionResult RaizCubica(string firstNumber)
        {
            try
            {
                if (ISNumeric(firstNumber))
                {
                    return Ok(RaizCubica(ConvertToDecimal(firstNumber)));
                }

                return BadRequest("Entrada inválida");
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }

        }

        private decimal RaizCubica(decimal number)
        {
            var result = Math.Pow(Convert.ToDouble(number), 1.0/3.0);

            return Convert.ToDecimal(result);
        }

        private decimal RaizQuadrada(decimal number)
        {
            var result = Convert.ToSingle(Math.Sqrt(Convert.ToDouble(number)));

            return Convert.ToDecimal(result);
        }

        private decimal ConvertToDecimal(string firstNumber)
        {
            decimal number;
            if (decimal.TryParse(firstNumber, out number))
                return Convert.ToDecimal(firstNumber);
            return 0;
        }

        private bool ISNumeric(string strNumber)
        {
            double number;
            return double.TryParse(strNumber,
                System.Globalization.NumberStyles.Any,
                System.Globalization.NumberFormatInfo.InvariantInfo,
                out number);

        }
    }
}
