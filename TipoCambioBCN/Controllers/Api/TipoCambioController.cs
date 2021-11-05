using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TipoCambioBCN.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoCambioController : ControllerBase
    {
        [HttpGet]
        [Route("GetTipoCambio")]
        public async Task<IActionResult> GetTipoCambio()
        {
            DateTime fecha = DateTime.Now;
            Response.Response resp = new Response.Response();
            RecuperaTC_DiaRequest req = new RecuperaTC_DiaRequest();
            req.Ano = fecha.Year;
            req.Mes = fecha.Month;
            req.Dia = fecha.Day;
            try
            {
                using (var bcn = new Tipo_Cambio_BCNSoapClient(Tipo_Cambio_BCNSoapClient.EndpointConfiguration.Tipo_Cambio_BCNSoap12))
                {
                    var resul = await bcn.RecuperaTC_DiaAsync(req);
                    resp.Dolar = resul.RecuperaTC_DiaResult;
                }
                resp.Fecha = DateTime.Now.ToString("dd/MM/yyyy");
                resp.IsSuccess = true;
                return Ok(resp);
            }
            catch (Exception ex)
            {
                resp.IsSuccess = false;
                resp.Message = ex.Message;
                return Ok(resp);
            }

        }
    }
}
